using System.Collections.Generic;
using QFramework.Player.NewPlayerAutoGrab._Data;
using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab._Model
{
    public class NewAutoGrab_Model:AbstractModel
    {
        private AutoGarb_Data _autoGrabData;
        private int _segments;
        private float _startAngle;
        private float _endAngle;
        private float _radius;
        private float _sphereRadius ;
        private bool _mousehaveCircle;
        public List<GameObject> TriigerObjectList=new List<GameObject>();
        public List<GameObject> FollowObjectList=new List<GameObject>();
        public bool IfShooting;
        public bool IfMoveing;
        private float _distance;

        public float Distance
        {
            get
            {
                if (_distance != _autoGrabData._distance) _distance = _autoGrabData._distance;
                return _distance;
            }
            set => _distance = value;
        }
        public bool MousehaveCircle
        {
            get=> _mousehaveCircle;
            set=> _mousehaveCircle=value;
        }

        public float SphereRadius
        {
            get
            {
                if (_sphereRadius != _autoGrabData._sphereRadius) _sphereRadius = _autoGrabData._sphereRadius;
                return _sphereRadius;
            }
            set => _sphereRadius = value;
        }
        
        public float Radius
        {
            get
            {
                if (_radius != _autoGrabData._radius) _radius = _autoGrabData._radius;
                return _radius;
            }
            set => _radius = value;
        }
        
        public int Segments
        {
            get
            {
                if (_segments != _autoGrabData._segments) _segments = _autoGrabData._segments;
                return _segments;
            }
            set => _segments = value;
        }
        public float StartAngle
        {
            get
            {
                if (_startAngle != _autoGrabData._startAngle) _startAngle = _autoGrabData._startAngle;
                return _startAngle;
            }
            set => _startAngle = value;
        }
        public float EndAngle
        {
            get
            {
                if (_endAngle != _autoGrabData._endAngle) _endAngle = _autoGrabData._endAngle;
                return _endAngle;
            }
            set => _endAngle = value;
        }

        protected override void OnInit()
        {
            _autoGrabData = Resources.Load<AutoGarb_Data>("Player_Data/AutoGrab_Data");
        }
    }
}