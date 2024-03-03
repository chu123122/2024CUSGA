using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.SceneManagement;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash_1", fileName = "PlayerState_DashCircle_1")]
public class PlayerState_DashCircle_1 : PlayerState
{
    #region 发射球的相关数据
    [Tooltip("发射的克隆球体预制体")]
    public GameObject spherePrefab;
    [Tooltip("发射的克隆球体开始碰撞判定预制体")]
    public GameObject spherePrefabFirstCheck;
    [Tooltip("球体消失的时间")]
    public float saveTime = 1.0f;
    [Tooltip("球体的发射速度")]
    public float circleHitForce = 3f;
    [Tooltip("球体速度低于多少时可触发")]
    public float isTiggeredSpeed=5f;
    [Tooltip("冲刺力度")]
    public float dashForce;
    [Tooltip("速度控制器")]
    public bool speedController;
    [Tooltip("水平速度")]
    public  float xSpeed;
    [Tooltip("垂直速度")]
    public  float ySpeed;
    [Tooltip("判定范围控制")]
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
        #region 丢球和施力
        if (Input.GetMouseButtonDown(1) )//&& Player.PlayerSr.color == Color.yellow)
        {
            Debug.Log("BUtton");
            AddForce();
            Launch();
            Player.PlayerSr.color = Color.white;
        }
        #endregion
    }
    void Launch()//发射球体
    {
        Vector2 playerEdgePosition = Player.PlayerCo.ClosestPoint(Player.PlayerTf.position);// 边缘位置
        cloneSphereHit = Instantiate(spherePrefab, Player.PlayerTf.position, Quaternion.identity);
       // GameObject cloneCheck = Instantiate(spherePrefabFirstCheck, Player.PlayerTf.position, Quaternion.identity);
        //cloneCheck.transform.parent = cloneSphereHit.transform;

        #region 克隆体初始化
        Transform parentTransform = GameObject.Find("DashCircle").transform;
        cloneSphereHit.transform.SetParent(parentTransform);
        cloneSphereHit.name = "dashCircle" + i.ToString()+"(Clone)";
        cloneSphereHit.tag = "DashCircle";
        i += 1;
        cloneSphereHit.AddComponent<CloneDashCircle>();
        saveTimeConller = saveTime;
        #endregion

        Rigidbody2D cloneSphereRb = cloneSphereHit.GetComponent<Rigidbody2D>();

        #region  获取球体发射方向
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mouseDirection = (mouseWorldPosition - Player.PlayerTf.position).normalized;
        Vector3 negativeMouseDirection = -mouseDirection;
        #endregion

        #region 发射球体前后的碰撞变化
        CircleCollider2D cloneCollider = cloneSphereHit.GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(cloneCollider, Player.PlayerTf.GetComponent<CircleCollider2D>(), true);// 在发射前忽略碰撞
        cloneSphereRb.AddForce(negativeMouseDirection * circleHitForce, ForceMode2D.Impulse);

        ShotTime = DateTime.Now;//记录发生时间

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
