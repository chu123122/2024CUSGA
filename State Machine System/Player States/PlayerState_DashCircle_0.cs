using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Dash_0",fileName = "PlayerState_DashCircle_0")]

public class PlayerState_DashCircle_0 : PlayerState
{
    #region �ӵ�ʱ�����
    [Tooltip("�ӵ�ʱ��ĳ���ʱ��")]
    public float bulletTime = 0.5f;
    [Tooltip("�ӵ�ʱ���ʱ�����ű���")]
    public float bulletTimeScale=0.1f;
    #endregion
    public static float bulletTimeCounter = 0.0f;
    [HideInInspector] public static bool isBulletTimeActive = false;
    #region ��̲���
    [Tooltip("���ˮƽ��")]
    public  float dashForce;
    [Tooltip("��̴�ֱ��")]
    public  float dashForceH;
    [Tooltip("�ӵ�ʱ�����ú���Գ��")]
    public float dashTimeCheck = 0.45f;
    #endregion

    public override void Enter()
    {
        //Debug.Log("Enter Dash_0");
        #region ����״̬׼��
        
        PlayerCollisionCheck.PlayerTouchCircle = false;
        bulletTimeCounter = bulletTime;
        isBulletTimeActive = true;

        Player.PlayerSr.color = Color.yellow;//�л�����

        #endregion

    }
    public override void Exit()
    {
        //Debug.Log("Exit Dash_0");
        #region �˳�״̬����
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

    #region ������ݼ�����
    public static int side = 0;//��̷���
    public static int dashMount = 0;//��̴���

    public void DashCheck()
    {
        if (dashMount > 0 && bulletTimeCounter <= (bulletTime - dashTimeCheck))
        {
            //Debug.Log("DashCheck");
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                side = 1;//��
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                side = 2;//����
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                side = 3;//��
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                side = 4;//����
            }
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                side = 5;//��
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                side = 6;//����
            }
            else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                side = 7;//��
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                side = 8;//����
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
            
            #region ��̷���ѡ��ʩ��
            switch (side)
            {
                case 1://��
                    Player.PlayerRb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    Debug.Log("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 2://����
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 3://��
                    Player.PlayerRb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 4://����
                    Player.PlayerRb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 5://��
                    Player.PlayerRb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    Debug.Log("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 6://����
                    Player.PlayerRb.AddForce(Vector2.left *dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 7://��
                    Player.PlayerRb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 8://����
                    Player.PlayerRb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    Debug.Log("����");
                    side = 0;
                    dashMount -= 1;
                    break;
            }
            #endregion
        }
    }
    #endregion

    

  
}
