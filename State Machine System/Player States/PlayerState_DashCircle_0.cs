using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Dash_0",fileName = "PlayerState_DashCircle_0")]

public class PlayerState_DashCircle_0 : PlayerState
{
    #region 子弹时间参数
    [Tooltip("子弹时间的持续时间")]
    public float bulletTime = 0.5f;
    [Tooltip("子弹时间的时间缩放比例")]
    public float bulletTimeScale=0.1f;
    #endregion
    public static float bulletTimeCounter = 0.0f;
    [HideInInspector] public static bool isBulletTimeActive = false;
    #region 冲刺参数
    [Tooltip("冲刺水平力")]
    public  float dashForce;
    [Tooltip("冲刺垂直力")]
    public  float dashForceH;
    [Tooltip("子弹时间过多久后可以冲刺")]
    public float dashTimeCheck = 0.45f;
    #endregion

    public override void Enter()
    {
        //Debug.Log("Enter Dash_0");
        #region 进入状态准备
        
        PlayerCollisionCheck.PlayerTouchCircle = false;
        bulletTimeCounter = bulletTime;
        isBulletTimeActive = true;

        Player.PlayerSr.color = Color.yellow;//切换动画

        #endregion

    }
    public override void Exit()
    {
        //Debug.Log("Exit Dash_0");
        #region 退出状态重置
        Player.PlayerRb.gravityScale = Player.orginGravityScale;
        bulletTimeCounter = 0.0f;
        Time.timeScale = 1.0f;
        isBulletTimeActive = false;
        side = 0;
        bulletTimeScale = 0.1f;
        #endregion
       // PlayerStateMachine.state = 2;
    }
    public override void LogicUpdate()
    {
        //Debug.Log("bulletTimeCounter:" + bulletTimeCounter);
       
        if (isBulletTimeActive && bulletTimeCounter > 0)
        {
            Time.timeScale = bulletTimeScale;
            isBulletTimeActive = true;
        }

       DashCheck();
       DashEffect();
       DashAddForce();
    }
    public override void PhysicUpdate()
    {
        if (isBulletTimeActive && bulletTimeCounter > 0)
        {
            bulletTimeCounter -= Time.deltaTime;
        }
        else
        {
            isBulletTimeActive = false;
        }
    }

    #region 冲刺数据及函数
    public static int side = 0;//冲刺方向
    public static int dashMount = 0;//冲刺次数

    public void DashCheck()
    {
        if (dashMount > 0 && bulletTimeCounter <= (bulletTime - dashTimeCheck))
        {
            //Debug.Log("DashCheck");
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
    public void DashEffect()
    {
        if (side == 0)
        {
            Player.PlayerRb.gravityScale = Player.orginGravityScale;
        }
        else if (side != 0)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            bulletTimeScale = 1.0f;
        }
    }
    public void DashAddForce()
    {
        if (dashMount > 0)
        {
            
            #region 冲刺方向选择施力
            switch (side)
            {
                case 1://右
                    Player.PlayerRb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    Debug.Log("右");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 2://右下
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("右下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 3://下
                    Player.PlayerRb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 4://左下
                    Player.PlayerRb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("左下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 5://左
                    Player.PlayerRb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    Debug.Log("左");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 6://左上
                    Player.PlayerRb.AddForce(Vector2.left *dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("左上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 7://上
                    Player.PlayerRb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 8://右上
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("右上");
                    side = 0;
                    dashMount -= 1;
                    break;
            }
            #endregion
        }
    }
    #endregion

    

  
}
