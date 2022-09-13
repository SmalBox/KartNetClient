namespace SmalBox
{
    public class CollectionDefined
    {
        // ====================== 事件定义 =========================
        /// <summary> 页面点击 </summary>
        public const string EVENT_UI_TYPE_CLICK = "CollectUITypeClick";
        /// <summary> 等级奖励获取 </summary>
        public const string EVENT_LEVEL_RECEIVE = "CollectLevelRwdReceive";
        /// <summary> 收集物奖励获取 </summary>
        public const string EVENT_ITEM_RECEIVE = "CollectItemRwdReceive";
        
        // ====================== 分类定义 =========================
        /// <summary> 鱼类 </summary>
        public const int TYPE_FISH = 1001;
        /// <summary> 虫类 </summary>
        public const int TYPE_INSECT = 1002;
        
        // ====================== 奖励状态 =========================
        public const int REWARD_STATE_UNABLE = 0;   // 未达成
        public const int REWARD_STATE_ABLE = 1;     // 可领
        public const int REWARD_STATE_AWARDED = 2;  // 已领
    }
}