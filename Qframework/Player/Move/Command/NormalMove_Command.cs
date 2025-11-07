using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEditor;
/// <summary>
/// 玩家移动时发送的指令
/// </summary>
public class Move_Normal_Command : AbstractCommand
{
    private readonly float _maxSpeedMult;
    private readonly float _accelerationMult;
    public Move_Normal_Command(float maxSpeedMult, float accelerationMult)
    {
        _maxSpeedMult=maxSpeedMult;
        _accelerationMult=accelerationMult; 
    }
    protected override void OnExecute()
    {
        #region 获取数据
        Rigidbody2D rb = PlayerSingleton.Instance.rigidbody2D;
        float speed = this.GetModel<PlayerMove_Model>().MoveSpeed;
        float acceleration = this.GetModel<PlayerMove_Model>().Acceleration;
        float decceleration = this.GetModel<PlayerMove_Model>().Decceleration;
        float velPower = this.GetModel<PlayerMove_Model>().VelPower;
        float frictionAmount = this.GetModel<PlayerMove_Model>().FrictionAmount;
        #endregion
        float targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        targetSpeed *= _maxSpeedMult;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        accelRate *= _accelerationMult;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(movement * Vector2.right);
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)//摩擦力
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
    }

}
