using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 设置玩家垂直速度为0后，给玩家一个向上的力
/// </summary>
public class AddUpForce_Command : AbstractCommand
{
    protected override void OnExecute()
    {
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        float jumpForce = this.GetModel<PlayerJump_Model>().JumpForce;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
