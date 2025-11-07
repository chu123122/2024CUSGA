using System.Collections;
using System.Collections.Generic;
using C_.StateMachine.Player.State;
using UnityEngine;
using QFramework;
using QFramework.Player.State.Dah_0_State.NewEvent;

public class PlayerState_Machine : StateMachine,ICanGetModel,ICanSendEvent,ICanRegisterEvent
{
    public Normal_State Normal_State;
    public NewDash_0_State Dash_0_State;
    public Dash_1_State Dash_1_State;

    private PlayerStateCheck_Model _playerStateCheck_Model;
    private PlayerSelf_Model _playerSelf_Model;
    private SpriteRenderer _spriteRenderer;
    private int _enterStateNumber;
    private void Awake()
    {
        Normal_State.Initialize(this);
        Dash_0_State.Initialize(this);
        Dash_1_State.Initialize(this);

        _playerStateCheck_Model = this.GetModel<PlayerStateCheck_Model>();
        _playerSelf_Model= this.GetModel<PlayerSelf_Model>();
        _spriteRenderer=PlayerSingleton.Instance.spriteRenderer;

        SwitchOn(Normal_State);

        #region 接受进入状态事件
        this.RegisterEvent<EnterNormalState_Event>(e =>
        {
            _playerStateCheck_Model.StateNumber =0;
            
            _playerStateCheck_Model.StateNumber = 0;
            _enterStateNumber = 0;

            _playerSelf_Model.IsStating = false;
            SwitchState(Normal_State);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        
        this.RegisterEvent<EnterDash_0_Event>(e =>
        {
            _playerStateCheck_Model.StateNumber = 1;
            _enterStateNumber = 1;

            _playerSelf_Model.IsStating = true;
            SwitchState(Dash_0_State);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
       
        this.RegisterEvent<EnterDash_1State_Event>(e =>
        {
            _playerStateCheck_Model.StateNumber = 2;
            _enterStateNumber = 2;

            _playerSelf_Model.IsStating = false;
            SwitchState(Dash_1_State);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        #endregion

        #region 接受退出状态事件
        this.RegisterEvent<ExitDash_0_Event>(e =>
        {
            this.SendEvent<EnterDash_1State_Event>();

        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        #endregion
    }

    private void Update()
    {
        if (_playerStateCheck_Model.StateNumber == 0 && _enterStateNumber != 0)
        {
            this.SendEvent<EnterNormalState_Event>();
        }
        else if (_playerStateCheck_Model.StateNumber == 1 && _enterStateNumber != 1)
        {
            this.SendEvent<EnterDash_0_Event>();
        }
        else if (_playerStateCheck_Model.StateNumber == 2 && _enterStateNumber != 2)
        {
            this.SendEvent<EnterDash_1State_Event>();
        }
        currenntState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currenntState.PhysicUpdate();
    }

    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
