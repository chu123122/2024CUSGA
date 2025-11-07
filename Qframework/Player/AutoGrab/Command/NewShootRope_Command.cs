using QFramework.Player.NewPlayerAutoGrab._Model;
using QFramework.Player.NewPlayerAutoGrab.Event;
using QFramework.Player.NewPlayerGrab._Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewShootRope_Command:AbstractCommand
    {
        private NewAutoGrab_Model  _newAutoGrabModel;
        private NewGrab_Model _grabModel; 
        private readonly GameObject _followCircle;
        private Transform _transform;
        private readonly Transform _player;
        private float _mount;
        private bool _enabled=true;
        public NewShootRope_Command(GameObject followCircle,Transform player)
        {
            _followCircle = followCircle;
            _player = player;
        }
        protected override void OnExecute()
        {
            _newAutoGrabModel=this.GetModel<NewAutoGrab_Model>();
            _grabModel=this.GetModel<NewGrab_Model>();
            _transform = _followCircle.GetComponent<Transform>();

            if (_newAutoGrabModel.IfShooting)
            {
                if(_mount<=1)
                    _mount += _grabModel.ContinueSpeed*(Time.deltaTime);
                Vector3 currentPosition = Vector3.Lerp(_player.position, _transform.position, _mount);
                PlayerSingleton.Instance.lineRenderer.SetPosition(1, currentPosition);
                PlayerSingleton.Instance.lineRenderer.SetPosition(0, _player.position);
                if (currentPosition == _transform.position&&_enabled)
                {
                    _enabled = false;
                    this.SendEvent<NewMoveStart_Event>();
                }
            }
          
        }
    }
}