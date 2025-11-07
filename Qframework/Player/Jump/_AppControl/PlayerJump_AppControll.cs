using C_.Qframework.Player.Jump.Command;
using UnityEngine;
using QFramework;
using QFramework.Player._Event_Behavior_;
using UnityEditor;
using UnityEngine.InputSystem;
public class PlayerJump_AppControll : MonoBehaviour,IController,ICanSendEvent
{
    private PlayerSelf_Model _playerModel;
    private PlayerJump_Model _jumpModel;
    private Rigidbody2D _rb;
    private bool _jumpBuffered;
    private bool _jumpCoyoted;
    private float _lastJumpTime;
    private float _lastGroundTime;

    MyInputAction inputActions;//按下空格
    private void Awake()
    {
        _playerModel = this.GetModel<PlayerSelf_Model>();
        _jumpModel = this.GetModel<PlayerJump_Model>();
        _rb =PlayerSingleton.Instance.rigidbody2D;
        inputActions=new MyInputAction();

        this.RegisterEvent<PlayerIsJumping_Event>(e =>
        {
            _playerModel.JumpMount -=1;
            _playerModel.IsJumping = e._isJumping;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        this.RegisterEvent<PlayerJump_IsPoint_Event>(e =>
        {
            _playerModel.IsJumpingPoint = e._isJumpingPoint;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.GamePlay.JumpHoldDown.performed += JumpHoldDown_performed;
        inputActions.GamePlay.JumpHoldUp.performed += JumpHoldUp_performed;
    }

    private void JumpHoldUp_performed(InputAction.CallbackContext obj)//松开空格的取消跳跃
    {
        if (  _playerModel.IsJumping)
        {
           
            _playerModel.JumpMount -= 1;
            
            this.SendCommand<AddDownForce_Command>();
        }
       
    }

    private void JumpHoldDown_performed(InputAction.CallbackContext obj)//每次按下空格时重置缓冲时间
    {
        _lastJumpTime = _jumpModel.JumpBuffetTime;
        _jumpBuffered = true;
        if (_playerModel.JumpMount < 1 && _playerModel.InGround) _playerModel.JumpMount = 1;
    }

    private void OnDisable()
    {
        inputActions.GamePlay.JumpHoldDown.performed -= JumpHoldDown_performed;
        inputActions.GamePlay.JumpHoldUp.performed -= JumpHoldUp_performed;
        inputActions.Disable();
    }
    private void Update()
    {
        //交互逻辑
        _lastJumpTime -= Time.deltaTime;
        _lastGroundTime-= Time.deltaTime;
        if (_playerModel.InGround&& _lastJumpTime >0&& _jumpBuffered && _playerModel.JumpMount>0)//按下空格的起跳
        {
            _jumpBuffered =false;
            this.SendCommand<AddUpForce_Command>();
            this.SendEvent(new PlayerIsJumping_Event(true));
            
            this.SendEvent(new Jump_Event(gameObject));
            
        }
        else if (_lastGroundTime>0 && _playerModel.JumpMount > 0&&_lastJumpTime > 0 && _jumpBuffered)//土狼跳跃的考虑
        {
            _jumpBuffered = false;
            this.SendCommand<AddUpForce_Command>();
            this.SendEvent(new PlayerIsJumping_Event(true));
            
            this.SendEvent(new Jump_Event(gameObject));
           
        }
        if (!_playerModel.InGround&&!_jumpCoyoted)//每次离开地面时重置土狼时间
        {
            _lastGroundTime = _jumpModel.JumpCoyoteTime;
            _jumpCoyoted = true;
        }
        if (_playerModel.InGround)
        {
            _jumpCoyoted = false;
        }
        if (_playerModel.HasLoading)
        {
            var playerJump_Start_Event = new PlayerIsJumping_Event(false);
            this.SendEvent(playerJump_Start_Event);
        }
    }

    private void FixedUpdate()
    {
        if(!_playerModel.IsDashing && !_playerModel.IsGarbiing && !_playerModel.IsStating)
        {
            if (_rb.velocity.y < 0 && _lastGroundTime <= 0 && !_playerModel.IsJumpingPoint)//下落阶段
            {
                this.SendCommand<AddFallGravity_Command>();
                this.SendCommand<ControlFallSpeed_Command>();
            }
            if (_playerModel.IsJumping && !_playerModel.InGround && Mathf.Abs(_rb.velocity.y) < _jumpModel.TimeThreshold)//跳跃顶点阶段
            {
                var playerJump_IsPoint_Event = new PlayerJump_IsPoint_Event(true);
                this.SendEvent(playerJump_IsPoint_Event);
                this.SendCommand<DeclineGravity_Command>();
            }
            else
            {
                var playerJump_IsPoint_Event = new PlayerJump_IsPoint_Event(false);
                this.SendEvent(playerJump_IsPoint_Event);
            }
        }
        else
        {
            // Debug.LogWarning("IsDashing:"+_playerModel.IsDashing);
            // Debug.LogWarning("IsGarbiing:"+_playerModel.IsGarbiing);
            // Debug.LogWarning("IsDashing:"+_playerModel.IsStating);
        }
        
        

    }

    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
