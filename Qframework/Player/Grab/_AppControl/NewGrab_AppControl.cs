using System.Collections;
using System.Collections.Generic;
using QFramework.Player._Event_Behavior_;
using QFramework.Player.NewPlayerGrab._Model;
using QFramework.Player.NewPlayerGrab.Command;
using QFramework.Player.NewPlayerGrab.Event;
using UnityEditor;
using UnityEngine;
using MoveStart_Event = QFramework.Player.NewPlayerGrab.Event.MoveStart_Event;

namespace QFramework.Player.NewPlayerGrab._AppControl
{
    public class NewGrab_AppControl:MonoBehaviour,IController,ICanSendEvent
    {
        private PlayerSelf_Model _playerSelfModel;
        private NewGrab_Model _newGrabModel;
        private CheckMouseDircetion_Command _checkMouseDircetionCommand; 
        private float grabTimeController;

        private void Awake()
        {
            _playerSelfModel=this.GetModel<PlayerSelf_Model>();
            
            _newGrabModel=this.GetModel<NewGrab_Model>();
            _checkMouseDircetionCommand = new CheckMouseDircetion_Command();
            //开始发射钩爪
            this.RegisterEvent<ShootStart_Event>(e =>
            {
                _playerSelfModel.GrabMount -= 1;
                StartCoroutine(ContinueShoot());
                this.SendEvent(new GrabStart_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //钩爪到达目标点
            this.RegisterEvent<ShootEnd_Event>(e =>
            {
                this.SendEvent<MoveStart_Event>();
                this.SendEvent(new GrabHit_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
           //人物开始移动
            this.RegisterEvent<MoveStart_Event>(e =>
            {
                _playerSelfModel.IsGarbiing=true;//在PlayerSelf中设置重力为0并不能移动
                StartCoroutine(ContinueMove());
                this.SendEvent(new GrabMove_Event(gameObject));
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            //人物到底目标点
            this.RegisterEvent<MoveEnd_Event>(e =>
            {
                _playerSelfModel.IsGarbiing=false;
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        IEnumerator ContinueMove()
        {
            _newGrabModel.IfMoveing = true;
            MoveFollowRope_Command followRopeCommand=new MoveFollowRope_Command();
            grabTimeController = _newGrabModel.GrabTimeController;
            while (_newGrabModel.IfMoveing)
            {
                this.SendCommand(followRopeCommand);
                grabTimeController-=Time.deltaTime;
                if (grabTimeController <= 0)
                {
                    PlayerSingleton.Instance.lineRenderer.enabled=false;
                    break;
                }                
                yield return null;
            }
            this.SendEvent<MoveEnd_Event>();
        }
        IEnumerator ContinueShoot()
        {
            _newGrabModel.IfShooting = true;
            ShootRope_Command shootRope_Command=new ShootRope_Command();
            while (_newGrabModel.IfShooting)
            {
                this.SendCommand(shootRope_Command);
                yield return null;
            }
            this.SendEvent<ShootEnd_Event>();
        }

        private void Update()
        {
            this.SendCommand(_checkMouseDircetionCommand);
            if (Input.GetMouseButtonDown(0)&&_playerSelfModel.GrabMount>0)
            {
                this.SendCommand<RayHitCheck_Command>();//发射射线检测是否有可抓取物体，如果有则发送抓取开始事件
            }

        }

        public IArchitecture GetArchitecture()
        {
            return GameObjects_App.Interface;
        }
    }
}