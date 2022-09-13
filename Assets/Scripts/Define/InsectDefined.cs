using UnityEngine;

namespace SmalBox
{
    public class InsectDefined
    {
        // =============== 小游戏事件 =================
        // 开始小游戏
        public const string EVENT_SHOWGAME = "InsectShowGame";
        // 小游戏结算
        public const string EVENT_ENDGAME = "InsectEndGame";
        // 小游戏点击单元
        public const string EVENT_GAMECLICK = "InsectGameClick";
        // 小游戏结果显示
        public const string EVENT_GAMERESULT = "InsectGameResult";
        
        // =============== 虫点推送事件 =================
        // 显示虫点UI
        public const string EVENT_SHOWUI = "ShowInsectUI";
        // 选择道具
        public const string EVENT_SELECTITEM = "InsectSelectItem";
        // 收到push后更新场景虫子信息
        public const string EVENT_ONREFRSHPUSH = "InsectScenePush";
        // 收到push后更新场景虫子信息
        public const string EVENT_ONITEMPUSH = "InsectItemChangePush";
        // 生成虫子
        public const string EVENT_REFRESHINSECT = "InsectRefreshInsect";
        // 生成虫点
        public const string EVENT_REFRESHSWARM = "InsectRefreshSwarm";
        // 通知虫点获取虫子生成范围
        public const string EVENT_SWARMCREATERANGE = "InsectSwarmCreateRange";
        // 创建虫子
        public const string EVENT_CREATEINSECT = "InsectCreateInsect";
        // 销毁虫子
        public const string EVENT_DELETEINSECT = "InsectDeleteInsect";
        // UI创建完成
        public const string EVENT_INSECT_UI_COMPLETE = "InsectCatchingUIComplete";
        // 点击气泡UI
        public const string EVENT_INSECT_TIPS_UI = "InsectCatchingTipsUIClick";
        
        // ============== 捕虫地图事件 ================
        // 地图速率变更通知
        public const string EVENT_SETMAPSPEED = "InsectMapSetSpeed";
        // 角色初始化完毕
        public const string EVENT_ROLEINITCOMPLETE = "InsectRoleInitComplete";
        
        // ===================== 虫点状态 ========================
        public const int SWARM_STATE_NONE = 0;      // 生成
        public const int SWARM_STATE_NORMAL = 1;    // 正常待机
        public const int SWARM_STATE_EFFECT = 2;    // 生效中
        public const int SWARM_STATE_DISABLE = 3;   // 消失
        public const int SWARM_STATE_TOEFFECT = 4;  // 转变生效过程
        
        // =================== 小游戏结果 ==================
        public const int GAME_RESULT_MISS = 0;   
        public const int GAME_RESULT_POOR = 1;
        public const int GAME_RESULT_NORMAL = 2;   
        public const int GAME_RESULT_PERFECT = 3;
        
        // =================== 小游戏分数 ==================
        public const int GAME_SCORE_MISS = 0;   
        public const int GAME_SCORE_POOR = 30;
        public const int GAME_SCORE_NORMAL = 50;   
        public const int GAME_SCORE_PERFECT = 100;
    }
}