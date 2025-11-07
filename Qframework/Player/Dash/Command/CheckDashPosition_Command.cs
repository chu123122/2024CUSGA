using C_.Qframework.Player.Dash._Model;
using QFramework;
using UnityEngine;

namespace C_.Qframework.Player.Dash.Command
{
    public class CheckDashPosition_Command : AbstractCommand,ICanRegisterEvent
    {
        private PlayerDash_Model _playerDash_Model;
        protected override void OnExecute()
        {
            _playerDash_Model = this.GetModel<PlayerDash_Model>();
            Transform transform = PlayerSingleton.Instance.transform1;
            int grappableLayer = LayerMask.NameToLayer("Player");
            int layerMask = (1 << grappableLayer);
            
            bool isObstacleDetected = Physics2D.OverlapCircle
                (transform.position + _playerDash_Model.DashDirection * _playerDash_Model.DashDistance, 0.3f,~layerMask);
            Collider2D hit= Physics2D.OverlapCircle
                (transform.position + _playerDash_Model.DashDirection * _playerDash_Model.DashDistance, 0.3f,~layerMask);
            if (isObstacleDetected)
            {
               // Debug.LogWarning("��⵽�ϰ���:"+hit.gameObject.name);
                _playerDash_Model.DashPosition =  _playerDash_Model.HitPosition;
                _playerDash_Model.HaveDashDirection = true;
            }
            else 
            {
               // Debug.LogWarning("δ��⵽�ϰ���");
                _playerDash_Model.DashPosition = transform.position + _playerDash_Model.DashDirection * _playerDash_Model.DashDistance;
                _playerDash_Model.HaveDashDirection = true;
            }
        }
    }
}
