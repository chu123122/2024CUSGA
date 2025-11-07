using QFramework.Player.NewPlayerGrab._Model;
using QFramework.Player.NewPlayerGrab.Event;
using UnityEngine;

namespace QFramework.Player.NewPlayerGrab.Command
{
     class RayHitCheck_Command : AbstractCommand
     {
         private NewGrab_Model _newGrabModel;
         private LineRenderer _lineRenderer;    
         private Transform _transform;
         protected override void OnExecute()
         {
             _newGrabModel=this.GetModel<NewGrab_Model>();
             _transform =PlayerSingleton.Instance.character;
             _lineRenderer= PlayerSingleton.Instance.lineRenderer;
             int wallLayer = LayerMask.NameToLayer("Wall");
             int gronudLayer = LayerMask.NameToLayer("Ground");
             int layerMask = (1 << wallLayer)|(1<<gronudLayer);
             RaycastHit2D hit = Physics2D.Raycast(_transform.position, _newGrabModel.MouseDirection, Mathf.Infinity, layerMask);
             if (hit.collider != null)
             {
                 if (Vector2.Distance(_transform.position, hit.point) <=_newGrabModel.MaxDistance)
                 {
                     Vector3 targetPosition = hit.point;
                     _newGrabModel.ShootPosition = targetPosition;

                     _lineRenderer.SetPosition(0, _transform.position);
                     _lineRenderer.SetPosition(1, _transform.position);
                     _lineRenderer.enabled = true;
                     this.SendEvent<ShootStart_Event>();
                 }
             }
             else
             {
                 Debug.Log("null");
             }
         }
     }
}