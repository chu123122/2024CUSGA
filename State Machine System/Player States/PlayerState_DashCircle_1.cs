using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.SceneManagement;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash_1", fileName = "PlayerState_DashCircle_1")]
public class PlayerState_DashCircle_1 : PlayerState
{
    #region ��������������
    [Tooltip("����Ŀ�¡����Ԥ����")]
    public GameObject spherePrefab;
    [Tooltip("������ʧ��ʱ��")]
    public float saveTime = 1.0f;
    [Tooltip("����ķ����ٶ�")]
    public float circleHitForce = 3f;
    [Tooltip("�����ٶȵ��ڶ���ʱ�ɴ���")]
    public float isTiggeredSpeed=5f;
    [Tooltip("�������")]
    public float dashForce;
    #endregion

    public static int i = 1;
    public static GameObject cloneSphereHit;
    [HideInInspector]  public float saveTimeConller;

    public override void Enter()
    {
        Debug.Log("Enter Dash_1");
    }

    public override void Exit()
    {
        Debug.Log("Exit Dash_1");
    }
    public override void LogicUpdate()
    {
        #region �����ʩ��
        if (Input.GetMouseButtonDown(1) && Player.PlayerSr.color == Color.yellow)
        {
            AddForce();
            Launch();
            Player.PlayerSr.color = Color.white;
        }
        #endregion
    }
  
    void Launch()//��������
    {
        Vector2 playerEdgePosition = Player.PlayerCo.ClosestPoint(Player.PlayerTf.position);// ��Եλ��
        cloneSphereHit = Instantiate(spherePrefab, playerEdgePosition, Quaternion.identity);
        #region ��¡���ʼ��

        cloneSphereHit.name = "dashCircle" + i.ToString();
        i += 1;
        cloneSphereHit.AddComponent<CloneDashCircle>();
        saveTimeConller = saveTime;
        #endregion
        Rigidbody2D cloneSphereRb = cloneSphereHit.GetComponent<Rigidbody2D>();

        #region  ��ȡ���巢�䷽��
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mouseDirection = (mouseWorldPosition - Player.PlayerTf.position).normalized;
        Vector3 negativeMouseDirection = -mouseDirection;
        #endregion

        #region ��������ǰ�����ײ�仯
        CircleCollider2D cloneCollider = cloneSphereHit.GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(cloneCollider, Player.PlayerTf.GetComponent<Collider2D>(), true);// �ڷ���ǰ������ײ
        cloneSphereRb.AddForce(negativeMouseDirection * circleHitForce, ForceMode2D.Impulse);
        
        PlayerState_DashCircle_1_TimePart.instance.StartEnableCollisionAfterDelay(cloneCollider);
        #endregion

    }

    void AddForce()
    {
        Player.PlayerRb.velocity = Vector2.zero;
        Player.PlayerRb.gravityScale = 0;
        Player.PlayerRb.AddForce(Grab.direction *new Vector2(dashForce, dashForce), ForceMode2D.Impulse);
        Player.PlayerRb.gravityScale = Player.orginGravityScale;
    }
}
