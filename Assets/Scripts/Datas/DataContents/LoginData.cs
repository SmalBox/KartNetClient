namespace SmalBox
{
    /// <summary>
    /// 登录请求数据
    /// </summary>
    public class LoginData : Singleton<LoginData>
    {
        /// <summary> 登录账号ID </summary>
        public string loginGameId;

        /// <summary> 登录Token </summary>
        public string loginGameToken;

        /// <summary> 游戏中的账号Id </summary>
        public string playingGameId;

        /// <summary> 游戏中的Token</summary>
        public string playingGameToken;

        /// <summary> 游戏中的服务器ID </summary>
        public int playingServerId;

        /// <summary> 服务器IP </summary>
        public string ip;

        /// <summary> 服务器端口号 </summary>
        public int port;

        /// <summary> 渠道表示 default | ks </summary>
        public string channel;

    }
}