using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

using Google.Protobuf;
using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// TCP连接管理
    /// </summary>
    public class TcpClientManager : INotice
    {
        /// <summary>
        /// 服务器返回回调
        /// </summary>
        class NetResponseCall
        {
            /// <summary> 协议号 </summary>
            public int cmd;

            /// <summary> 回调方法 </summary>
            public Action<NetData> call;
        }

        /// <summary> 包头长度 4字节 </summary>
        private const int HEAD_SIZE = 4;

        /// <summary> 协议号长度 4字节 </summary>
        private const int CMD_SIZE = 4;

        /// <summary> 状态位长度 4字节 </summary>
        private const int STATE_SIZE = 4;
        
        /// <summary> 套字节大小 </summary>
        private const int NET_SIZE = 1024;

        /// <summary> 最大重连次数</summary>
        private const int MAX_RECONNECT_NUM = 3;

        /// <summary> 网络是否连接中 </summary>
        public bool isConnect = false;

        /// <summary> 服务器IP地址 </summary>
        private string host;

        /// <summary> 服务器端口号 </summary>
        private int port;

        /// <summary> 套字节缓冲池 </summary>
        private byte[] recvBytes = new byte[NET_SIZE];

        /// <summary> 本地缓存字节数据 </summary>
        private byte[] cacheBytes = new byte[NET_SIZE];

        /// <summary> 本地缓存数据长度</summary>
        private int cacheLength = 0;

        /// <summary> 剩余重连次数 </summary>
        private int reconnectNum = 0;

        /// <summary> 程序接 </summary>
        private Assembly assembly;

        /// <summary> 协议数据缓存 </summary>
        private NetDataPool netDataPool = new NetDataPool();

        /// <summary> 服务器回调监听列表 </summary>
        private List<NetResponseCall> responseCallList = new List<NetResponseCall>();

        /// <summary> 服务器推送监听列表 </summary>
        private Dictionary<int, Action<NetData>> serverPushDic = new Dictionary<int, Action<NetData>>();

        /// <summary> 准备好的协议数据 </summary>
        private List<NetData> netDataList = new List<NetData>();

        /// <summary> TCP客户端 </summary>
        private TcpClient tcpClient;

        public TcpClientManager()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        /// <summary> TCP建立连接 </summary>
        public void Connect(string host = "127.0.0.1", int port = 10)
        {
            lock (this)
            {
                if (!isConnect)
                {
                    this.host = host;
                    this.port = port;

                    try
                    {
                        tcpClient = new TcpClient();
                        // tcpClient.SendTimeout = 1000; // 发送延迟
                        // tcpClient.ReceiveTimeout = 1000; // 接收延迟
                        tcpClient.BeginConnect(host, port, ConnectCallback, tcpClient);
                    }
                    catch (Exception e)
                    {
                        LogUtl.LogNetwork("网络连接失败!");
                        netDataPool.Enqueue(new NetData(NetType.ConnectFailed));
                    }
                }
            }
        }

        /// <summary> 连接回调 </summary>
        private void ConnectCallback(IAsyncResult asyncResult)
        {
            lock (this)
            {
                // 已经和服务器建立连接了
                if (isConnect) return;

                TcpClient client = asyncResult.AsyncState as TcpClient;

                // 服务器未开启,尝试重连
                if (!client.Connected)
                {
                    LogUtl.LogNetwork($"服务器未开启，尝试重连......");
                    netDataPool.Enqueue(new NetData(NetType.ServerNotOpen));
                    return;
                }

                try
                {
                    // // TCP心跳检测 15秒检测一次心跳
                    // tcpClient.Client.IOControl(IOControlCode.KeepAliveValues, BitConverter.GetBytes(15), null);
                    tcpClient.EndConnect(asyncResult);
                    netDataPool.Clear();

                    isConnect = true;
                    LogUtl.LogNetwork($"服务器连接成功......");
                    netDataPool.Enqueue(new NetData(NetType.ConnectSuccess));

                    tcpClient.Client.BeginReceive(recvBytes, 0, recvBytes.Length, SocketFlags.None, OnReceiveSocket,
                        tcpClient);
                }
                catch (Exception e)
                {
                    LogUtl.LogNetwork($"服务器连接异常，重新连接......");
                    netDataPool.Enqueue(new NetData(NetType.ServerDataError));
                }
            }
        }

        /// <summary> 收到新的网络数据 </summary>
        private void OnReceiveSocket(IAsyncResult aynAsyncResult)
        {
            lock (this)
            {
                int dataLength = 0;
                try
                {
                    // 本次接收到的数据长度
                    if (tcpClient == null)
                        LogUtl.LogNetwork("TCP 客户端");
                    if (aynAsyncResult == null)
                        LogUtl.LogNetwork("AynAsyncResult 空");
                    dataLength = tcpClient.GetStream().EndRead(aynAsyncResult);
                    
                    // 服务器断开网络
                    if (dataLength == 0)
                    {
                        LogUtl.LogNetwork($"服务器主动断开网络！");
                        netDataPool.Enqueue(new NetData(NetType.ConnectDisconnect));
                        return;
                    }
                    
                    // 将socket中的数据缓存到本地
                    int needLength = cacheLength + dataLength;
                    // 剩余长度不满足数据存放，申请新的内存块
                    if (cacheBytes.Length < needLength)
                    {
                        int applyLength = GetBuffSize(needLength);
                        LogUtl.LogNetwork($"数据存储空间不足 当前{cacheLength}/{cacheBytes.Length}，需要{needLength},申请新的空间 {applyLength}");
                        byte[] copyBuff = new byte[applyLength];
                        Array.Copy(cacheBytes, 0, copyBuff, 0, cacheLength);
                        cacheBytes = copyBuff;
                    }
                    
                    Array.Copy(recvBytes, 0, cacheBytes, cacheLength, dataLength);
                    cacheLength += dataLength;
                    LogUtl.LogNetwork($"存储新的数据 当前{cacheLength}/{cacheBytes.Length}");

                    // 包头数据不足
                    if (cacheLength < HEAD_SIZE)
                    {
                        LogUtl.LogNetwork("包头数据不足，等待其他数据");
                        KeepReceive();
                        return;
                    }

                    // 解析报文长度
                    int requireLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cacheBytes, 0));
                    
                    // 网络传输出问题了，数据长度不能为负
                    if (requireLength < 0)
                    {
                        LogUtl.LogNetwork("数据传输出现问题，重新连接");
                        netDataPool.Enqueue(new NetData(NetType.ServerDataError));
                        return;
                    }
                    
                    // 报文内容未传输完毕
                    if (cacheLength < requireLength)
                    {
                        LogUtl.LogNetwork($"报文数据不足，等待其他数据 需要数据长度{cacheLength}/{requireLength}");
                        KeepReceive();
                        return;
                    }
                    
                    // 报文数据接收完毕，解析协议数据
                    DeserializationResponseData();
                }
                catch (Exception e)
                {
                    LogUtl.LogNetwork($"网络数据传输错误，重连！");
                    LogUtl.LogNetwork($"{e.StackTrace}");
                    netDataPool.Enqueue(new NetData(NetType.ServerDataError));
                    return;
                }

                KeepReceive();
            }
        }

        /// <summary> 接收下一组数据 </summary>
        private void KeepReceive()
        {
            tcpClient.Client.BeginReceive(recvBytes, 0, recvBytes.Length, SocketFlags.None, OnReceiveSocket, tcpClient);
        }

        /// <summary> 反序列化接收到的数据 </summary>
        private void DeserializationResponseData()
        {
            // LogUtl.LogNetwork("收到完整报文，开始解析协议数据");
            int requireLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cacheBytes, 0));
            int startIndex = HEAD_SIZE;
            int cmdId = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cacheBytes, startIndex));
            startIndex += CMD_SIZE;
            int state = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cacheBytes, startIndex));
            startIndex += STATE_SIZE;
            
            // 请求数据 error
            if (state != 0)
            {
                LogUtl.LogNetwork($"服务器返回错误代码 ErrorCode: {state}");
                // return;
            }

            // 取出协议数据
            IMessage protocMessage = null;
            int protocLength = requireLength - startIndex;
            byte[] protocBytes = new byte[protocLength];
            Array.Copy(cacheBytes, startIndex, protocBytes, 0, protocLength);

            // 数据重置，清除已使用的数据
            cacheLength = cacheLength - requireLength;
            int applySize = GetBuffSize(cacheLength);
            byte[] copyBuff = new byte[applySize];
            Array.Copy(cacheBytes, requireLength, copyBuff, 0, cacheLength);
            cacheBytes = copyBuff;

            // 反射创建实例
            string cmdName = ProtocbufManager.Inst.GetCmdNameById(cmdId);
            Type protoType = assembly.GetType(cmdName);
            
            // 协议CMD对应Protoc类没找到，一般是CMD写错了
            if (protoType == null)
            {
                LogUtl.LogWarning($"CMD对应的协议未找到 cmdId:{cmdId} cmdName:{cmdName}");
            }
            else
            {
                protocMessage = Activator.CreateInstance(protoType) as IMessage;
                protocMessage.MergeFrom(protocBytes);
                netDataPool.Enqueue(new NetData(NetType.ProtoData) {cmdId = cmdId, state = state, message = protocMessage});
                LogUtl.LogNetwork(
                    $"收到服务器消息 CMD:{cmdId} cmdName:{cmdName} state:{state} bytes:{requireLength}");
            }

            // 缓存中还可以读取数据 。。。
            if (cacheLength > 0 && cacheLength >= HEAD_SIZE)
            {
                requireLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(cacheBytes, 0));
                if(cacheLength >= requireLength) DeserializationResponseData();
            }
        }

        /// <summary> 重连服务器 </summary>
        private void Reconnect()
        {
            lock (this)
            {
                reconnectNum = 1;
                cacheLength = 0;
                isConnect = false;
                tcpClient.BeginConnect(host, port, ConnectCallback, tcpClient);
            }
        }

        /// <summary> 自动重连服务器 </summary>
        private void AutoReconnect()
        {
            Timers.inst.Add(5,1, (value) =>
            {
                lock (this)
                {
                    cacheLength = 0;
                    isConnect = false;
                    tcpClient.BeginConnect(host, port, ConnectCallback, tcpClient);
                }
            });
        }

        /// <summary> 断开与服务器的连接 </summary>
        public void CloseSocket()
        {
            LogUtl.LogNetwork("调用断开连接");
            lock (this)
            {
                if (isConnect)
                {
                    try
                    {
                        LogUtl.LogNetwork("断开连接");
                        tcpClient.Client.Shutdown(SocketShutdown.Both);
                    }
                    catch (Exception e)
                    {
                        tcpClient.Close();
                    }

                    tcpClient = null;
                    isConnect = false;
                    netDataPool.Clear();
                }
            }
        }

        /// <summary> 发送数据 </summary>
        public void Send(IMessage message, Action<NetData> callBack = null)
        {
            string cmdName = message.GetType().ToString();
            int cmdId = ProtocbufManager.Inst.GetCmdIdByName(cmdName);

            int index = cmdName.IndexOf("Request");
            if (index < 0)
            {
                LogUtl.LogNetwork($"未找到对应CMD:{cmdId} CmdName:{cmdName}");
                return;
            }

            string responseCmdName = cmdName.Substring(0, index) + "Response";
            int responseCmdId = ProtocbufManager.Inst.GetCmdIdByName(responseCmdName);

            // 存在服务器反馈 && 需要监听反馈通知
            if (responseCmdId > 0 && callBack != null)
            {
                responseCallList.Add(new NetResponseCall {cmd = responseCmdId, call = callBack});
            }

            lock (this)
            {
                try
                {
                    if (isConnect)
                    {
                        // 序列化数据
                        byte[] bytes = SerializationRequestData(message, cmdId);
                        tcpClient.GetStream().BeginWrite(bytes, 0, bytes.Length, OnSendSocket, tcpClient);
                        LogUtl.LogNetwork($"客户端请求数据 CMD:{cmdId} CmdName{cmdName} bytes:{bytes.Length}");
                    }
                }
                catch (Exception e)
                {
                    netDataPool.Enqueue(new NetData(NetType.SocketSendError));
                }
            }
        }

        /// <summary> 序列化要发送的数据 </summary>
        private byte[] SerializationRequestData(IMessage message, int cmdId)
        {
            byte[] msgBytes = message.ToByteArray();
            int totalLength = msgBytes.Length + CMD_SIZE + HEAD_SIZE;
            byte[] bytes = new byte[totalLength];
            byte[] lengthBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(totalLength));
            byte[] idBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(cmdId));

            int startIndex = 0;
            Array.Copy(lengthBytes, 0, bytes, startIndex, HEAD_SIZE);
            startIndex += HEAD_SIZE;
            Array.Copy(idBytes, 0, bytes, startIndex, CMD_SIZE);
            startIndex += CMD_SIZE;
            Array.Copy(msgBytes, 0, bytes, startIndex, msgBytes.Length);
            return bytes;
        }

        /// <summary> 异步数据发送完毕 </summary>
        private void OnSendSocket(IAsyncResult result)
        {
            tcpClient.GetStream().EndWrite(result);
        }

        /// <summary> 处理解析好的协议数据 </summary>
        public void ProcessNetData()
        {
            netDataList = netDataPool.GetAllNetData();
            for (int i = 0; i < netDataList.Count; i++)
            {
                if (netDataList[i].netType == NetType.ConnectSuccess)
                {
                    this.SendNotice(NoticeEvent.SERVER_CONNECT);
                }
                else if (netDataList[i].netType == NetType.ProtoData)
                {
                    int cmdId = netDataList[i].cmdId;
                    int errorCode = netDataList[i].state;
                    if (errorCode != 0)
                    {
                        this.SendNotice<int, int>(NoticeEvent.SERVER_ERRORCODE, cmdId, errorCode);
                    }

                    NetResponseCall responseCall = responseCallList.Find((value) => value.cmd == cmdId);
                    if (responseCall != null)
                    {
                        responseCall.call.Invoke(netDataList[i]);
                        responseCallList.Remove(responseCall);
                    }

                    if (serverPushDic.ContainsKey(cmdId) && serverPushDic[cmdId] != null)
                    {
                        serverPushDic[cmdId].Invoke(netDataList[i]);
                    }
                }
                else if (netDataList[i].netType == NetType.ConnectFailed)
                {
                    Disconnect("服务器连接失败");
                }
                else if (netDataList[i].netType == NetType.ConnectDisconnect)
                {
                    Disconnect("服务器连接断开");
                }
                else if (netDataList[i].netType == NetType.ServerNotOpen)
                {
                    Disconnect("服务器未开启");
                }
                else if (netDataList[i].netType == NetType.ServerDataError)
                {
                    Disconnect("服务器数据异常");
                }
                else if (netDataList[i].netType == NetType.ServerDataError)
                {
                    Disconnect("发送数据异常");
                }
            }
        }

        /// <summary> 断开连接，提示重连 </summary>
        private void Disconnect(string noticeStr)
        {
            CloseSocket();
//            UI_AlertPanel.Show(noticeStr, () => { SocketManager.Inst.GetLoginInfoAsync(); });
            //UI_AlertPanel.Show(noticeStr, JumpToLoginModule);
        }

        private void JumpToLoginModule()
        {
            this.SendNotice(NoticeEvent.OPEN_SCENE, SceneName.GAMELOGIN);
        }

        /// <summary> 注册监听的CMD </summary>
        public void RegistListener(bool isRegist, int cmdId, Action<NetData> call)
        {
            if (!serverPushDic.ContainsKey(cmdId))
            {
                serverPushDic.Add(cmdId, null);
            }

            serverPushDic[cmdId] -= call;
            
            if (isRegist)
            {
                serverPushDic[cmdId] += call;
            }
        }
        
        
        /// <summary> 计算缓冲大小 </summary>
        private int GetBuffSize(int size)
        {
            for (int i = 0; i < 10; i++)
            {
                int targetSize = NET_SIZE * (int) Math.Pow(2, i);
                if (size < targetSize) return targetSize;
            }

            return size * 2;
        }
    }
}
