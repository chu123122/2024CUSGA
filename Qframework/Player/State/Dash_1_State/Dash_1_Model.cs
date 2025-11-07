using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class Dash_1_Model : AbstractModel
{
    private Dash_1_Data _dash_1_Data;

    private GameObject _spherePrefab;
    private float _saveTime;
    private float _dashForce;
    private float _distance;
    private float _time;
    private float _circleHitForce;

    private float _dashDistance;
    private float _moveSpeed;
    private AnimationCurve _speedCurve;
    private bool _canSeeTime;
    private float _time_0;
    private float _timeScale_0;
    private float _timeCounter_0;
    private bool _inState;
    public bool InState { get => _inState; set => _inState = value; }
    public float TimeScale_0
    {
        get
        {
            if (_timeScale_0 != _dash_1_Data._timeScale_0) _timeScale_0 = _dash_1_Data._timeScale_0;
            return _timeScale_0;
        }
        set => _timeScale_0 = value;
    }
    public float Time_0
    {
        get
        {
            if (_time_0 != _dash_1_Data._time_0) _time_0 = _dash_1_Data._time_0;
            return _time_0;
        }
        set => _time_0 = value;
    }
    public float MoveSpeed
    {
        get
        {
            if (_moveSpeed != _dash_1_Data._moveSpeed) _moveSpeed = _dash_1_Data._moveSpeed;
            return _moveSpeed;
        }
        set => _moveSpeed = value;
    }
    public float DashDistance
    {
        get
        {
            if (_dashDistance != _dash_1_Data._dashDistance) _dashDistance = _dash_1_Data._dashDistance;
            return _dashDistance;
        }
        set => _dashDistance = value;
    }
    public bool CanSeeTime
    {
        get
        {
            if (_canSeeTime != _dash_1_Data._canSeeTime) _canSeeTime = _dash_1_Data._canSeeTime;
            return _canSeeTime;
        }
        set => _canSeeTime = value;
    }
    public AnimationCurve SpeedCurve
    {
        get
        {
            if (_speedCurve != _dash_1_Data._speedCurve) _speedCurve = _dash_1_Data._speedCurve;
            return _speedCurve;
        }
        set => _speedCurve = value;
    }
    public GameObject SpherePrefab
    {
        get
        {
            if (_spherePrefab != _dash_1_Data._spherePrefab) _spherePrefab = _dash_1_Data._spherePrefab;
            return _spherePrefab;
        }
        set => _spherePrefab = value;
    }
    public float SaveTime
    {
        get
        {
            if (_saveTime != _dash_1_Data._saveTime) _saveTime = _dash_1_Data._saveTime;
            return _saveTime;
        }
        set => _saveTime = value;
    }
    public float DashForce
    {
        get
        {
            if (_dashForce != _dash_1_Data._dashForce) _dashForce = _dash_1_Data._dashForce;
            return _dashForce;
        }
        set => _dashForce = value;
    }
    public float Distance
    {
        get
        {
            if (_distance != _dash_1_Data._distance) _distance = _dash_1_Data._distance;
            return _distance;
        }
        set => _distance = value;
    }
    public float CircleHitForce
    {
        get
        {
            if (_circleHitForce != _dash_1_Data._circleHitForce) _circleHitForce = _dash_1_Data._circleHitForce;
            return _circleHitForce;
        }
        set => _circleHitForce = value;
    }
    public float Time
    {
        get
        {
            if (_time != _dash_1_Data._time) _time = _dash_1_Data._time;
            return _time;
        }
        set => _time = value;
    }

    public float TimeCounter_0 { get => _timeCounter_0; set => _timeCounter_0 = value; }

    protected override void OnInit()
    {
        _dash_1_Data = Resources.Load<Dash_1_Data>("PlayerState_Data/Dash_1_State");
    }

}
