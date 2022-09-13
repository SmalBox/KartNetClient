using UnityEngine;

namespace SmalBox
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
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