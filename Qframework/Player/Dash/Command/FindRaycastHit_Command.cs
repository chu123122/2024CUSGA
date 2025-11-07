using C_.Qframework.Player.Dash._Model;
using QFramework;
using UnityEngine;

namespace C_.Qframework.Player.Dash.Command
{
    public class FindRaycastHit_Command : AbstractCommand
    {
        private PlayerDash_Model _playerDash_Model;

        protected override void OnExecute()
        {
            _playerDash_Model = this.GetModel<PlayerDash_Model>();
            Transform transform =  PlayerSingleton.Instance.character;
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
            int grappableLayer = LayerMask.NameToLayer("Player");

            int layerMask = (1 << grappableLayer);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                (targetPosition - transform.position).normalized, _playerDash_Model.DashDistance,~layerMask);
        
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = (targetPosition- transform.position).normalized;
            float rayDistance = _playerDash_Model.DashDistance;

            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
            if (hit.collider != null) 
            {
                GameObject.Find("Music").transform.position = hit.point;
                if (Input.GetMouseButtonDown(1))
                {
                    _playerDash_Model.HitPosition = hit.point;
                }
            }
           
        }
    }
}
