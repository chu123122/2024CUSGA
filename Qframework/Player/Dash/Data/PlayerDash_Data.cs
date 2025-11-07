using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Dash", fileName = "Dash_Player_Data")]
public class PlayerDash_Data : ScriptableObject
{
    [Tooltip("冲刺距离")]
    public float _dashDistance;
    [Tooltip("冲刺速度倍数")]
    public float _moveSpeed;
    [Tooltip("冲刺速度曲线")]
    public AnimationCurve _speedCurve;
    [Tooltip("是否显示冲刺总时长")]
    public bool _canSeeTime;
    [Tooltip("子弹时间的持续时间")]
    public float _time;
    [Tooltip("子弹时间的缩放")]
    public float _timeScale;
    [Tooltip("顿帧时间")]
    public float _waitTime;
    [Tooltip("残影数量")]
    public int _mount;
    [Tooltip("残影间隔时间")]
    public float _intervalTime;
}
