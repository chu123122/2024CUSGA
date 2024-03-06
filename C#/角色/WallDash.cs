using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDash : MonoBehaviour
{
    [Tooltip("µÅÇ½±ÚµÄ³å´ÌËÙ¶È")]
    public float dashForce;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)&&WallDashCheck.wallDash&& PlayerStateMachine.state!= 2)
        {
            Vector2 dashDirection = WallDashCheck.isRight ? Vector2.left : Vector2.right;
            //Player.PlayerRb.velocity = Vector2.zero;
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

            StartCoroutine(WaitForGravity());
        }
    }
    IEnumerator WaitForGravity()
    {
        yield return new WaitForSeconds(0.1f);
        Player.PlayerRb.gravityScale = Player.orginGravityScale;
    }
}
