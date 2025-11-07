using QFramework.Player.NewPlayerAutoGrab._Model;
using QFramework.Player.NewPlayerGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewPlayerFollowMove_Command:AbstractCommand
    {
        private NewAutoGrab_Model   _newAutoAutoGrabModel;
        private NewGrab_Model  _newGrab_Model;
        private readonly Transform _player;
        private readonly GameObject _followCircle;
        private Transform _transform;

        public NewPlayerFollowMove_Command(GameObject followCircle,Transform player)
        {
            _followCircle=followCircle;
            _player = player;
        }
        protected override void OnExecute()
        {
            _newAutoAutoGrabModel=this.GetModel<NewAutoGrab_Model>();
            _newGrab_Model=this.GetModel<NewGrab_Model>();
            _transform=_followCircle.GetComponent<Transform>();
            if (_newAutoAutoGrabModel.IfMoveing)
            {
                _player.position = Vector3.MoveTowards
                    (_player.position, _transform.position, _newGrab_Model.PlayerSpeed*Time.deltaTime);

                if (Vector2.Distance(_player.position, _transform.position) < 0.1f)
                {
                    _newAutoAutoGrabModel.IfMoveing = false;
                    _newAutoAutoGrabModel.IfShooting = false;
                   PlayerSingleton.Instance.lineRenderer.enabled=false;
                }
            }
        }
    }
}