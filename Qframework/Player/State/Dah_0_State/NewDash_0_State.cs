using System;
using System.Collections;
using C_.StateMachine.Player.State.Command_1;
using QFramework;
using QFramework.Player._Event_Behavior_;
using QFramework.Player.State.Dah_0_State.NewEvent;
using UnityEngine;

namespace C_.StateMachine.Player.State
{
    [CreateAssetMenu(menuName = "State/Player/NewDash_0", fileName = "NewDash_0_State")]
    public class NewDash_0_State:PlayerState,ICanGetModel,ICanSendCommand,ICanSendEvent,ICanRegisterEvent
    {
        private PlayerSelf_Model _model;
        private Dash_0_Model  _dash_0_Model;
        private Action<HaveDashPosition_Event> _haveDashPosition_Event;
        private Action<EnterDash_0_Event> _enterDash_0_Event;
        private float _timer;
        public override void Enter()
        {
            Debug.Log("Enter Dash_0");
            this.SendEvent(new MablessGet_Event(PlayerSingleton.Instance.gameObject1));
            _model=this.GetModel<PlayerSelf_Model>();
            _dash_0_Model=this.GetModel<Dash_0_Model>();
            _dash_0_Model.Side = 0;
            _dash_0_Model.DashMount = 1;
            _dash_0_Model.IsWaiting = true;
            _dash_0_Model.InState = true;
            Dash_0_MonoBehivor.Instance.StartCoroutine(WaitRespond());
            
            _haveDashPosition_Event=e =>
            {
                Dash_0_MonoBehivor.Instance.StartCoroutine(WaitDash());
            }; this.RegisterEvent(_haveDashPosition_Event);
        }
        public override void Exit()
        {
            Debug.Log("Exit Dash_0");
            _dash_0_Model.InState = false;
            this.UnRegisterEvent(_enterDash_0_Event);
            this.UnRegisterEvent(_haveDashPosition_Event);
        }
        IEnumerator WaitDash()
        {
            Dash dash = new Dash();
            _dash_0_Model.IsDashing = true;
            _timer = _dash_0_Model.DashTimeController;
            while (_dash_0_Model.IsDashing)
            {
                this.SendCommand(dash);
                _timer-=Time.deltaTime;
                if(_timer<=0)break;
                yield return null;
            }
           this.SendEvent<ExitDash_0_Event>();
        }

        IEnumerator WaitRespond()
        {
            WaitForRespond waitForRespondCommand = new WaitForRespond();
            _dash_0_Model.WaitTimer=_dash_0_Model.WaitTime;//��Ӧʱ�������
            while (_dash_0_Model.IsWaiting)
            {
                this.SendCommand(waitForRespondCommand);
                yield return null;
            }
        }

        public override void LogicUpdate()
        {
            if (!_dash_0_Model.IsWaiting)
            {
                this.SendCommand<CheckDashSide>(); //�����Ƿ�ȷ����̷���
                if (_dash_0_Model.Side != 0)
                {
                    this.SendCommand<ComputeDashPosiiton>(); //�����̷���ȷ���������λ��

                }
            }
        }
        public IArchitecture GetArchitecture()
        {
            return  GameObjects_App.Interface;
        }
    }
}