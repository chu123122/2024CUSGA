using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class Dash_0_Model : AbstractModel
{
    private Dash_0_Data _dash_0_Data;

   
    private float _moveSpeed;
    private float _timer;
    private float _waitTime;
    private float _waitTimer;
    private bool _canSeeTime;
    private AnimationCurve _speedCurve;
    private int _side;
  
    private float _dashDistance;
    private Vector3 _dashPosiotn;
    private bool _inDashState;
    private int _dashMount;
    public Vector3 DashPosiotn { get => _dashPosiotn; set => _dashPosiotn = value; }
    private float _dashTimeController;
    private bool _isDashing;
    private bool _isWaiting;
    private bool _inState;
    public bool InState { get => _inState;set => _inState = value;
    }
    public bool IsDashing { get => _isDashing; set => _isDashing = value; }
    public bool IsWaiting { get => _isWaiting; set => _isWaiting = value; }
    public float WaitTimer { get => _waitTimer; set => _waitTimer = value; }

    public float DashTimeController
    {
        get
        {
            if(_dashTimeController != _dash_0_Data._dashTimeController)_dashTimeController= _dash_0_Data._dashTimeController;
            return _dashTimeController;
        }
        set => _dashTimeController = value;
    }
    public float WaitTime
    {
        get
        {
            if (_waitTime != _dash_0_Data._waitTime) _waitTime = _dash_0_Data._waitTime;
            return _waitTime;
        }
        set => _waitTime = value;
    }
    public bool CanSeeTime
    {
        get
        {
            if (_canSeeTime != _dash_0_Data._canSeeTime) _canSeeTime = _dash_0_Data._canSeeTime;
            return _canSeeTime;
        }
        set => _canSeeTime = value;
    }
    public AnimationCurve SpeedCurve
    {
        get
        {
            if (_speedCurve != _dash_0_Data._speedCurve) _speedCurve = _dash_0_Data._speedCurve;
            return _speedCurve;
        }
        set => _speedCurve = value;
    }
    public float DashDistance 
    { 
        get
        {
            if (_dashDistance != _dash_0_Data._dashDistance) _dashDistance = _dash_0_Data._dashDistance;
            return _dashDistance;
        }
        set => _dashDistance = value;
    }
    public float MoveSpeed
    {
        get
        {
            if (_moveSpeed != _dash_0_Data._moveSpeed) _moveSpeed = _dash_0_Data._moveSpeed;
            return _moveSpeed;
        }
        set => _moveSpeed = value;
    }
   
    public bool InDashState{ get => _inDashState; set => _inDashState = value; }
    public int Side { get => _side; set => _side = value; }
    public int DashMount { get => _dashMount; set => _dashMount = value; }

    protected override void OnInit()
    {
        _dash_0_Data = Resources.Load<Dash_0_Data>("PlayerState_Data/Dash_0_State");
    }

}
