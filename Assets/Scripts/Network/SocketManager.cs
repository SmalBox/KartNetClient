
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// 服务器信息
    /// </summary>
    [Serializable]
    public class ServerInfo
    {
        /// <summary> 服务器Id </summary>
        public int id;
        /// <summary> 服务器名字 </summary>
        public string name;
    }

    /// <summary>
    /// 服务器列表信息
    /// </summary>
    [Serializable]
    public class ServerListInfo
    {
        public List<ServerInfo> srv_list = new List<ServerInfo>();
    }
    
    /// <summary>
    /// Http数据请求获取token、IP和端口号
    /// </summary>
    [Serializable]
    public class HttpResponse
    {
        /// <summary> 服务器返回的token </summary>
        public string token;
        /// <summary> Ip地址 host:port </summary>
        public string addr;
    }
    
    /// <summary>
    /// 网络管理类
    /// </summary>
    public class SocketManager : MonoSingletonDontDestory<SocketManager>, INotice
    {
        /// <summary> 任务线程回调 </summary>
        private static Action TaskCall;
        
        /// <summary> 服务器列表获取地址 </summary>
        public const string HTTPURL_SERVERLIST_LIST = "http://124.223.207.39:8080/list";
        public const string HTTPURL_SERVERLIST_LIST2 = "http://1.13.20.171:30001/list";
        //public const string HTTPURL_SERVERLIST_LIST2 = "http://124.223.207.39:8080/list";
        
        /// <summary> 服务器IP地址获取 </summary>
        public const string HTTPURL_SERVERLIST_LOGIN = "http://124.223.207.39:8080/login";
        public const string HTTPURL_SERVERLIST_LOGIN2 = "http://1.13.20.171:30001/login";
        //public const string HTTPURL_SERVERLIST_LOGIN2 = "http://124.223.207.39:8080/login";

        /// <summary> 获取服务器列表地址 </summary>
        public string httpUrlServerListIndex = HTTPURL_SERVERLIST_LIST;
        /// <summary> 获取登录服务器地址 </summary>
        public string httpUrlServerListLogin = HTTPURL_SERVERLIST_LOGIN;

        /// <summary> 用户名格式 </summary>
        public const string TEMP_ACCOUNT = "{\"account\":\"{0}\",\"srv_id\":{1},\"channel\":\"{2}\"}";
        public const string TEMP_ACCOUNT_KS = "{\"account\":\"{0}\",\"srv_id\":{1},\"channel\":\"{2}\",\"game_token\":\"{3}\"}";
        
        /// <summary> TCP网络数据管理 </summary>
        private TcpClientManager tcpClientManager = new TcpClientManager();
        
        /// <summary> Http请求返回数据 </summary>
        private HttpResponse httpResponse;

        /// <summary> 心跳包发送间隔 </summary>
        private float heartBeatSend = 1*60;
        private float heartBeatTime = 0;

        private void Start()
        {
        }
        private void Update()
        {
            // 每帧处理准备好的协议数据
            if (tcpClientManager.isConnect)
            {
                tcpClientManager.ProcessNetData();

                heartBeatTime += Time.deltaTime;
                if (heartBeatTime >= heartBeatSend)
                {
                    heartBeatTime = 0;
                    HeartBeatRequest();
                }
            }

            if (TaskCall != null)
            {
                TaskCall.Invoke();
                TaskCall = null;
            }
        }

        private void HeartBeatRequest()
        {
            HeartBeatRequest heartBeatRequest = new HeartBeatRequest();
            tcpClientManager.Send(heartBeatRequest, HeartBeatResponseRtn);
        }

        private void HeartBeatResponseRtn(NetData netData)
        {
            LogUtl.LogNetwork("HeartBeatResponseRtn");
        }

        public string GetToken()
        {
            return httpResponse == null ? "" : httpResponse.token;
        }

        public async void GetServerListAsync(Action<ServerListInfo> getServerListCall)
        {
            await Task.Run(() =>
            {
                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes("{}");
                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(httpUrlServerListIndex);
                    request.Proxy = null;
                    request.Method = "post";
                    request.ContentType = "application/json";
                    request.KeepAlive = true;

                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);

                    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    
                    string result = reader.ReadToEnd();
                    ServerListInfo serverListInfo = JsonUtility.FromJson<ServerListInfo>(result);
                    LogUtl.LogNetwork($"获取服务器列表成功: {result}");

                    TaskCall += () => { getServerListCall?.Invoke(serverListInfo); };
                }
                catch (Exception e)
                {
                    LogUtl.LogNetwork($"服务器列表请求失败! {e}");
                    TaskCall += () => { NoticeManager.Inst.SendNotice(NoticeEvent.LOGIN_HTTP_ERROR); };
                }
            });
        }


        /// <summary> 获取登录信息 addr 和 token </summary>
        public async void GetLoginInfoAsync()
        {
            await Task.Run(() =>
            {
                string content = "";

                byte[] bytes = Encoding.UTF8.GetBytes(content);

                try
                {
                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(httpUrlServerListLogin);
                    request.Method = "post";
                    request.ContentType = "application/json";
                    request.KeepAlive = true;

                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);

                    //LogUtl.LogNetwork("开始发送");
                    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    //LogUtl.LogNetwork("开始结束");
                    
                    string result = reader.ReadToEnd();
                    LogUtl.LogNetwork("读取结果" + result);
                    httpResponse = JsonUtility.FromJson<HttpResponse>(result);
                    LogUtl.LogNetwork("解json" + httpResponse.addr);
                    
                    string[] arr = httpResponse.addr.Split(':');
                    //LogUtl.LogNetwork("开始连接" + arr.Length);
                    //tcpClientManager.Connect(arr[0], int.Parse(arr[1]));
                    LoginDataProxy.Inst.SetPlayingIdAndToken(LoginDataProxy.Inst.GetLoginId(), httpResponse.token);
                    LoginDataProxy.Inst.SetIpAndPort(arr[0], int.Parse(arr[1]));
                    LogUtl.LogNetwork($"Http连接成功 token:{httpResponse.token} addr:{httpResponse.addr}");

                    TaskCall += () => { NoticeManager.Inst.SendNotice(NoticeEvent.LOGIN_LINK_SERVER_SUC); };
                }
                catch (Exception e)
                {
                    LogUtl.LogNetwork($"Http Login失败! {e}");
                    TaskCall += () => { NoticeManager.Inst.SendNotice(NoticeEvent.LOGIN_LINK_SERVER_ERROR); };
                }
            });
        }

        public void ConnectServer()
        {
            if (httpResponse == null)
            {
                LogUtl.LogNetwork($"httpResponse 为空，需要拉取登录信息!");
                return;
            }

            try
            {
                // tcp建立连接
                tcpClientManager.Connect(LoginDataProxy.Inst.GetServerIp(), LoginDataProxy.Inst.GetServerPort());
            }
            catch (Exception e)
            {
                LogUtl.LogNetwork($"连接目标服务器失败 {e.StackTrace}");
                NoticeManager.Inst.SendNotice(NoticeEvent.LOGIN_LINK_SERVER_ERROR);
            }
        }

        /// <summary> 发送数据 </summary>
        public void Send(IMessage message, Action<NetData> callBack = null)
        {
            if (tcpClientManager.isConnect)
            {
                tcpClientManager.Send(message, callBack);
            }
        }

        /// <summary> 注册监听的CMD </summary>
        public void RegistListener(bool isRegist, int cmdId, Action<NetData> call)
        {
            tcpClientManager.RegistListener(isRegist, cmdId, call);
        }

        public bool IsConnect { get => tcpClientManager.isConnect; }
       
        public void CloseSocket(Action callback)
        {
            tcpClientManager.CloseSocket();
            LoginMono.Inst.action += callback;
        }
    }
}