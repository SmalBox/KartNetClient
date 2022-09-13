using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmalBox.Manager
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameManager : MonoSingleton<GameManager>
    {
        [Header("Kart预制体")]
        public MonoBase kartPrefab;

        /// <summary> 所有Kart对象的list </summary>
        private List<MonoBase> kartList = new List<MonoBase>();

        /// <summary>
        /// 获取当前玩家的Kart信息
        /// </summary>
        /// <returns></returns>
        public KartInfo GetPlayerKartInfo()
        {
            if (kartPrefab != null)
            {
                KartInfo info = new KartInfo();
                info.ID = kartPrefab.id;
                info.SId = kartPrefab.sId;
                Transform kartTransform = kartPrefab.transform;
                Vector3 kartPos = kartTransform.position;
                info.PosX = kartPos.x;
                info.PosY = kartPos.y;
                info.PosZ = kartPos.z;
                Vector3 kartRotate = kartTransform.rotation.eulerAngles;
                info.RotateX = kartRotate.x;
                info.RotateY = kartRotate.y;
                info.RotateZ = kartRotate.z;
                return info;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据kartInfo设置当前环境中其他Kart状态
        /// </summary>
        /// <param name="kartInfoList"></param>
        public void SetKartInfo(List<KartInfo> kartInfoList)
        {
            // 匹配信息与kart对象列表个数
            if (kartInfoList.Count > kartList.Count)
            {
                int addCount = kartInfoList.Count - kartList.Count;
                for (int i = 0; i < addCount; i++)
                {
                    // 实例化生成一个kart对象，放入kart列表中
                    kartList.Add(
                        Instantiate(kartPrefab.gameObject)
                                .GetComponent<MonoBase>()
                        );
                }
            }
            else if (kartInfoList.Count < kartList.Count)
            {
                for (int i = kartInfoList.Count; i < kartList.Count; i++)
                {
                    // kart列表中关闭多余的对象（这里不直接Destroy，做对象缓冲池）
                    kartList[i].gameObject.SetActive(false);
                }
            }
            // 开始设置kart
            for (int i = 0; i < kartInfoList.Count; i++)
            {
                kartList[i].id = kartInfoList[i].ID;
                kartList[i].sId = kartInfoList[i].SId;
                // 设置位置
                kartList[i].transform.position =
                    kartInfoList[i].GetPos();
                // 设置旋转
                kartList[i].transform.rotation =
                    Quaternion.Euler(kartInfoList[i].GetRotate());
            }
        }
    }

    /// <summary>
    /// Kart信息
    /// </summary>
    public class KartInfo
    {
        private int id;

        public int ID
        {
            get => id;
            set => id = value;
        }

        public int SId
        {
            get => sId;
            set => sId = value;
        }

        public float PosX
        {
            get => posX;
            set => posX = value;
        }

        public float PosY
        {
            get => posY;
            set => posY = value;
        }

        public float PosZ
        {
            get => posZ;
            set => posZ = value;
        }

        public float RotateX
        {
            get => rotateX;
            set => rotateX = value;
        }

        public float RotateY
        {
            get => rotateY;
            set => rotateY = value;
        }

        public float RotateZ
        {
            get => rotateZ;
            set => rotateZ = value;
        }

        private int sId;
        private float posX;
        private float posY;
        private float posZ;
        private float rotateX;
        private float rotateY;
        private float rotateZ;

        public Vector3 GetPos()
        {
            return new Vector3(posX, posY, posZ);
        }

        public Vector3 GetRotate()
        {
            return new Vector3(rotateX, rotateY, rotateZ);
        }
    }
}