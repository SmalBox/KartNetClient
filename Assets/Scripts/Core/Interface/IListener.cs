using System;

namespace SmalBox
{
    /// <summary>
    /// 操作交互接口
    /// </summary>
    public interface IListener
    {
    }

    public static class ListenerExtension
    {
        // public static void RegistListener(this IListener self, bool isRegist, EventListener listener,
        //     EventCallback0 call)
        // {
        //     if (isRegist) listener.Add(call);
        //     else listener.Remove(call);
        // }
        //
        // public static void RegistListener(this IListener self, bool isRegist, EventListener listener,
        //     EventCallback1 call)
        // {
        //     if (isRegist) listener.Add(call);
        //     else listener.Remove(call);
        // }
    }
}