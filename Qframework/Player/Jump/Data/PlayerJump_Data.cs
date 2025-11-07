using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Jump", fileName = "Jump_Player_Data")]
public class PlayerJump_Data : ScriptableObject
{
    [Header("正常跳跃的参数")]
    [Tooltip("跳跃高度")]
    public float _jumpForce;
    [Tooltip("松开跳跃键时的取消继续跳跃力度")]
    public float _jumpCutMultplier;
    [Tooltip("下落时的重力倍数")]
    public float _fallGrivityMultplier;
    [Tooltip("跳跃缓冲时间")]
    [Range(0, 10)]
    public float _jumpBuffetTime;
    [Tooltip("土狼跳跃时间")]
    [Range(0, 10)]
    public float _jumpCoyoteTime;
    [Tooltip("最大下落速度")]
    [Range(0, 400)]
    public float _maxFallSpeed;

    [Header("跳跃顶点时人物的参数")]
    [Range(0, 20)]
    [Tooltip("跳跃顶点的速度判定")]
    public float _timeThreshold;
    [Range(0, 1)]
    [Tooltip("跳跃顶点时的重力乘数")]
    public float _grivityMult;
    [Range(1, 10)]
    [Tooltip("跳跃顶点时加速度/减速度乘数")]
    public float _accelerationMult;
    [Range(1, 10)]
    [Tooltip("跳跃顶点时的最大速度乘数")]
    public float _maxSpeedMult;

}
