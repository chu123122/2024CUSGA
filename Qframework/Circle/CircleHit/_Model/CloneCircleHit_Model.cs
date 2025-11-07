using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class CloneCircleHit_Model : AbstractModel
{
    private Circle_Data _circleData;
    private float _force;
    private float _hitCircleForce;
    private float _hitPlayerForce;
    private float _firection;
    private float _stopSpeed;
    private float _stopTime;
    private float _hitPlayerForce_Move;

    public float HitPlayerForce_Move
    {
        get
        {
           if(_hitPlayerForce_Move!=_circleData._hitPlayerForce_Move)_hitPlayerForce_Move=_circleData._hitPlayerForce_Move;
           return _hitPlayerForce_Move;
        }
        set =>_hitPlayerForce_Move = value;
    }

    public float Force
    {
        get
        {
            if (_force != _circleData._force) _force = _circleData._force;
            return _force;
        }
        set => _force = value;
    }
    public float HitCircleForce
    {
        get
        {
            if (_hitCircleForce != _circleData._hitCircleForce) _hitCircleForce = _circleData._hitCircleForce;
            return _hitCircleForce;
        }
        set => _hitCircleForce = value;
    }
    public float HitPlayerForce
    {
        get
        {
            if (_hitPlayerForce != _circleData._hitPlayerForce) _hitPlayerForce = _circleData._hitPlayerForce;
            return _hitPlayerForce;
        }
        set => _hitPlayerForce = value;
    }

    public float Firection
    {
        get
        {
            if (_firection != _circleData._firection) _firection = _circleData._firection;
            return _firection;
        }
        set => _firection = value;
    }
    public float StopSpeed
    {
        get
        {
            if (_stopSpeed != _circleData._stopSpeed) _stopSpeed = _circleData._stopSpeed;
            return _stopSpeed;
        }
        set => _force = value;
    }
    public float StopTime
    {
        get
        {
            if (_stopTime != _circleData._stopTime) _stopTime = _circleData._stopTime;
            return _stopTime;
        }
        set => _stopTime = value;
    }
    protected override void OnInit()
    {
        _circleData = Resources.Load<Circle_Data>("Objects_Data/Circle");
    }
}
