using QFramework.Player.NewPlayerGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerGrab.Command
{
    public class MoveFollowRope_Command:AbstractCommand
    {
        private NewGrab_Model _model;
        private Transform _transform;
        private LineRenderer _lineRenderer;
        protected override void OnExecute()
        {
            _model=this.GetModel<NewGrab_Model>();
            _transform = PlayerSingleton.Instance.transform1;
            _lineRenderer = PlayerSingleton.Instance.lineRenderer;
            if (_model.IfMoveing)
            {
                Vector3 nextPosition = Vector3.MoveTowards(_transform.position, _model.ShootPosition
                    , Time.deltaTime * _model.PlayerSpeed);
                
                _transform.position = nextPosition;
                _lineRenderer.SetPosition(1,PlayerSingleton.Instance.character.position);
                float distance = Vector3.Distance(_transform.position, _model.ShootPosition);
                if (distance < 1f)
                {
                    PlayerSingleton.Instance.lineRenderer.enabled = false;
                    _model.IfMoveing = false;
                }
            }
        }
    }
}