using System;

namespace SmalBox
{
    /// <summary>
    /// 消息功能接口
    /// </summary>
    public interface INotice
    {
    }

    public static class NoticeExtension
    {
        /// <summary> 注册消息 或 注销消息 </summary>
        /// <param name="self"></param>
        /// <param name="isRegist"> true:注册消息 false:注销消息 </param>
        /// <param name="noticeName"> 消息名称 </param>
        /// <param name="call"> 回调方法 </param>
        public static void RegistNotice(this INotice self, bool isRegist, string noticeName, Action call)
        {
            NoticeManager.Inst.RegistNotice(isRegist, noticeName, call);
        }

        /// <summary> 注册消息 或 注销消息 </summary>
        /// <typeparam name="T"> 参数 </typeparam>
        public static void RegistNotice<T>(this INotice self, bool isRegist, string noticeName, Action<T> call)
        {
            NoticeManager.Inst.RegistNotice(isRegist, noticeName, call);
        }

        /// <summary> 注册消息 或 注销消息 </summary>
        /// <typeparam name="T1,T2"> 参数1,参数2 </typeparam>
        public static void RegistNotice<T1, T2>(this INotice self, bool isRegist, string noticeName,
            Action<T1, T2> call)
        {
            NoticeManager.Inst.RegistNotice(isRegist, noticeName, call);
        }

        /// <summary> 注册消息 或 注销消息 </summary>
        /// <typeparam name="T1,T2,T3"> 参数1,参数2,参数3 </typeparam>
        public static void RegistNotice<T1, T2, T3>(this INotice self, bool isRegist, string noticeName,
            Action<T1, T2, T3> call)
        {
            NoticeManager.Inst.RegistNotice(isRegist, noticeName, call);
        }

        /// <summary> 注册消息 或 注销消息 </summary>
        /// <typeparam name="T1,T2,T3,T4"> 参数1,参数2,参数3,参数4 </typeparam>
        public static void RegistNotice<T1, T2, T3, T4>(this INotice self, bool isRegist, string noticeName,
            Action<T1, T2, T3, T4> call)
        {
            NoticeManager.Inst.RegistNotice(isRegist, noticeName, call);
        }

        /// <summary> 发送消息 </summary>
        /// <param name="noticeName"> 消息名称 </param>
        public static void SendNotice(this INotice self, string noticeName)
        {
            NoticeManager.Inst.SendNotice(noticeName);
        }

        /// <summary> 发送消息 </summary>
        /// <typeparam name="T"> 参数 </typeparam>
        public static void SendNotice<T>(this INotice self, string noticeName, T arg)
        {
            NoticeManager.Inst.SendNotice(noticeName, arg);
        }

        /// <summary> 发送消息 </summary>
        /// <typeparam name="T1,T2"> 参数1,参数2 </typeparam>
        public static void SendNotice<T1, T2>(this INotice self, string noticeName, T1 arg1, T2 arg2)
        {
            NoticeManager.Inst.SendNotice(noticeName, arg1, arg2);
        }

        /// <summary> 发送消息 </summary>
        /// <typeparam name="T1,T2,T3"> 参数1,参数2,参数3 </typeparam>
        public static void SendNotice<T1, T2, T3>(this INotice self, string noticeName, T1 arg1, T2 arg2,
            T3 arg3)
        {
            NoticeManager.Inst.SendNotice(noticeName, arg1, arg2, arg3);
        }

        /// <summary> 发送消息 </summary>
        /// <typeparam name="T1,T2,T3,T4"> 参数1,参数2,参数3,参数4 </typeparam>
        public static void SendNotice<T1, T2, T3, T4>(this INotice self, string noticeName, T1 arg1, T2 arg2,
            T3 arg3, T4 arg4)
        {
            NoticeManager.Inst.SendNotice(noticeName, arg1, arg2, arg3, arg4);
        }
    }
}