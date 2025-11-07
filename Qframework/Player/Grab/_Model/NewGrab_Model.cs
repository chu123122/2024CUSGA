using QFramework.Player.NewPlayerGrab._Data;
using UnityEngine;
namespace QFramework.Player.NewPlayerGrab._Model
{
    public class NewGrab_Model:AbstractModel
    {
        private NewGrab_Data _data;
        
        private float _continueSpeed;

        public float ContinueSpeed
        {
            get
            {
               if(_continueSpeed!=_data._continueSpeed)_continueSpeed=_data._continueSpeed;
               return _continueSpeed;
            }
            set =>_continueSpeed=value;
        }
        private float _playerSpeed;
        public float PlayerSpeed
        {
            get
            {
                if(_playerSpeed!=_data._playerSpeed)_playerSpeed=_data._playerSpeed;
                return _playerSpeed;
            }
            set =>_playerSpeed=value;
        }
        private float _maxDistance;
        
        public float MaxDistance
        {
            get
            {
                if(_maxDistance!=_data._maxDistance)_maxDistance=_data._maxDistance;
                return _maxDistance;
            }
            set =>_maxDistance=value;
        }

        private float _grabTimeController;

        public float GrabTimeController
        {
            get
            {
                if(_grabTimeController!=_data._grabTimeController)_grabTimeController=_data._grabTimeController;
                return _grabTimeController;
            }
            set =>_grabTimeController=value;
        }
        private bool _ifShooting;
        public bool IfShooting{get=>_ifShooting;set=>_ifShooting=value;}
        private bool _ifMoveing;
        public bool IfMoveing{get=>_ifMoveing;set=>_ifMoveing=value;}
        private Vector3 _mouseDirection;
        public Vector3 MouseDirection{get=>_mouseDirection;set=>_mouseDirection=value;}
        private Vector3 _shootPosition;
        public Vector3 ShootPosition{get=>_shootPosition;set=>_shootPosition=value;}
        protected override void OnInit()
        {
            _data = Resources.Load<NewGrab_Data>("Player_Data/Grab_Data");
        }
    }
}