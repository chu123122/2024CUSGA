using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Dash_0", fileName = "Dash_0_State")]
public class Dash_0_Data : ScriptableObject
{
    [Tooltip("冲刺距离")]
    public float _dashDistance;
    [Tooltip("冲刺速度倍数")]
    public float _moveSpeed;
    [Tooltip("冲刺速度曲线")]
    public AnimationCurve _speedCurve;
    [Tooltip("是否显示冲刺总时长")]
    public bool _canSeeTime;
    [Tooltip("停顿时间过多久后可以冲刺")]
    public float _waitTime;
    [Tooltip("冲刺时间控制器")]
    public float _dashTimeController;
}
