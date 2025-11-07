using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
/// <summary>
/// 增加玩家下落的重力
/// </summary>
public class AddFallGravity_Command : AbstractCommand
{
    protected override void OnExecute()
    {
        #region 数据获取
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        float orginGravityScale = this.GetModel<PlayerSelf_Model>().OrginGravityScale;
        float fallGrivityMultplier = this.GetModel<PlayerJump_Model>().FallGrivityMultplier;
        #endregion
        rb.gravityScale = orginGravityScale * fallGrivityMultplier;
    }
}
