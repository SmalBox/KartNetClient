namespace SmalBox
{
    public class NPCDefined
    {
        // ============ 事件相关 ===============
        public const string EVENT_REMOVE = "NPCRemoveEvent";
        public const string EVENT_CLICK = "NPCClickEvent";
        
        // ============ 动画相关 ===============
        /// <summary>动画参数名</summary>
        public const string ANIM_PARAM_NAME = "AnimState";
        
        // ============ 头顶标记 ===============
        /// <summary>无状态</summary>
        public const int TIP_STATE_NONE = 0;
        /// <summary>有任务接取</summary>
        public const int TIP_STATE_TASK = 1;
        /// <summary>有对话</summary>
        public const int TIP_STATE_TALK = 2;

        /// <summary>动画片段ID</summary>
        public enum ANIM_ID
        {
            IDLE = 0,
            WALK = 1,
            SURPRISE = 2,
            THINK = 3,
            TALK = 4,
            SPECAIL_IDLE = 5,
            TRAVEL = 6,
            WAVE = 7,
            WATCH = 8
        }
    }
}