using QFramework.Player.NewPlayerAutoGrab._Model;
using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab.Command
{
    public class NewCheckMouse_Command:AbstractCommand
    {
        private NewAutoGrab_Model _newAutoGrabModel;
        private Transform _transform;
        protected override void OnExecute()
        {
            _newAutoGrabModel=this.GetModel<NewAutoGrab_Model>();
            _transform=PlayerSingleton.Instance.transform1;
            // 获取角色位置
            Vector3 characterPosition = _transform.position;
            characterPosition.z = 0f;
            // 获取鼠标位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            // 计算结束位置
            Vector3 direction = (mousePosition - characterPosition).normalized;
            Vector3 endPosition = characterPosition + direction * _newAutoGrabModel.Distance;
            //获取排除碰撞的层级
            int circleLayer = LayerMask.NameToLayer("Circle");
            int layerMask = (1 << circleLayer);
           // Collider2D colliders = Physics2D.OverlapCircle(mousePosition, _newAutoGrabModel.SphereRadius, layerMask);
            RaycastHit2D colliders = Physics2D.CircleCast(characterPosition, _newAutoGrabModel.SphereRadius,direction,_newAutoGrabModel.Distance, layerMask);
            if (colliders)
            {
                
                _newAutoGrabModel.FollowObjectList.Add(colliders.collider.gameObject);//保证列表中只存在一个物体
                _newAutoGrabModel.FollowObjectList[0].GetComponent < SpriteRenderer>().color = Color.green;
            }
            else
            {
                if (_newAutoGrabModel.FollowObjectList.Count > 0&&!_newAutoGrabModel.IfShooting)//确保只有退出了钩爪状态是才将追逐物体从列表删去
                {
                    _newAutoGrabModel.FollowObjectList[0].GetComponent < SpriteRenderer>().color = Color.red;
                    _newAutoGrabModel.FollowObjectList.Clear();//清空列表
                }
            }
            _newAutoGrabModel.MousehaveCircle=colliders;
        }
    }
}