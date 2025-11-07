using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Player._Event_Behavior_;

[CreateAssetMenu(menuName = "State/Player/Dash_1", fileName = "Dash_1_State")]
public class Dash_1_State : PlayerState,ICanGetModel,ICanSendCommand,ICanSendEvent,ICanRegisterEvent
{
    private PlayerSelf_Model _model;
    private Dash_1_Model _dash_1_Model;
    private Dash_0_Model _dash_0_Model;
    private Action<HaveForceDirection_Event> _forceDirectionHandler;
    private SpriteRenderer _spriteRenderer;
    public override void Enter()
    {
        Debug.Log("Enter Dash_1");
        this.GetModel<Dash_0_Model>().InDashState = true;
        
        _model=this.GetModel<PlayerSelf_Model>();
        _dash_1_Model = this.GetModel<Dash_1_Model>();
        _dash_0_Model=this.GetModel<Dash_0_Model>();
        _spriteRenderer=PlayerSingleton.Instance.spriteRenderer;
        
        _dash_1_Model.InState = true;
        
        _forceDirectionHandler = e =>
        {
            var addForceInPlayer_Command = new AddForceInPlayer_Command(e.playerDirection);//给玩家力
            this.SendCommand(addForceInPlayer_Command);

            var launchCircle_Command = new LaunchCircle_Command(e.circleDirection);//发射弹珠
            this.SendCommand(launchCircle_Command);


            var launchCircle_Event = new LaunchCircle_Event(_dash_1_Model.Time);
            this.SendEvent(launchCircle_Event);//发送已经丢球事件（为了再次接触的冷却）
            EnterNormalState_Event enterNormalState_Event = new EnterNormalState_Event(_spriteRenderer);
            this.SendEvent(enterNormalState_Event);//进入普通状态事件
        };
        this.RegisterEvent(_forceDirectionHandler);
    }
    public override void Exit()
    {
        this.SendEvent(new Throw_Event(PlayerSingleton.Instance.gameObject1));
         Debug.Log("Exit Dash_1");
         _dash_1_Model.InState = false;
         _dash_0_Model.InDashState = false;
         //PlayerSingleton.Instance.StartCoroutine(WaitTime());
         this.UnRegisterEvent(_forceDirectionHandler);
    }
    public override void LogicUpdate()
    {
        var checkMouseDirection_Command=new CheckMouseDirection_Command();
        this.SendCommand(checkMouseDirection_Command);

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Dash_1");
            var haveForceDirection_Event = new HaveForceDirection_Event
                (checkMouseDirection_Command.playerDirection, checkMouseDirection_Command.circleDirection);
            this.SendEvent(haveForceDirection_Event);
        }
    }

    IEnumerator WaitTime()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("2");
      
    }
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
