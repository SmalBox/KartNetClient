using System;

namespace SmalBox
{
    /// <summary>
    /// 模块类接口
    /// </summary>
    public interface IModule : INotice
    {
        /// <summary> 创建UI </summary>
         void CreateUI(Action loadResCompleteCall);
        
        /// <summary> 容器打开 </summary>
        void Startup();

        /// <summary> 容器关闭 </summary>
        void Reset();
        
        /// <summary> 面板销毁 </summary>
        void Dispose();
    }
}