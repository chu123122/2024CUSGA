using QFramework.Player.NewPlayerGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerGrab.Command
{
   
    public class ShootRope_Command:AbstractCommand
    {
        private NewGrab_Model _model;
        private float _step=0;
        private Transform _transform;
        private LineRenderer _lineRenderer;
        private bool _iscan=true;
        protected override void OnExecute()
        {
            _model = this.GetModel<NewGrab_Model>();
            _transform=PlayerSingleton.Instance.character;
            _lineRenderer=PlayerSingleton.Instance.lineRenderer;
            if (_model.IfShooting)
            {
                if(_step<=1)
                    _step +=_model.ContinueSpeed * Time.deltaTime;
                Vector3 currentPosition = Vector3.Lerp(_transform.position, _model.ShootPosition, _step);
                _lineRenderer.SetPosition(0, currentPosition);
                _lineRenderer.SetPosition(1, _transform.position);

                if (currentPosition==_model.ShootPosition&&_iscan) // 钩爪到达目标位置
                {
                    _iscan = false;
                    _model.IfShooting = false; // 停止发射
                }
            }
        }
    }
}