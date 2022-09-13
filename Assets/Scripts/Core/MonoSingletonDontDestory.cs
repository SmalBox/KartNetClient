using UnityEngine;

namespace SmalBox
{
    public class MonoSingletonDontDestory<T> : MonoBehaviour where T : MonoSingletonDontDestory<T>
    {
        private static T inst;

        public static T Inst
        {
            get
            {
                if (inst == null)
                {
                    inst = FindObjectOfType<T>();
                    if (inst != null)
                    {
                        Destroy(inst.gameObject);
                    }
                    inst = new GameObject(typeof(T).Name).AddComponent<T>();
                    DontDestroyOnLoad(inst.gameObject);
                }
                return inst;
            }
        }

		private void OnDestroy()
		{
            inst = null;
		}
	}
}