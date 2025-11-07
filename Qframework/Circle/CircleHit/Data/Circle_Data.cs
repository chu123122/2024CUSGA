
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Circle/CloneCircleHit_Data", fileName = "CloneCircleHit_Data")]
public class Circle_Data : ScriptableObject
{
    [Tooltip("弹珠撞到墙壁类反弹的力度")]
    public float _force;
    [Tooltip("运动弹珠弹弹珠的力度")]
    public float _hitCircleForce;
    [Tooltip("静止弹珠弹人物的力度")]
    public float _hitPlayerForce;
    [Tooltip("运动弹珠弹人物的力度")]
    public float _hitPlayerForce_Move;
    [Tooltip("摩擦力")]
    public float _firection;
    [Tooltip("判定球是静止的速度界限")]
    public float _stopSpeed;
    [Tooltip("球低于静止速度后消失的时间")]
    public float _stopTime;
}
