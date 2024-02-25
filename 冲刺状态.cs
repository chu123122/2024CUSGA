using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public static int side = 0;//冲刺方向
    public static int dashMount = 0;//冲刺次数
    public float dashForce;//冲刺水平力
    public float dashForceH;//冲刺垂直力


    public void DashButtonCheck()
    {
        if (dashMount > 0&& DashCircle.bulletTimeCounter <= 0.45f)
        {
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                side = 1;//右
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                side = 2;//右下
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                side = 3;//下
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                side = 4;//左下
            }
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                side = 5;//左
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                side = 6;//左上
            }
            else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                side = 7;//上
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                side = 8;//右上
            }

        }
    }
    public void DashButtonEffect()
    {
        if (side == 0)
        {
            Player.PlayerRb.gravityScale = Player.orginGravityScale;
        }
        else if (side != 0)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
        }
    }

    public void DashButtonAddForce()
    {
        if (dashMount > 0)
        {
            #region 冲刺方向选择施力
            switch (side)
            {
                case 1://右
                    Player.PlayerRb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    print("右");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 2://右下
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("右下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 3://下
                    Player.PlayerRb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 4://左下
                    Player.PlayerRb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("左下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 5://左
                    Player.PlayerRb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    print("左");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 6://左上
                    Player.PlayerRb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("左上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 7://上
                    Player.PlayerRb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 8://右上
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("右上");
                    side = 0;
                    dashMount -= 1;
                    break;
            }
            #endregion
        }
    }
}
