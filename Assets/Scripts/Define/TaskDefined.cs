using UnityEngine;

namespace SmalBox
{
    public class TaskDefined
    {
        // =============== 任务类型 ================
        /// <summary> 普通任务 </summary>
        public const int TYPE_NORMAL = 0;
        
        // =============== 任务状态 ================
        /// <summary> 创建未激活 </summary>
        public const int STATE_CREATED = 0;
        /// <summary> 进行中 </summary>
        public const int STATE_ACCEPTED = 1;
        /// <summary> 已完成待领取 </summary>
        public const int STATE_FINISHED = 2;
        /// <summary> 已领取 </summary>
        public const int STATE_AWARDED = 3;
        
        // =============== 事件定义 ================
        /// <summary> 刷新任务列表 </summary>
        public const string EVENT_LISTCHANG = "TaskListChange";
        /// <summary> 刷新任务列表 </summary>
        public const string EVENT_STATECHANGE = "TaskStateChange";
        /// <summary> 图标飞行 </summary>
        public const string EVENT_GUIDE_ICON = "TaskGuideIcon";
        
        // =============== 接触接取类型 ================
        /// <summary> 进入地图触发 </summary>
        public const int TRIGGER_MAP = 1;
        /// <summary> 点击Npc触发 </summary>
        public const int TRIGGER_NPC = 2;

        // =============== 任务目标类型 =================
        /// <summary> 未定义的默认显示 </summary>
        public const int TARGET_UNDEFINED = 0;
        /// <summary> 和npc对话 </summary>
        public const int TARGET_NPC = 1;
        /// <summary> 获得资源 </summary>
        public const int TARGET_GETRES = 2;
        /// <summary> 获得资源（历史累计） </summary>
        public const int TARGET_GETRES_ALL = 3;
        /// <summary> 完成任务 </summary>
        public const int TARGET_TASK = 4;
        /// <summary> 博物馆等级 </summary>
        public const int TARGET_MUSEUM_LEVEL = 5;
        /// <summary> 进入地图 </summary>
        public const int TARGET_MAP_ENTER = 6;
        /// <summary> 收集物品 </summary>
        public const int TARGET_COLLECT = 7;
        /// <summary> 钓鱼次数 </summary>
        public const int TARGET_FISH_ACT = 8;
        /// <summary> 钓鱼次数（历史累计） </summary>
        public const int TARGET_FISH_ACT_ALL = 9;
        /// <summary> 捉虫次数 </summary>
        public const int TARGET_INSECT_ACT = 10;
        /// <summary> 捉虫次数（历史累计） </summary>
        public const int TARGET_INSECT_ACT_ALL = 11;
        /// <summary> 收集鱼类数量 </summary>
        public const int TARGET_FISH_COUNT = 12;
        /// <summary> 收集鱼类数量（历史累计） </summary>
        public const int TARGET_FISH_COUNT_ALL = 13;
        /// <summary> 收集虫类数量 </summary>
        public const int TARGET_INSECT_COUNT = 14;
        /// <summary> 收集虫类数量（历史累计） </summary>
        public const int TARGET_INSECT_COUNT_ALL = 15;
        /// <summary> 收集物到达等级 </summary>
        public const int TARGET_COLLECT_LEVEL = 16;
        /// <summary> 游客总数量 </summary>
        public const int TARGET_VISITOR_ALL = 17;
        /// <summary> 指定游客数量 </summary>
        public const int TARGET_VISITOR_COUNT = 18;
        /// <summary> 游客达到等级 </summary>
        public const int TARGET_VISITOR_LEVEL = 19;
        /// <summary> 游客解锁 </summary>
        public const int TARGET_VISITOR_UNLOCK = 20;
        /// <summary> 建造次数 </summary>
        public const int TARGET_BUILD_COUNT = 21;
        /// <summary> 建造次数（历史累计） </summary>
        public const int TARGET_BUILD_COUNT_ALL = 22;
        /// <summary> 建筑互动 </summary>
        public const int TARGET_BUILD_ACT = 23;
        /// <summary> 建筑互动（历史累计） </summary>
        public const int TARGET_BUILD_ACT_ALL = 24;
        /// <summary> 建筑达到等级 </summary>
        public const int TARGET_BUILD_LEVEL = 25;
        /// <summary> 通过建筑获得研究点 </summary>
        public const int TARGET_BUILD_GETPOINT = 26;
        /// <summary> 通过建筑获得研究点（历史累计） </summary>
        public const int TARGET_BUILD_GETPOINT_ALL = 27;
        /// <summary> 通过建筑获得金币 </summary>
        public const int TARGET_BUILD_GETGOLD = 28;
        /// <summary> 通过建筑获得金币（历史累计） </summary>
        public const int TARGET_BUILD_GETGOLD_ALL = 29;
        /// <summary> 展品在博物馆里 </summary>
        public const int TARGET_EXHIBIT_ITEM = 30;
        /// <summary> 展品被参观次数 </summary>
        public const int TARGET_EXHIBIT_VISITED = 31;
        /// <summary> 展品被参观次数（历史累计） </summary>
        public const int TARGET_EXHIBIT_VISITED_ALL = 32;
        /// <summary> 指定研究完成 </summary>
        public const int TARGET_RESEARCH_COMPLETE = 33;
    }
}