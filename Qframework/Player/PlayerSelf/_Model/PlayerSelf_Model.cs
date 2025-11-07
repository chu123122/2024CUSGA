using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可以尝试构造函数中使用获取初始_tag
public class PlayerSelf_Model : AbstractModel
{
    private float _orginGravityScale;//人物重力
    private float _jumpMount;
    private float _dashMount;
    private float _grabMount;
    private bool _inGround;
    private bool _layIsGround;
    private bool _hasLoading;
    private bool _isJumpingPoint;

    private bool _isJumping;//跳跃状态
    private bool _isDashing;//冲刺状态
    private bool _isGarbiing;
    private bool _isStating;//状态机状态
    public bool LayIsGround { get => _layIsGround; set => _layIsGround = value; }
    public float OrginGravityScale { get => _orginGravityScale; set => _orginGravityScale = value; }
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public bool InGround { get => _inGround; set => _inGround = value; }
    public bool HasLoading { get => _hasLoading; set => _hasLoading = value; }
    public bool IsJumpingPoint { get => _isJumpingPoint; set => _isJumpingPoint = value; }
    public float JumpMount { get => _jumpMount; set => _jumpMount = value; }
    public float DashMount { get => _dashMount; set => _dashMount = value; }
    public bool IsDashing { get => _isDashing; set => _isDashing = value; }
    public float GrabMount { get => _grabMount; set => _grabMount = value; }
    public bool IsStating { get => _isStating; set => _isStating = value; }
    public bool IsGarbiing { get => _isGarbiing; set => _isGarbiing = value; }

    protected override void OnInit()
    {
        JumpMount = 1;
        DashMount = 1;
        //读数据
    }

}
