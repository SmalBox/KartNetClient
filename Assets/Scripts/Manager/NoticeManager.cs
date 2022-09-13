using System;
using System.Collections.Generic;

namespace SmalBox
{
    /// <summary>
    /// 消息管理基类
    /// </summary>
    public class NoticeManager : Singleton<NoticeManager>
    {
        public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

        public void AddListener(string eventType, Delegate listenerBeingAdded)
        {
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }

            Delegate d = eventTable[eventType];
            if (d != null && d.GetType() != listenerBeingAdded.GetType())
            {
                throw new ListenerException(string.Format(
                    "Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}",
                    eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
            }
        }

        public void CheckRemoveListener(string eventType, Delegate listenerBeingRemoved)
        {
            if (eventTable.ContainsKey(eventType))
            {
                Delegate d = eventTable[eventType];

                if (d == null)
                {
                    throw new ListenerException(string.Format(
                        "Attempting to remove listener with for event type {0} but current listener is null.",
                        eventType));
                }
                else if (d.GetType() != listenerBeingRemoved.GetType())
                {
                    throw new ListenerException(string.Format(
                        "Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}",
                        eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
                }
            }
        }

        public void RegistNotice(bool isRegist, string eventType, Action handler)
        {
            if (isRegist)
            {
                AddListener(eventType, handler);
                eventTable[eventType] = (Action) eventTable[eventType] + handler;
            }
            else
            {
                CheckRemoveListener(eventType, handler);
                eventTable[eventType] = (Action) eventTable[eventType] - handler;
                if (eventTable[eventType] == null) eventTable.Remove(eventType);
            }
        }

        public void RegistNotice<T>(bool isRegist, string eventType, Action<T> handler)
        {
            if (isRegist)
            {
                AddListener(eventType, handler);
                eventTable[eventType] = (Action<T>) eventTable[eventType] + handler;
            }
            else
            {
                CheckRemoveListener(eventType, handler);
                eventTable[eventType] = (Action<T>) eventTable[eventType] - handler;
                if (eventTable[eventType] == null) eventTable.Remove(eventType);
            }
        }

        public void RegistNotice<T1, T2>(bool isRegist, string eventType, Action<T1, T2> handler)
        {
            if (isRegist)
            {
                AddListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2>) eventTable[eventType] + handler;
            }
            else
            {
                CheckRemoveListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2>) eventTable[eventType] - handler;
                if (eventTable[eventType] == null) eventTable.Remove(eventType);
            }
        }

        public void RegistNotice<T1, T2, T3>(bool isRegist, string eventType, Action<T1, T2, T3> handler)
        {
            if (isRegist)
            {
                AddListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2, T3>) eventTable[eventType] + handler;
            }
            else
            {
                CheckRemoveListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2, T3>) eventTable[eventType] - handler;
                if (eventTable[eventType] == null) eventTable.Remove(eventType);
            }
        }

        public void RegistNotice<T1, T2, T3, T4>(bool isRegist, string eventType, Action<T1, T2, T3, T4> handler)
        {
            if (isRegist)
            {
                AddListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2, T3, T4>) eventTable[eventType] + handler;
            }
            else
            {
                CheckRemoveListener(eventType, handler);
                eventTable[eventType] = (Action<T1, T2, T3, T4>) eventTable[eventType] - handler;
                if (eventTable[eventType] == null) eventTable.Remove(eventType);
            }
        }

        public void SendNotice(string eventType)
        {
            if (eventTable.TryGetValue(eventType, out Delegate d))
            {
                Action callback = d as Action;
                callback?.Invoke();
            }
        }

        public void SendNotice<T>(string eventType, T arg)
        {
            if (eventTable.TryGetValue(eventType, out Delegate d))
            {
                Action<T> callback = d as Action<T>;
                callback?.Invoke(arg);
            }
        }

        public void SendNotice<T1, T2>(string eventType, T1 arg1, T2 arg2)
        {
            if (eventTable.TryGetValue(eventType, out Delegate d))
            {
                Action<T1, T2> callback = d as Action<T1, T2>;
                callback?.Invoke(arg1, arg2);
            }
        }

        public void SendNotice<T1, T2, T3>(string eventType, T1 arg1, T2 arg2, T3 arg3)
        {
            if (eventTable.TryGetValue(eventType, out Delegate d))
            {
                Action<T1, T2, T3> callback = d as Action<T1, T2, T3>;
                callback?.Invoke(arg1, arg2, arg3);
            }
        }

        public void SendNotice<T1, T2, T3, T4>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (eventTable.TryGetValue(eventType, out Delegate d))
            {
                Action<T1, T2, T3, T4> callback = d as Action<T1, T2, T3, T4>;
                callback?.Invoke(arg1, arg2, arg3, arg4);
            }
        }

        public class ListenerException : Exception
        {
            public ListenerException(string msg)
                : base(msg)
            {
            }
        }
    }
}