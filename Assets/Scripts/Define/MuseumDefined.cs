using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// 博物馆的一些定义
    /// </summary>
    public class MuseumDefined
    {
        public const int CASE_TYPE_ALL = 0;//所有类型
        public const int CASE_TYPE_SHOWCASE = 1;//展柜
        public const int CASE_TYPE_INTERACTIVE = 2;//可交互装饰
        public const int CASE_TYPE_ORNAMENT = 3;//不可交互装饰
        public const int CASE_SUBTYPE_FISH = 1;//子类型鱼展柜
        public const int CASE_SUBTYPE_INSECT = 2;//子类型虫展柜
        public const int CASE_SUBTYPE_FOSSIL = 3;//子类型化石柜
        public const int AREAUNLOCK_CONDITION_TASKID = 1;//博物馆区域任务id解锁条件类型
        public const int AREAUNLOCK_CONDITION_EXHIBIT = 2;//博物馆区域展品数量解锁条件类型
        public const int AREAUNLOCK_CONDITION_LEVEL = 3;//博物馆区域博物馆等级解锁条件类型
    }
}
