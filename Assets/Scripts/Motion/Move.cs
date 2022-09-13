using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmalBox.Motion
{
    public class Move : MonoBehaviour
    {
        [Header("前后运动给的力")] public float forceSize = 3;
        [Header("前后左右旋转给的力")] public float rotateAngle = 1;
        [Header("最大速度")] public float maxVelocity = 4;
        [Header("最大旋转力")] public float maxTorque = 2;

        private Rigidbody rig;

        void Start()
        {
            // 设置FixedUpdate固定更新时间片时间
            Time.fixedDeltaTime = 0.02f;
            // 获取缓存rigidbody组件
            if (rig == null)
            {
                rig = GetComponent<Rigidbody>();
            }
        }

        private void FixedUpdate()
        {
            // 按下向前 W 或 ↑
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // 最大速度限制
                if (rig.velocity.magnitude <= maxVelocity)
                {
                    // 力的方向 * 力的大小
                    var force = transform.forward.normalized * forceSize;
                    Debug.Log($"向前施加力：{force}, 速度：{rig.velocity}");
                    // 添加先前力
                    rig.AddForce(force);
                }
            }

            // 按下向后 S 或 ↓
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                // 最大速度限制
                if (rig.velocity.magnitude <= maxVelocity)
                {
                    // 力的方向 * 力的大小
                    var force = -transform.forward.normalized * forceSize;
                    Debug.Log($"向后施加力：{force}, 速度：{rig.velocity},");
                    // 添加向后力
                    rig.AddForce(force);
                }
            }

            // 按下向左 A 或 ←
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // 最大旋转限制
                if (rig.angularVelocity.magnitude <= maxTorque)
                {
                    Debug.Log($"向左转向：{Vector3.one * rotateAngle}");
                    // 添加旋转力（扭力）
                    rig.AddRelativeTorque(-Vector3.one * rotateAngle);
                }
            }

            // 按下向右 D 或 →
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // 最大旋转限制
                if (rig.angularVelocity.magnitude <= maxTorque)
                {
                    Debug.Log($"向右转向：{-Vector3.one * rotateAngle}");
                    // 添加旋转力（扭力）
                    rig.AddRelativeTorque(Vector3.one * rotateAngle);
                }
            }
        }
    }
}