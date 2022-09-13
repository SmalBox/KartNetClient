using Google.Protobuf;

namespace SmalBox
{

    /// <summary>
    /// 网络数据包类型
    /// </summary>
    public enum NetType
    {
        ConnectSuccess = 1,       // 服务器连接成功
        ConnectFailed = 2,        // 服务器连接失败
        ProtoData = 3,            // 新的协议数据
        ConnectDisconnect = 4,    // 服务器连接断开
        ServerNotOpen = 5,        // 服务器未开启
        ServerDataError = 6,      // 服务器数据异常
        SocketSendError = 7,      // 发送数据异常
    }
    
    /// <summary>
    /// 网络包数据
    /// </summary>
    public class NetData
    {
        /// <summary> 包的类型 </summary>
        public NetType netType;
        /// <summary> 协议号 </summary>
        public int cmdId;
        /// <summary> 协议状态，非0表示报错 </summary>
        public int state;
        /// <summary> 协议数据 </summary>
        public IMessage message;
        
        public NetData(NetType netType)
        {
            this.netType = netType;
        }
    }
}