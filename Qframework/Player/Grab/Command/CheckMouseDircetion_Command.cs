using QFramework.Player.NewPlayerGrab._Data;
using QFramework.Player.NewPlayerGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerGrab.Command
{
    public class CheckMouseDircetion_Command:AbstractCommand
    {
        private NewGrab_Model _model;
        protected override void OnExecute()
        {
            _model=this.GetModel<NewGrab_Model>();
            Transform _transform = PlayerSingleton.Instance.character;
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
           
            _model.MouseDirection= (targetPosition - _transform.position).normalized;
        }
    }
}