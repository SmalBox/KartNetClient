namespace SmalBox
{
    /// <summary>
    /// 消息名称，任何新增的消息都需要写在这里
    /// </summary>
    public class NoticeEvent
    {
        // ====================== 框架层事件 ======================

        /// <summary> 打开场景 </summary>
        public const string OPEN_SCENE = "OPEN_SCENE";
        /// <summary> 打开模块 </summary>
        public const string OPEN_MODULE = "OPEN_MODULE";
        /// <summary> 打开模块，带参数标识 </summary>
        public const string OPEN_MODULE_TAG = "OPEN_MODULE_TAG";
        /// <summary> 打开模块，带参数标识，参数内容 </summary>
        public const string OPEN_MODULE_TAG_ARGS = "OPEN_MODULE_TAG_ARGS";
        /// <summary> 关闭模块 </summary>
        public const string CLOSE_MODULE = "CLOSE_MODULE";
        /// <summary> 关闭所有Window </summary>
        public const string CLOSE_ALL_WINDOW = "CLOSE_ALL_WINDOW";
        /// <summary> 场景关闭中 </summary>
        public const string SCENE_CLOSEING = "SCENE_CLOSEING";
        /// <summary> 场景加载完毕 </summary>
        public const string SCENE_OPEN_COMPLETE = "SCENE_OPEN_COMPLETE";
        /// <summary> 关闭加载进度面板</summary>
        public const string CLOSE_LOADING_MODULE = "CLOSE_LOADING_MODULE";
        /// <summary> 场景切换完毕 </summary>
        public const string SCENE_LOADED_COMPLETE = "SCENE_LOADED_COMPLETE";

        // ====================== 逻辑层事件 ======================
        /// <summary> 网络连接状态 </summary>
        public const string SERVER_CONNECT = "SERVER_CONNECT";    // 服务器连接成功
        public const string LOGIN_SUCCESS = "LOGIN_SUCCESS";      // 登录请求成功
        public const string LOGIN_SERVER_SELECT = "LOGIN_SERVER_SELECT";      // 登录服务器请求
        public const string LOGIN_HTTP_ERROR = "LOGIN_HTTP_ERROR";      // 登录http请求报错
        public const string LOGIN_LINK_SERVER_ERROR = "LOGIN_LINK_SERVER_ERROR";      // 获取登录信息失败
        public const string LOGIN_LINK_SERVER_SUC = "LOGIN_LINK_SERVER_SUC";      // 获取登录信息成功
        public const string SERVER_ERRORCODE = "SERVER_ERRORCODE";//服务器返回错误码

        /// <summary> 属性 </summary>
        public const string ATTR_LEVELCHANGE = "ATTR_LEVELCHANGE";//博物馆等级经验变化

        /// <summary> 选中及移动 </summary>
        public const string PLAYER_MOVE = "PLAYER_MOVE";//移动
        public const string SELECT_CHANGE = "SELECT_CHANGE";//选中物体变化

        /// <summary> 主操作界面 </summary>
        public const string BUILDING_MOVE = "BUILDING_MOVE";//建筑移动
        public const string GAME_TIMEREFRESH = "GAME_TIMEREFRESH";//游戏时间刷新
        public const string CONSUMABLES_VISABLE = "CONSUMABLES_VISABLE";//消耗栏显示状态

        /// <summary> 升级界面 </summary>
        public const string OPENUPGRADETIPS = "OPENTIPS";//打开Tips
        public const string CLOSEUPGRADETIPS = "CLOSETIPS";//关闭Tips

        /// <summary> 博物馆（人物）升级 </summary>
        public const string PLAYER_LEVELUP = "PLAYER_LEVELUP";//博物馆（人物）升级界面

        /// <summary> 三消 </summary>
        public const string MATCH3_COLLECTION_TARGET = "MATCH3_COLLECTION_TARGET"; // 三消收集目标
        public const string MATCH3_REMAINING_STEPS = "MATCH3_REMAINING_STEPS"; // 三消剩余步数

        /// <summary> 声音 </summary>
        public const string MATCH3_VOLUME_MUSICAL = "MATCH3_VOLUME_MUSICAL"; // 三消剩余步数
        public const string MATCH3_VOLUME_SOUND_EFFECT = "MATCH3_VOLUME_SOUND_EFFECT"; // 三消剩余步数

        //钓鱼相关
        public const string FISHING_FINSHCLICK = "FISHING_FINSHCLICK";//点击鱼
        public const string FISHING_FINSHSELECTED = "FISHING_FINSHSELECTED";//确认选中鱼
        public const string FISHING_HOOKPOINT = "FISHING_HOOKPOINT";//产生鱼钩落点
        public const string FISHING_FISHINHOOK = "FISHING_FISHINHOOK";//鱼上钩
        public const string FISHING_END = "FISHING_HAVERST";//鱼收获
        public const string FISHING_INITFISHDATA = "FISHING_INITFISHDATA";//初始化鱼数据
        public const string FISHING_FISHCHANGE = "FISHING_FISHCHANGE";//鱼塘鱼变化
        public const string FISHING_STARTFISHING = "FISHING_STARTFISHING";//开始钓鱼
        public const string FISHING_STARTFISHINGFAIL = "FISHING_STARTFISHINGFAIL";//开始钓鱼失败
        public const string FISHING_CATCH = "FISHING_CATCH";//捕获鱼返回
        public const string FISHING_DESTROY = "FISHING_DESTROY";//鱼销毁

        // 捕虫相关
        public const string INSECT_CATCHING_CATCH = "INSECT_CATCHING_CATCH"; // 捕虫捕捉
        public const string INSECT_CATCHING_CATCHED = "INSECT_CATCHING_CATCHED"; // 捕捉到昆虫
        public const string INSECT_CATCHING_STATE = "INSECT_CATCHING_STATE"; // 捕虫状态消息
        public const string INSECT_CATCHING_CATCH_RESULT = "INSECT_CATCHING_CATCH_RESULT"; // 捕虫捕捉结果
        public const string INSECT_CATCHING_USESTRENGTH = "INSECT_CATCHING_USESTRENGTH"; // 捕虫消耗体力结果

        /// <summary> 获取任务列表成功 </summary>
        public const string TASK_GET_LIST_SUC = "TASK_GET_LIST_SUC";
        public const string TASK_NPC_CHECK = "TASK_NPC_CHECK";  // 检测NPC身上的任务
        public const string TASK_UNLOCK_FUNC = "TASK_UNLOCK_FUNC";  // 通过任务解锁功能
        public const string TASK_CHECK_NPC_EXIST = "TASK_CHECK_NPC_EXIST";  // 检测NPC显示状态

        /// <summary> 属性类资源变更 </summary>
        public const string ITEM_ATTRITEM_CHANGE = "ITEM_ATTRITEM_CHANGE";

        //博物馆相关
        public const string MUSEUM_DATAINITIALIZED = "MUSEUM_DATAINITIALIZED";//博物馆数据初始化完成
        public const string MUSEUM_SCENEITIALIZED = "MUSEUM_SCENEITIALIZED";//博物馆场景初始化完成
        public const string MUSEUM_OFFLINEREWARD = "MUSEUM_OFFLINEREWARD";//博物馆场景离线收益
        public const string MUSEUM_SETUISTATU = "MUSEUM_SETUISTATU";//博物馆设置UI状态
        public const string MUSEUM_CASELISTVISABLE = "MUSEUM_CASELISTVISABLE";//博物馆设置展柜UI状态
        public const string MUSEUM_BUILDMODECHANEG = "MUSEUM_BUILDMODECHANEG";//博物馆建造模式变化
        public const string MUSEUM_SHOWAREAUNLOCK = "MUSEUM_SHOWAREAUNLOCK";//博物馆区域可解锁
        public const string MUSEUM_AREAUNLOCK = "MUSEUM_AREAUNLOCK";//博物馆区域解锁
        public const string MUSEUM_REPAIRBOX = "MUSEUM_REPAIRBOX";//博物馆修复展柜
        public const string MUSEUM_PLACECASE = "MUSEUM_PLACECASE";//博物馆放置展柜
        public const string MUSEUM_CASELEVELUP = "MUSEUM_CASELEVELUP";//博物馆展柜升级
        public const string MUSEUM_RETRACTCASE = "MUSEUM_RETRACTCASE";//博物馆收起展柜
        public const string MUSEUM_PLACEEXHIBIT = "MUSEUM_PLACEEXHIBIT";//博物馆放置展品
        public const string MUSEUM_REPLACEEXHIBIT = "MUSEUM_REPLACEEXHIBIT";//博物馆展品跟换位置
        public const string MUSEUM_REMOVEEXHIBIT = "MUSEUM_REMOVEEXHIBIT";//博物馆移除展品
        public const string MUSEUM_CASEREWARD = "MUSEUM_CASEREWARD";//博物馆可领取奖励
        public const string MUSEUM_CASEGETREWARD = "MUSEUM_CASEGETREWARD";//博物馆获取奖励成功

        //游客相关
        public const string VISITOR_SELECT = "VISITOR_SELECT";//选中游客
        public const string VISITOR_SELECTSUSSCE = "VISITOR_SELECTSUSSCE";//确认选中游客
        public const string VISITOR_CREAT = "VISITOR_CREAT";//创建游客
        public const string VISITOR_ADDVISITOR = "VISITOR_ADDVISITOR";//添加游客
        public const string VISITOR_LEVELUP = "VISITOR_LEVELUP";//游客升级
        public const string VISITOR_LEAVE = "VISITOR_LEAVE";//游客离开
        public const string VISITOR_WATCHINGSUSSCE = "VISITOR_WATCHINGSUSSCE";//游客参观当前节点结束
        public const string VISITOR_WATCHINGLOSE = "VISITOR_WATCHINGLOSE";//游客放弃当前节点
        public const string VISITOR_SETUISTATE = "VISITOR_SETUISTATE";//游客UI
        public const string VISITOR_CLICKSENDLEVELUP = "VISITOR_CLICKSENDLEVELUP";//游客点击升级
        public const string VISITOR_NOWWATCHING = "VISITOR_NOWWATCHING";//游客当前参观
        public const string VISITOR_GETVISITORWATCHING = "VISITOR_GETVISITORWATCHING";//主动获取游客当前参观
        public const string VISITOR_CREATTASKNPC = "VISITOR_CREATTASKNPC";//创建任务NPC
        public const string VISITOR_GETREWARDSUSSCE = "VISITOR_GETREWARDSUSSCE";//领取奖励成功
        public const string VISITOR_OPENNPCTOP = "VISITOR_OPENNPCTOP";//打开NPC头顶图标
        public const string VISITOR_CLOSENPCTOP = "VISITOR_CLOSENPCTOP";//打开NPC头顶图标

        // 研究相关
        public const string RESEARCH_GET_ALL_ID = "RESEARCH_GET_ALL_ID"; // 获取所有研究项id
        public const string RESEARCH_REQUEST = "RESEARCH_REQUEST"; // 请求研究项

        // <summary> 新地图解锁 </summary>
        public const string MAP_NEW_MAP_OPEN = "MAP_NEW_MAP_OPEN";

        /// <summary> 商城相关 </summary>
        public const string SHOP_SWITCH_TYPE = "SHOP_SWITCH_TYPE";
        public const string SHOP_PURCHASE_RESPONSE = "SHOP_PURCHASE_RESPONSE";
        public const string SHOP_PURCHASE_LACK_TIP = "SHOP_PURCHASE_LACK_TIP";

        // 展柜特写
        public const string SC_FEATURE_RESET = "SC_FEATURE_RESET"; // 镜头复位
        
        // Loading界面
        public const string LOADING_SHOW_COMPLETE = "LOADING_SHOW_COMPLETE";        // LOADING界面展示完毕

        public const string GAMEHEAD_REFRESH = "GAMEHEAD_REFRESH";// 主界面头像刷新
        public const string GAMEHEAD_LIST_REFRESH = "GAMEHEAD_LIST_REFRESH";// 头像列表刷新

        //time 相关
        public const string TIMEDOWN_ONESECOND_DIS = "TIMEDOWN_ONESECOND_DIS"; //每秒触发一次
        public const string TIMEDOWN_POWER_FRESH= "TIMEDOWN_POWER_FRESH"; //体力时间刷新

        // SDK信息
        public const string SDK_USER_INFO = "SDK_USER_INFO";
        public const string SDK_USER_TOKEN = "SDK_USER_TOKEN";
        public const string SDK_LOGOUT = "SDK_LOGOUT";

        // 引导相关
        public const string GUIDE_OPERATE = "GUIDE_OPERATE";
        //场景剧情通知
        public const string TASK_STEP_COMPLETE = "TASK_STEP_COMPLETE";
        //剧情
        public const string PLOT_EVENT = "PLOT_EVENT";//剧情事件触发
        public const string PLOT_END = "PLOT_END";//剧情结束
    }
}
