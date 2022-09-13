using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmalBox.Terrain
{
    public class GroundGenObstacle : MonoBehaviour
    {
        [Header("是否启用生成")]
        public bool enableGen = true;
        [Header("障碍物预制体列表")]
        public List<GameObject> obstaclePrefabList;
        [Header("障碍物个数")]
        public int obstacleCount = 10;
        [Header("生成范围X值")]
        public Vector2 rangeX = new Vector2(-10, 10);
        [Header("生成范围Y值")]
        public Vector2 rangeY = new Vector2(-10, 10);
        
        private void Awake()
        {
            // 生成地形上的障碍物。
            if (enableGen)
            {
                for (int i = 0; i < obstacleCount; i++)
                {
                    // 随机选一个预制体
                    GameObject go = GetRandomObstacle(obstaclePrefabList);
                    // 随机选一个位置
                    Vector3 pos = GetRandomPos(rangeX, rangeY);
                    // 将获得的随机障碍物放到随机位置
                    go.transform.position = pos;
                }
            }
        }

        /// <summary>
        /// 随机获取一个障碍物对象
        /// </summary>
        /// <param name="obstacleList">障碍物预制体列表,会从中随机选择一个</param>
        /// <returns>根据传入障碍物列表随机选择返回，如果传入为null或数量为0则返回默认的cube</returns>
        private GameObject GetRandomObstacle(List<GameObject> obstacleList)
        {
            GameObject go = null;
            if (obstacleList != null && obstacleList.Count > 0)
            {
                // 实例化列表中随机选择的预制体
                go = Instantiate(obstacleList[UnityEngine.Random.Range(0, obstacleList.Count)], transform);
                go.transform.localScale =
                    new Vector3(
                        1 / transform.localScale.x,
                        1 / transform.localScale.y,
                        1 / transform.localScale.z);
                go.transform.localPosition = Vector3.zero;
            }
            else
            {
                // 生成默认cube
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // 设置父物体为本对象
                go.transform.SetParent(transform);
            }
            // 本地坐标归零
            go.transform.localPosition = Vector3.zero;
            return go;
        }

        /// <summary>
        /// 随机获取一个障碍物对象的坐标
        /// </summary>
        /// <param name="randomRangeX">随机坐标X的取值范围</param>
        /// <param name="randomRangeY">随机坐标Y的取值范围</param>
        /// <returns>根据传入范围返回随机坐标</returns>
        private Vector3 GetRandomPos(Vector2 randomRangeX, Vector2 randomRangeY)
        {
            return new Vector3(
                UnityEngine.Random.Range(randomRangeX.x, randomRangeX.y),
                0,
                UnityEngine.Random.Range(randomRangeY.x, randomRangeY.y)
                );
        }
    }
}