using UnityEngine;

namespace SmalBox
{
    public class ProtocbufManager : MonoSingletonDontDestory<ProtocbufManager>
    {
        public ProtocbufCMD protocbufCmd;

        private void Awake()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            protocbufCmd = Resources.Load<ProtocbufCMD>("ProtocbufCMD");
        }
    
        /// <summary> 根据协议Id获取协议名称 </summary>
        public int GetCmdIdByName(string cmdName)
        {
            // 删除前缀SmalBox.
            int nameSpaceLength = ConfigValue.NAME_SPACE.Length + 1;
            int index = cmdName.IndexOf($"{ConfigValue.NAME_SPACE}");
            if (index >= 0) cmdName = cmdName.Substring(nameSpaceLength, cmdName.Length - nameSpaceLength);
            CMDInfo cmdInfo = protocbufCmd.cmdList.Find((value) => value.cmdName == cmdName);
            
            // Debug.Log("================ filter ===============");
            // var list = protocbufCmd.cmdList;
            // foreach (var cmd in list)
            // {
            //     Debug.Log("id: " + cmd.cmdId + " -- name: " + cmd.cmdName);
            // }
            if (cmdInfo == null)
            {
                LogUtl.LogNetwork($"未找到对应的CmdId CmdName:{cmdName}");
                return 0;
            }
            return cmdInfo.cmdId;
        }

        /// <summary> 根据协议名称获取协议ID </summary>
        public string GetCmdNameById(int cmdId)
        {
            CMDInfo cmdInfo = protocbufCmd.cmdList.Find((value) => value.cmdId == cmdId);
            if (cmdInfo == null) LogUtl.LogNetwork($"未找到对应的CmdName cmdId:{cmdId}");
            return $"{ConfigValue.NAME_SPACE}.{cmdInfo.cmdName}";
        }
    }
}