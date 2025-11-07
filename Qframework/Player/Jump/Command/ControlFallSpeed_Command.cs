using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 限制玩家下落的最大速度
/// </summary>
public class ControlFallSpeed_Command : AbstractCommand
{
    protected override void OnExecute()
    {
        #region 获取数据
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        float maxFallSpeed = this.GetModel<PlayerJump_Model>().MaxFallSpeed;
        #endregion

        rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));//下落最大速度限制
    }

}
