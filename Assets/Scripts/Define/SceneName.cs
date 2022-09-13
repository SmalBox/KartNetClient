using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// 场景名称定义
    /// </summary>
    public class SceneName
    {
        /// <summary> 登陆场景 </summary>
        public const string GAMELOADING = "GameLoading";
        public const string GAMELOGIN = "GameLogin";

        /// <summary> 主场景-博物馆 </summary>
        public const string MUSEUM = "Museum";

        /// <summary> 钓鱼场景1 </summary>
        public const string FISHING_1 = "Fishing1";
        public const string FISHING_2 = "Fishing2";
        public const string FISHING_3 = "Fishing3";
        
        /// <summary> 捉虫场景1 </summary>
        public const string INSECT_1 = "Scene_Insect_1";
        public const string INSECT_2 = "Scene_Insect_2";
        public const string INSECT_3 = "Scene_Insect_3";
        
        /// <summary> 主城场景 </summary>
        public const string HOMETOWN = "HomeTown";

        /// <summary> 室内场景 </summary>
        public const string HOME = "Home";

        /// <summary>  </summary>
        public const string TEMPENTRY = "TempEntry";

        /// <summary> 三消场景 </summary>
        public const string MATCH3 = "Match3";

        /// <summary> 野外场景 </summary>
        public const string MAINMAP = "MainMap";
        
        /// <summary> 场景类型 </summary>
        public const int SCENE_TYPE_MUSEUM = 0;
        public const int SCENE_TYPE_FISH = 1;
        public const int SCENE_TYPE_INSECT = 2;
        
        /// <summary> 展柜特写 </summary>
        public const string SHOWCASE_FEATURE = "ExhibitFeature";

        /// <summary> 车站 </summary>
        public const string STATION = "Station";

        /// <summary> 路口 </summary>
        public const string CROSS = "Crossing";
        /// <summary> 博物馆外 </summary>
        public const string MUSEOUT= "MuseumOutside";
    }
}
