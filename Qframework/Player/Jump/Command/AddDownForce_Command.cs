using QFramework;
using UnityEngine;

namespace C_.Qframework.Player.Jump.Command
{
    /// <summary>
    /// 给玩家一个向下的力
    /// </summary>
    public class AddDownForce_Command : AbstractCommand
    {
        protected override void OnExecute()
        {
            GameObject Player = PlayerSingleton.Instance.gameObject1;
            Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
            float jumpCutMultplier = this.GetModel<PlayerJump_Model>().JumpCutMultplier;

            rb.AddForce(Vector2.down * (rb.velocity.y * jumpCutMultplier), ForceMode2D.Impulse);
        }
    }
}
