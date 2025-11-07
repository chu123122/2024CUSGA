using QFramework;
using UnityEngine;

namespace C_.Qframework.Player.Dash._Model
{
    public class PlayerDash_Model : AbstractModel
    {
        private PlayerDash_Data _dashData;

        private float _dashDistance;
        private float _moveSpeed;
        private float _time;
        private float _timeScale;
        private AnimationCurve _speedCurve;
        private float _timeControl;

        private Vector3 _dashPosition;
        private Vector3 _dashDirection;
        private Vector3 _hitPosition;
        private bool isDashing;
        private bool haveDashDirection;
        private bool _canSeeTime;
        private int _mount;
        public float _intervalTime;
        private float _waitTime;

        public float WaitTime
        {
            get
            {
                if (_waitTime != _dashData._waitTime) _waitTime = _dashData._waitTime;
                return _waitTime;
            }
            set => _waitTime = value;
        }

        public float IntervalTime
        {
            get
            {
                if (_intervalTime != _dashData._intervalTime) _intervalTime = _dashData._intervalTime;
                return _intervalTime;
            }
            set => _intervalTime = value;
        }
        public int Mount
        {
            get
            {
                if (_mount != _dashData._mount) _mount = _dashData._mount;
                return _mount;
            }
            set => _mount = value;
        }
        public bool CanSeeTime
        {
            get
            {
                if (_canSeeTime != _dashData._canSeeTime) _canSeeTime = _dashData._canSeeTime;
                return _canSeeTime;
            }
            set => _canSeeTime = value;
        }
        public AnimationCurve SpeedCurve
        {
            get
            {
                if (_speedCurve != _dashData._speedCurve) _speedCurve = _dashData._speedCurve;
                return _speedCurve;
            }
            set => _speedCurve = value;
        }
        public float DashDistance
        {
            get
            {
                if (_dashDistance != _dashData._dashDistance) _dashDistance = _dashData._dashDistance;
                return _dashDistance;
            }
            set => _dashDistance = value;
        }
        public float MoveSpeed
        {
            get
            {
                if (_moveSpeed != _dashData._moveSpeed) _moveSpeed = _dashData._moveSpeed;
                return _moveSpeed;
            }
            set => _moveSpeed = value;
        }
        public float Time
        {
            get
            {
                if (_time != _dashData._time) _time = _dashData._time;
                return _time;
            }
            set => _time = value;
        }
        public float TimeScale
        {
            get
            {
                if (_timeScale != _dashData._timeScale) _timeScale = _dashData._timeScale;
                return _timeScale;
            }
            set => _timeScale = value;
        }

        public Vector3 DashPosition { get => _dashPosition; set => _dashPosition = value; }
        public Vector3 DashDirection { get => _dashDirection; set => _dashDirection = value; }
        public Vector3 HitPosition { get => _hitPosition; set => _hitPosition = value; }
        public bool IsDashing { get => isDashing; set => isDashing = value; }
        public bool HaveDashDirection { get => haveDashDirection; set => haveDashDirection = value; }
        public float TimeControl { get => _timeControl; set => _timeControl = value; }

        protected override void OnInit()
        {
            _dashData =  Resources.Load<PlayerDash_Data>("Player_Data/Dash_Data");
        }


    }
}
