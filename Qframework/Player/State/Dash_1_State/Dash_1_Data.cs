using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Dash_1", fileName = "Dash_1_State")]
public class Dash_1_Data : ScriptableObject
{
    [Tooltip("发射的克隆球体预制体")]
    public GameObject _spherePrefab;
    [Tooltip("球体消失的时间")]
    public float _saveTime = 1.0f;
    [Tooltip("球体的发射速度")]
    public float _circleHitForce = 3f;
    [Tooltip("冲刺力度")]
    public float _dashForce;
    [Tooltip("发射球体生成位置在边缘上的额外距离")]
    public float _distance;
    
    
    [Space(10)]
    [Header("暂时没用的数据")]
    [Tooltip("再次接触的冷却")]
    public float _time;

    [Tooltip("冲刺距离")]
    public float _dashDistance;
    [Tooltip("冲刺速度倍数")]
    public float _moveSpeed;
    [Tooltip("冲刺速度曲线")]
    public AnimationCurve _speedCurve;
    [Tooltip("是否显示冲刺总时长")]
    public bool _canSeeTime;
    [Tooltip("子弹时间的持续时间")]
    public float _time_0;
    [Tooltip("子弹时间的缩放")]
    public float _timeScale_0;
}
