namespace SmalBox
{
    public class LoginDataProxy : Singleton<LoginDataProxy>
    {
        /// <summary> 设置登录的GameId 和 Token </summary>
        public void SetLoginInfo(string gameId, string token, int serverId, string channel)
        {
            LoginData.Inst.loginGameId = gameId;
            LoginData.Inst.loginGameToken = token;
            LoginData.Inst.playingServerId = serverId;
            LoginData.Inst.channel = channel;
        }


        /// <summary> 设置游戏的GameId 和 Token </summary>
        public void SetPlayingIdAndToken(string gameId, string token)
        {
            LoginData.Inst.playingGameId = gameId;
            LoginData.Inst.playingGameToken = token;
        }

        /// <summary> 设置服务器的IP 和 端口号 </summary>
        public void SetIpAndPort(string ip, int port)
        {
            LoginData.Inst.ip = ip;
            LoginData.Inst.port = port;
        }


        public string GetServerIp()
        {
            return LoginData.Inst.ip;
        }

        public int GetServerPort()
        {
            return LoginData.Inst.port;
        }

        public int GetServerId()
        {
            return LoginData.Inst.playingServerId;
        }

        public string GetPlayingGameId()
        {
            return LoginData.Inst.playingGameId;
        }

        public string GetPlayingToken()
        {
            return LoginData.Inst.playingGameToken;
        }
        
        public string GetLoginId()
        {
            return LoginData.Inst.loginGameId;
        }

        public string GetLoginToken()
        {
            return LoginData.Inst.loginGameToken;
        }
        
        public string GetChannel()
        {
            return LoginData.Inst.channel;
        }

    }
}