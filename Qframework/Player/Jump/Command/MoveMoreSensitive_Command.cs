using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家在跳跃顶点时发送的移动指令（移动更灵敏）
/// </summary>
public class MoveMoreSensitive_Command : AbstractCommand
{
    protected override void OnExecute()
    {
        Debug.Log("1");
        #region 获取数据
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        PlayerMove_Model playerMove_Model = this.GetModel<PlayerMove_Model>();

        float speed = playerMove_Model.MoveSpeed;
        float acceleration = playerMove_Model.Acceleration;
        float decceleration = playerMove_Model.Decceleration;
        float velPower = playerMove_Model.VelPower;
        float frictionAmount = playerMove_Model.FrictionAmount;

        float accelerationMult = this.GetModel<PlayerJump_Model>().AccelerationMult;
        float maxSpeedMult = this.GetModel<PlayerJump_Model>().MaxSpeedMult;
        #endregion
        float targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        targetSpeed *= maxSpeedMult;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        accelRate *= accelerationMult;
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
