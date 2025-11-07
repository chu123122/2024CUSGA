using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.LowLevel;
public class PlayerJump_Model : AbstractModel
{
    private PlayerJump_Data _jumpData;
    #region 私有变量
    private float _jumpForce;
    private float _jumpCutMultplier;

    private float _jumpBuffetTime;
    private float _jumpCoyoteTime;

    private float _fallGrivityMultplier;
    private float _maxFallSpeed;

    private float _timeThreshold;
    private float _grivityMult;
    private float _accelerationMult;
    private float _maxSpeedMult;

    private bool _isTimeThreshold;

    private float _jumpCount;
    #endregion

    #region 公共变量
    public float JumpForce
    {
        get
        {
            if (_jumpForce != _jumpData._jumpForce) _jumpForce = _jumpData._jumpForce;
            return _jumpForce;
        }
        set => _jumpForce = value;
    }
    public float JumpCutMultplier
    {
        get
        {
            if (_jumpCutMultplier != _jumpData._jumpForce) _jumpCutMultplier = _jumpData._jumpCutMultplier;
            return _jumpCutMultplier;
        }
        set => _jumpCutMultplier = value;
    }
    public float JumpBuffetTime
    {
        get
        {
            if (_jumpBuffetTime != _jumpData._jumpBuffetTime) _jumpBuffetTime = _jumpData._jumpBuffetTime;
            return _jumpBuffetTime;
        }
        set => _jumpBuffetTime = value;
    }
    public float JumpCoyoteTime
    {
        get
        {
            if (_jumpCoyoteTime != _jumpData._jumpCoyoteTime) _jumpCoyoteTime = _jumpData._jumpCoyoteTime;
            return _jumpCoyoteTime;
        }
        set => _jumpCoyoteTime = value;
    }
    public float FallGrivityMultplier
    {
        get
        {
            if (_fallGrivityMultplier != _jumpData._fallGrivityMultplier) _fallGrivityMultplier = _jumpData._fallGrivityMultplier;
            return _fallGrivityMultplier;
        }
        set => _fallGrivityMultplier = value;
    }
    public float MaxFallSpeed
    {
        get
        {
            if (_maxFallSpeed != _jumpData._maxFallSpeed) _maxFallSpeed = _jumpData._maxFallSpeed;
            return _maxFallSpeed;
        }
        set => _maxFallSpeed = value;
    }
    public float TimeThreshold
    {
        get
        {
            if (_timeThreshold != _jumpData._timeThreshold) _timeThreshold = _jumpData._timeThreshold;
            return _timeThreshold;
        }
        set => _timeThreshold = value;
    }
    public float GrivityMult
    {
        get
        {
            if (_grivityMult != _jumpData._grivityMult) _grivityMult = _jumpData._grivityMult;
            return _grivityMult;
        }
        set => _grivityMult = value;
    }
    public float AccelerationMult
    {
        get
        {
            if (_accelerationMult != _jumpData._accelerationMult) _accelerationMult = _jumpData._accelerationMult;
            return _accelerationMult;
        }
        set => _accelerationMult = value;
    }
    public float MaxSpeedMult
    {
        get
        {
            if (_maxSpeedMult != _jumpData._maxSpeedMult) _maxSpeedMult = _jumpData._maxSpeedMult;
            return _maxSpeedMult;
        }
        set => _maxSpeedMult = value;
    }
    #endregion


    protected override void OnInit()
    {
        _jumpData = Resources.Load<PlayerJump_Data>("Player_Data/Jump_Data");
    }

}
