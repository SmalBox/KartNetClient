using System.Collections.Generic;

namespace SmalBox
{
    public class NetDataPool
    {
        /// <summary> 网络数据缓存 </summary>
        private Queue<NetData> netDataQueue = new Queue<NetData>();
        
        /// <summary> 数据包入队列 </summary>
        public void Enqueue(NetData netData)
        {
            lock (netDataQueue)
            {
                netDataQueue.Enqueue(netData);
            }
        }

        /// <summary> 数据包出队列 </summary>
        public NetData Dequeue()
        {
            lock (netDataQueue)
            {
                if (netDataQueue.Count > 0)
                    return netDataQueue.Dequeue();
                return null;
            }
        }

        /// <summary> 获取所有数据 </summary>
        public List<NetData> GetAllNetData()
        {
            lock (netDataQueue)
            {
                List<NetData> dataList = new List<NetData>();
                dataList.AddRange(netDataQueue);
                netDataQueue.Clear();
                return dataList;
            }
        }

        /// <summary> 数据清空 </summary>
        public void Clear()
        {
            lock (netDataQueue)
            {
                netDataQueue.Clear();
            }
        }
    }
}