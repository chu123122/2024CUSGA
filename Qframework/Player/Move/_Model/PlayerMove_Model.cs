using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class PlayerMove_Model : AbstractModel
{
    private PlayerMove_Data _moveData;
    private float _moveSpeed;
    private float _acceleration;
    private float _decceleration;
    private float _velPower;
    private float _frictionAmount;
    public float MoveSpeed
    {
        get
        {
            if (_moveSpeed != _moveData._moveSpeed) _moveSpeed = _moveData._moveSpeed;
            return _moveSpeed;
        }
        set => _moveSpeed = value;
    }
    public float Acceleration
    {
        get
        {
            if (_acceleration != _moveData._acceleration) _acceleration = _moveData._acceleration;
            return _acceleration;
        }
        set => _acceleration = value;
    }
    public float Decceleration
    {
        get
        {
            if (_decceleration != _moveData._decceleration) _decceleration = _moveData._decceleration;
            return _decceleration;
        }
        set => _decceleration = value;
    }
    public float VelPower
    {
        get
        {
            if (_velPower != _moveData._velPower) _velPower = _moveData._velPower;
            return _velPower;
        }
        set => _velPower = value;

    }
    public float FrictionAmount
    {
        get
        {
            if (_frictionAmount != _moveData._frictionAmount) _frictionAmount = _moveData._frictionAmount;
            return _frictionAmount;
        }
        set => _frictionAmount = value;
    }

    protected override void OnInit()
    {
        _moveData = Resources.Load<PlayerMove_Data>("Player_Data/Move_Data");
    }
}
