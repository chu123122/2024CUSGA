using QFramework.Player.NewPlayerAutoGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewCheck_Command:AbstractCommand
    {
        private NewAutoGrab_Model _newAutoGrabModel;
        private GameObject _player;
        public NewCheck_Command(GameObject player)
        {
            _player = player;
        }
        protected override void OnExecute()
        {
            _newAutoGrabModel=this.GetModel<NewAutoGrab_Model>();
            
            PolygonCollider2D polyCollider = _player.GetComponent<PolygonCollider2D>();
            float angleDelta = (_newAutoGrabModel.EndAngle - _newAutoGrabModel.StartAngle) / _newAutoGrabModel.StartAngle;
            Vector2[] points = new Vector2[_newAutoGrabModel.Segments + 2];
            for (int i = 0; i <= _newAutoGrabModel.Segments; i++)
            {
                float angle = Mathf.Deg2Rad * (_newAutoGrabModel.StartAngle + angleDelta * i);
                float x = Mathf.Cos(angle) * _newAutoGrabModel.Radius;
                float y = Mathf.Sin(angle) * _newAutoGrabModel.Radius;
                points[i] = new Vector2(x, y);
            }
            points[_newAutoGrabModel.Segments + 1] = Vector2.zero;
            polyCollider.points = points;
            
        }
    }
}