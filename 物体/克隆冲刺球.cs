using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CloneDashCircle : MonoBehaviour
{
    PlayerState_DashCircle_1 dashCircle_1;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rb;
    private bool isMoving = true;
    private int instantiateMount = 1;
    public static float length = 1;
    private void Start()
    {
        dashCircle_1 = GameObject.Find("Player").GetComponent<PlayerStateMachine>().dashState_1;
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb = PlayerState_DashCircle_1.cloneSphereHit.GetComponent<Rigidbody2D>();
    }
    bool isTrigger = false;
    private void FixedUpdate()
    {
        if(isTrigger_1&&isTrigger&&isTrigger_2)
            circleCollider2D.isTrigger = true;
        else
            circleCollider2D.isTrigger = false;
            TriggerCheck();
    }
    private void Update()
    {
        Debug.Log("isTrigger:" + isTrigger);
        Vector3 newVelocity = new Vector3(dashCircle_1.xSpeed, dashCircle_1.ySpeed, 0);
        if(dashCircle_1.speedController)
            rb.velocity = newVelocity;

        Vector3 startPosition = rb.transform.parent.TransformPoint(rb.transform.localPosition);
        Vector2 direction = rb.velocity.normalized;
        float rayLength = rb.velocity.magnitude * Time.deltaTime;
        // 发射射线
        int layerMask_0 = (1 << gameObject.layer);// | (1 << LayerMask.NameToLayer("PlayerCheck"));
        int layerMask= ~(layerMask_0);
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, 1, layerMask);
        Debug.DrawRay(startPosition, direction *1, Color.red, 0.001f);

         #region 触发器激活判定
         if (hit.collider!=null&&isMoving&& !hit.collider.CompareTag("Player")&&!hit.collider.CompareTag("PlayerCheck"))
         {
            isTrigger_2 = false;
         }
         if (hit.collider != null)
         {
             if (!isMoving || hit.collider.CompareTag("Player"))
             {
                isTrigger_2 = true;
             }
         }

         #endregion
        #region 减速判定及销毁和恢复
        if (isMoving)
        {
            Decelerate();
        }  
        else
        {
            #region 减少克隆体存在时间，时间归零后销毁克隆体
            dashCircle_1.saveTimeConller -= Time.deltaTime;
            if (dashCircle_1.saveTimeConller <= 0)
            {
                print("Destroy");
                Destroy(gameObject);
                PlayerState_DashCircle_1.i-=1;
                instantiateMount -= 1;
                isMoving = true;
                if (instantiateMount == 0)
                    Origin();

                dashCircle_1.saveTimeConller = dashCircle_1.saveTime;
            }
            #endregion

        }
        #endregion

    }
 
    void Decelerate()//球体速度判定
    {
        #region 球体速度低于一定程度速度归零
        if (PlayerState_DashCircle_1.cloneSphereHit == null)
        {
            return;
        }
       
        if (rb.velocity.magnitude <= 0.5f)
        {
            rb.velocity = Vector3.zero;
            isMoving = false;
        }
        #endregion
    }
    void Origin()
    {
        #region 激活球体
        if (Circle.CircleName.Count > 0)
            {
                string lastName = Circle.CircleName[Circle.CircleName.Count - 1];// 获取最后一个
                GameObject parentObj = GameObject.Find("DashCircle");
                GameObject lastObject = parentObj.transform.Find(lastName).gameObject;
                if (lastObject != null)
                {
                    Circle.CircleName.RemoveAt(Circle.CircleName.Count - 1);
                    lastObject.SetActive(true);
                    instantiateMount += 1;
                }
            }
        #endregion

    }
    void TriggerCheck()
    {
        Vector2 center = transform.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, 0.6f);
        bool first=false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player")&& Player.PlayerSr.color == Color.white)
            {
                print("Player!");
                isTrigger = true;
                #region
                DateTime DashTime = DateTime.Now;
                TimeSpan timeDifference = DashTime - PlayerState_DashCircle_1.ShotTime; 
                if (timeDifference.TotalSeconds < 0.5f)
                    first = false;
                else
                    first = true;
                if (first)
                {
                    PlayerState_DashCircle_0.dashMount=1;
                    gameObject.SetActive(false);
                    PlayerCollisionCheck.PlayerTouchCircle = true;
                }
                    
                #endregion
            }
            else if (collider.CompareTag("Wall") || collider.CompareTag("Ground"))
            {
                print("Wall!");
                isTrigger = false;
            }
        }
    }
    bool isTrigger_1 = false;
    bool isTrigger_2 = false;
    bool two=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            isTrigger_1 = false;
        }
        else if (collision.CompareTag("PlayerCheck_1")&&Player.PlayerSr.color==Color.white)
        {
            isTrigger_1 = true;
            DateTime DashTime = DateTime.Now;
            TimeSpan timeDifference = DashTime - PlayerState_DashCircle_1.ShotTime;
            if (timeDifference.TotalSeconds < 0.5f)
                two = false;
            else
                two = true;
            if (two)
            {
                PlayerState_DashCircle_0.dashMount = 1;
                gameObject.SetActive(false);
                PlayerCollisionCheck.PlayerTouchCircle = true;
            }
        }
    }
}
