using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Objects/Data/DashSquare", fileName = "DashSquare")]
public class DashSquare_Data : ScriptableObject
{
    [Tooltip("与玩家接触后多久开始移动的时间")]
    public float waitTime;
    [Tooltip("目标位置和原位置x轴的距离")]
    public float targetPosition_x;
    [Tooltip("目标位置和原位置y轴的距离")]
    public float targetPosition_y;
    [Tooltip("运动速度的倍率")]
    public float speed;
    [Tooltip("运动的速度轨迹")]
    public AnimationCurve speedCurve;
    [Tooltip("是否接触到玩家")]
    public bool touchPlayer = false;
}
