using System.Collections;
using System.Collections.Generic;
using QFramework.Player._Event_Behavior_;
using QFramework.Player.NewPlayerAutoGrab._Model;
using QFramework.Player.NewPlayerAutoGrab.Command;
using QFramework.Player.NewPlayerAutoGrab.Event;
using UnityEditor;
using UnityEngine;

namespace QFramework.Player.NewPlayerAutoGrab._AppControl
{
    public class NewAutoGarb_AppControl:MonoBehaviour,IController,ICanSendEvent
    {
        private PlayerSelf_Model _model;
        private NewAutoGrab_Model _newAutoGrabModel;

        private GameObject _player;
        private Transform _transform;
        private void Awake()
        {
            _model=this.GetModel<PlayerSelf_Model>();
            _newAutoGrabModel=this.GetModel<NewAutoGrab_Model>();  
            _player = PlayerSingleton.Instance.gameObject1;
            _transform=_player.GetComponent<Transform>();
            //钩爪开始移动
            this.RegisterEvent<NewShootStart_Event>(e =>
            {
                StartCoroutine(WaitForShoot());
                this.SendEvent(new GrabStart_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //钩爪结束移动
            this.RegisterEvent<NewShootEnd_Event>(e =>
            {
                this.SendEvent(new GrabHit_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //人物开始移动
            this.RegisterEvent<NewMoveStart_Event>(e =>
            {
                StartCoroutine(WaitForMove());
                this.SendEvent(new GrabMove_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //人物结束移动
            this.RegisterEvent<NewMoveEnd_Event>(e =>
            {

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        //人物持续移动的协程
        IEnumerator WaitForMove()
        {
            _newAutoGrabModel.IfMoveing = true;
            _model.IsGarbiing = true;
            NewPlayerFollowMove_Command playerFollowMoveCommand=new NewPlayerFollowMove_Command
                (_newAutoGrabModel.FollowObjectList[0],_transform);
            while ( _newAutoGrabModel.IfMoveing)
            {
                this.SendCommand(playerFollowMoveCommand);
                yield return null;
            }
            _model.IsGarbiing = false;
            this.SendEvent<NewMoveEnd_Event>();
        }
        //钩爪持续移动的协程
        IEnumerator WaitForShoot()
        {
            _newAutoGrabModel.IfShooting = true;
            NewShootRope_Command newShootRope_Command = new NewShootRope_Command(_newAutoGrabModel.FollowObjectList[0],_transform);
            while (_newAutoGrabModel.IfShooting)
            {
                this.SendCommand(newShootRope_Command);
                yield return null;
            }
            this.SendEvent<NewShootEnd_Event>();
        }
        private void Update()
        {
            this.SendCommand(new NewCheck_Command(gameObject));//创造扇形判定范围
            this.SendCommand(new NewFollowMouse_Command(transform));//跟随鼠标
            this.SendCommand<NewCheckMouse_Command>();//判断鼠标圆形范围内是否有物体
            if (_newAutoGrabModel.FollowObjectList.Count > 0)//目标列表里有物体
            {
                bool _canAutoGrab = _newAutoGrabModel.TriigerObjectList.Contains(_newAutoGrabModel.FollowObjectList[0]);//在触发器列表里面有目标物体
                if (Input.GetMouseButtonDown(0) && _model.GrabMount > 0&&_canAutoGrab)
                {
                    this.SendCommand(new NewSetRope_Command(_transform));
                    _model.GrabMount -= 1;
                    this.SendEvent<NewShootStart_Event>();
                }
            }
          
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Circle"))
            {
                _newAutoGrabModel.TriigerObjectList.Add(other.gameObject);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Circle"))
            {
                _newAutoGrabModel.TriigerObjectList.Remove(other.gameObject);
            }
        }
        private void OnDrawGizmos()
        {
            if (_newAutoGrabModel == null || Camera.main == null) return;
            // 设置Gizmos颜色
            Gizmos.color = Color.yellow;
            // 获取角色位置
            Vector3 characterPosition = transform.position;
            characterPosition.z = 0f;
            // 圆的半径
            float radius = _newAutoGrabModel.SphereRadius;
            // 获取鼠标位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            
            // 绘制起始圆
            Gizmos.DrawWireSphere(characterPosition, radius);
            // 计算结束位置
            Vector3 direction = (mousePosition - characterPosition).normalized;
            Vector3 endPosition = characterPosition + direction * _newAutoGrabModel.Distance;
            // 绘制结束圆
            Gizmos.DrawWireSphere(endPosition, radius);
            
            // 计算起始和结束圆的左右边缘位置
            Vector3 startLeft = characterPosition - Vector3.Cross(direction, Vector3.forward) * radius;
            Vector3 startRight = characterPosition + Vector3.Cross(direction, Vector3.forward) * radius;
            Vector3 endLeft = endPosition - Vector3.Cross(direction, Vector3.forward) * radius;
            Vector3 endRight = endPosition + Vector3.Cross(direction, Vector3.forward) * radius;

            // 绘制左边缘到左边缘的线
            Gizmos.DrawLine(startLeft, endLeft);

            // 绘制右边缘到右边缘的线
            Gizmos.DrawLine(startRight, endRight);
        }
        public IArchitecture GetArchitecture()
        {
            return GameObjects_App.Interface;
        }
    }
}