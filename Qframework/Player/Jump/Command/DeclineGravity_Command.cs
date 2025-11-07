using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制玩家重力减少
/// </summary>
public class DeclineGravity_Command : AbstractCommand
{
    protected override void OnExecute()
    {
        #region 数据获取
        GameObject Player = PlayerSingleton.Instance.gameObject1;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        float orginGravityScale = this.GetModel<PlayerSelf_Model>().OrginGravityScale;
        float grivityMult = this.GetModel<PlayerJump_Model>().GrivityMult;
        #endregion
        rb.gravityScale = orginGravityScale * grivityMult;//重力减少
    }
}
