using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class LogUtl
    {
        /// <summary> 日志类型，可自定义 </summary>
        public enum LogType
        {
            White,
            Red,
            Yellow,
            Blue,
            Green
        }

        /// <summary> 日志输出 </summary>
        public static void Log(string content, LogType logType = LogType.White)
        {
            Debug.Log($"<color={GetColorStr(logType)}>{content}</color>");
        }

        /// <summary> 警告输出 </summary>
        public static void LogWarning(string content)
        {
            Debug.LogWarning(content);
        }

        /// <summary> 报错输出 </summary>
        public static void LogError(string content)
        {
            Debug.LogError(content);
        }

        /// <summary> 框架日志输出 </summary>
        public static void LogFramework(string content, LogType logType = LogType.White)
        {
            Debug.Log($"=== Framework === : <color={GetColorStr(logType)}>{content}</color>");
        }

        /// <summary> 网络日志输出 </summary>
        public static void LogNetwork(string content, LogType logType = LogType.White)
        {
            Debug.Log($"=== Network === : <color={GetColorStr(logType)}>{content}</color>");
        }

        /// <summary> 编辑器面板调试用 </summary>
        public static void LogEditor(string content, LogType logType = LogType.White)
        {
            Debug.Log($"=== Editor === : <color={GetColorStr(logType)}>{content}</color>");
        }

        /// <summary> 获取颜色代码 </summary>
        static string GetColorStr(LogType logType)
        {
            string colotStr = "#FFFFFF";
            switch (logType)
            {
                case LogType.Red:
                    colotStr = "#FF0000";
                    break;
                case LogType.Yellow:
                    colotStr = "#FFFF00";
                    break;
                case LogType.Blue:
                    colotStr = "#0000FF";
                    break;
                case LogType.Green:
                    colotStr = "#00FF00";
                    break;
            }

            return colotStr;
        }
    }
}