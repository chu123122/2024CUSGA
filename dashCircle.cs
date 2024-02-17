using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashCircle : MonoBehaviour
{
    //子弹时间的持续时间
    public float bulletTime;
    private float bulletTimeCounter;
    private bool isBulletTimeActive = false;

    // 子弹时间的时间缩放比例
    public float bulletTimeScale;

    public Rigidbody2D rb;
    private float orginGravityScale = 5.0f;
    Dash dash;
    private void Start()
    {
        dash= GetComponent<Dash>();
        bulletTimeCounter = bulletTime;
    }
    private void Update()
    {
       // Debug.Log("bulletTimeCounter:" + bulletTimeCounter); 
        Debug.Log("mouseSide:" + Dash.mouseSide);
        BulletTime();
    }
    private void OnTriggerEnter2D(Collider2D other)//玩家碰撞检测
    {
        if (other.CompareTag("DashCircle"))
        {
            print("Enter");
            Destroy(other.gameObject);
            Dash.dashButtonMount = 1;
            //进入子弹时间
            isBulletTimeActive = true;
        }

    }
    void BulletTime()
    {
        if (isBulletTimeActive && bulletTimeCounter > 0)
        {
            Time.timeScale = bulletTimeScale;
            
            bulletTimeCounter -= Time.deltaTime;
            dash.DashButtonCheck();
            dash.DashButtonAddForce();
            if (Dash.mouseSide == 0)
            {
                rb.gravityScale = orginGravityScale;
            }
        }
        else if (bulletTimeCounter <= 0)
        {
            Time.timeScale = 1.0f;
            isBulletTimeActive = false;
            bulletTimeCounter = bulletTime;
        }
    }
    float t;
    float timeScale;
    void TimeScale()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            t = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            t += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0.2f, t);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            t = 1;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, t);
        }

    }
}
