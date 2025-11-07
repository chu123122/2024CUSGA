using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Move", fileName = "Move_Player_Data")]
public class PlayerMove_Data : ScriptableObject
{
    [Tooltip("最大速度")]
    public float _moveSpeed;
    [Tooltip("加速度")]
    public float _acceleration;
    [Tooltip("减速度")]
    public float _decceleration;
    [Tooltip("速度变化程度")]
    public float _velPower;
    [Space]
    [Tooltip("减速的摩擦力")]
    public float _frictionAmount;
}
