using QFramework;
using System.Collections;
using System.Collections.Generic;
using QFramework.Player._Event_Behavior_;
using QFramework.Player.NewPlayerGrab.Event;
using UnityEngine;

public class PlayerMove_Appcontroll : MonoBehaviour, IController, ICanSendEvent
{
    private PlayerSelf_Model _playerSelfModel;
    private PlayerJump_Model _jumpModel;
    private Dash_0_Model _dash0Model;
    public static bool CanMove=true;
    private void Awake()
    {
        _playerSelfModel = this.GetModel<PlayerSelf_Model>();
        _jumpModel=this.GetModel<PlayerJump_Model>();
        _dash0Model=this.GetModel<Dash_0_Model>();
        this.RegisterEvent<MoveStart_Event>(e =>
        {
            CanMove=false;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        this.RegisterEvent<MoveEnd_Event>(e =>
        {
            CanMove = true;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }
    private void Update()
    {
        // Debug.LogWarning("CanMove:"+CanMove);
        // Debug.LogWarning("IsGarbiing:"+_playerSelfModel.IsGarbiing);
        // Debug.LogWarning("IsDashing:"+_playerSelfModel.IsDashing);
        // Debug.LogWarning("InState:"+_dash0Model.InState);
        if (Input.GetKeyDown(KeyCode.A)) PlayerSingleton.Flip(false);
        else if (Input.GetKeyDown(KeyCode.D))PlayerSingleton.Flip(true);

        var velocity = PlayerSingleton.Instance.rigidbody2D.velocity;
        bool isIdle = Mathf.Abs(velocity.x ) < 0.01f;
        AnimatorStateInfo stateInfo =PlayerSingleton.Instance.animator.GetCurrentAnimatorStateInfo(0);             
        if (isIdle&&_playerSelfModel.InGround&&stateInfo.IsName("Run"))
        {
            PlayerSingleton.Instance.animator.Play("Idle");            
        }else if (!isIdle && _playerSelfModel.InGround && stateInfo.IsName("Idle"))
        {
            if (Mathf.Abs(PlayerSingleton.Instance.rigidbody2D.velocity.x) > 0.5f)
            {
                PlayerSingleton.Instance.animator.Play("Run",-1,0f);
            }
               
        }
        if (CanMove&& !_playerSelfModel.IsGarbiing&& !_playerSelfModel.IsDashing&&!_dash0Model.InState)              
        {
            if (!_playerSelfModel.IsJumpingPoint)
            {
                bool input = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
                if(input&&_playerSelfModel.InGround) 
                    this.SendEvent(new PlayerMoveStart_Event(gameObject));
                
                var move_Normal_Command = new Move_Normal_Command(1, 1);
                this.SendCommand(move_Normal_Command);
                if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)) this.SendEvent(new PlayerMoveEnd_Event(gameObject));
                    
            }
            else
            {
                bool input = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
                if(input&&_playerSelfModel.InGround) 
                    this.SendEvent(new PlayerMoveStart_Event(gameObject));
                
                var move_Normal_Command = new Move_Normal_Command(_jumpModel.MaxSpeedMult, _jumpModel.AccelerationMult);
                this.SendCommand(move_Normal_Command);
                if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)) this.SendEvent(new PlayerMoveEnd_Event(gameObject));
            }
        }
    }
    
   
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
