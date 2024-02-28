using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDashCircle : MonoBehaviour
{
    PlayerState_DashCircle_1 dashCircle_1;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rb;
    private bool isMoving = true;
    private int instantiateMount = 1;
    private void Start()
    {
        dashCircle_1 = GameObject.Find("Player").GetComponent<PlayerStateMachine>().dashState_1;
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb = PlayerState_DashCircle_1.cloneSphereHit.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Player.PlayerSr.color == Color.yellow)
        {
            circleCollider2D.isTrigger = false;
        }
        else if (Player.PlayerSr.color == Color.white&& rb.velocity.magnitude<= dashCircle_1.isTiggeredSpeed)
        {
            circleCollider2D.isTrigger = true;
            gameObject.tag = "DashCircle";
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region 
        if (collision.CompareTag("Player"))
        {
            PlayerState_DashCircle_0.dashMount += 1;
            Destroy(gameObject);

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
       
        //Debug.Log("magnitude " + rb.velocity.magnitude);
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
}
