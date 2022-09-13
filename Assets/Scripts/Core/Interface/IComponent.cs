using System;

namespace SmalBox
{
    /// <summary>
    /// UI GComponent 的接口
    /// </summary>
    public interface IComponent
    {
        void Show(Action call = null);
        
        void CustomShowEffect(Action call = null);

        void Hide(Action call = null);

        void CustomHideEffect(Action call = null);

    }
}