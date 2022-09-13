using System;
using System.Reflection;

namespace SmalBox
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static T inst;

        public static T Inst
        {
            get
            {
                if (inst == null)
                {
                    var type = typeof(T);
                    var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                    {
                        throw new Exception($"Public Constructor No Found in {type.Name}");
                    }

                    inst = ctor.Invoke(null) as T;
                }

                return inst;
            }
        }
        
    }
}