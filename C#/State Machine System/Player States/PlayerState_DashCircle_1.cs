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
    [Tooltip("����Ŀ�¡���忪ʼ��ײ�ж�Ԥ����")]
    public GameObject spherePrefabFirstCheck;
    [Tooltip("������ʧ��ʱ��")]
    public float saveTime = 1.0f;
    [Tooltip("����ķ����ٶ�")]
    public float circleHitForce = 3f;
    [Tooltip("�����ٶȵ��ڶ���ʱ�ɴ���")]
    public float isTiggeredSpeed=5f;
    [Tooltip("�������")]
    public float dashForce;
    [Tooltip("�ٶȿ�����")]
    public bool speedController;
    [Tooltip("ˮƽ�ٶ�")]
    public  float xSpeed;
    [Tooltip("��ֱ�ٶ�")]
    public  float ySpeed;
    [Tooltip("�ж���Χ����")]
    public  float radius=0.52f;

    #endregion

    public static int i = 1;
    public static GameObject cloneSphereHit;
    [HideInInspector]  public float saveTimeConller;

    public override void Enter()
    {
        //Debug.Log("Enter Dash_1");
    }

    public override void Exit()
    {
       // Debug.Log("Exit Dash_1");
    }
    public override void LogicUpdate()
    {
        #region �����ʩ��
        if (Input.GetMouseButtonDown(1) )//&& Player.PlayerSr.color == Color.yellow)
        {
            Debug.Log("BUtton");
            AddForce();
            Launch();
            Player.PlayerSr.color = Color.white;
        }
        #endregion
    }
    void Launch()//��������
    {
        Vector2 playerEdgePosition = Player.PlayerCo.ClosestPoint(Player.PlayerTf.position);// ��Եλ��
        cloneSphereHit = Instantiate(spherePrefab, Player.PlayerTf.position, Quaternion.identity);
       // GameObject cloneCheck = Instantiate(spherePrefabFirstCheck, Player.PlayerTf.position, Quaternion.identity);
        //cloneCheck.transform.parent = cloneSphereHit.transform;

        #region ��¡���ʼ��
        Transform parentTransform = GameObject.Find("DashCircle").transform;
        cloneSphereHit.transform.SetParent(parentTransform);
        cloneSphereHit.name = "dashCircle" + i.ToString()+"(Clone)";
        cloneSphereHit.tag = "DashCircle";
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
        Physics2D.IgnoreCollision(cloneCollider, Player.PlayerTf.GetComponent<CircleCollider2D>(), true);// �ڷ���ǰ������ײ
        cloneSphereRb.AddForce(negativeMouseDirection * circleHitForce, ForceMode2D.Impulse);

        ShotTime = DateTime.Now;//��¼����ʱ��

        PlayerState_DashCircle_1_TimePart.instance.StartEnableCollisionAfterDelay(cloneCollider);
        #endregion

    }
    public static DateTime ShotTime;
    void AddForce()
    {
        Player.PlayerRb.velocity = Vector2.zero;
        Player.PlayerRb.gravityScale = 0;
        Player.PlayerRb.AddForce(Grab.direction *new Vector2(dashForce, dashForce), ForceMode2D.Impulse);
        Player.PlayerRb.gravityScale = Player.orginGravityScale;
    }
}
