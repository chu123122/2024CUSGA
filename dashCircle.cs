using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class dashCircle : MonoBehaviour
{
    //子弹时间的持续时间
    public  float bulletTime=0.5f;
    public static float bulletTimeCounter;
    private bool isBulletTimeActive = false;

    // 子弹时间的时间缩放比例
    public float bulletTimeScale;

    public Rigidbody2D rb;
    private float orginGravityScale = 5.0f;
    Dash dash;

    //拾取弹珠后的变化
    public static int circleDashMount=0;

    //复制球体
    GameObject cloneSphere;
    public GameObject spherePrefab; // 预制球体
    public GameObject Player; // 玩家
    public static int cloneCount=0;//克隆体数量

   
    private void Start()
    {
        dash= GetComponent<Dash>();
        bulletTimeCounter = bulletTime;
    }
    private void Update()
    {
       // Debug.Log("bulletTimeCounter:" + bulletTimeCounter); 
       // Debug.Log("mouseSide:" + Dash.mouseSide);
        
    }

    private void FixedUpdate()
    {
        BulletTime();
        if (Dash.mouseSide != 0)
        {

            print("1");
            Time.timeScale = 1.0f;
            dash.DashButtonAddForce();
        }
        DestroyCloneSphere();
    }
    void DestroyCloneSphere()
    {
        if (cloneSphere != null)
        {
            if (dashCircle.circleDashMount != 0)
            {
            }
            else
            {
                 Destroy(cloneSphere);
                 cloneCount=0;
            }
        }
    }
   
    public GameObject CreateCloneSphere()
    {
        GameObject createCloneSphere = Instantiate(spherePrefab, Player.transform.position, Quaternion.identity);
        createCloneSphere.transform.parent = Player.transform;
        createCloneSphere.transform.localPosition = Vector3.zero;
        // 设置克隆球体的大小
        createCloneSphere.transform.localScale = Player.transform.localScale * 0.5f;

        // 设置克隆球体的显示层级
        SpriteRenderer spriteRenderer = createCloneSphere.GetComponent<SpriteRenderer>();

        // 设置渲染层和显示顺序
        spriteRenderer.sortingLayerName = "Default"; // 替换为您的渲染层名称
        spriteRenderer.sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        cloneCount =1;
        return createCloneSphere;
    }
    private void OnTriggerEnter2D(Collider2D other)//玩家碰撞检测
    {
        if (other.CompareTag("DashCircle"))
        {
            print("Enter");
            Destroy(other.gameObject);//销毁原来球体
            if (cloneCount == 0)
            {
                cloneSphere = CreateCloneSphere();//设置玩家体内虚影
            }
            circleDashMount += 1;
            Dash.dashButtonMount = 1;
            //进入子弹时间
            isBulletTimeActive = true;

            Vector3 positionToAdd = other.transform.position;
            print("Storing position: " + positionToAdd);
            circlePosition.CirclePosition.Add(positionToAdd);


        }
    }
    void BulletTime()
    {

        if (isBulletTimeActive)
            Time.timeScale = bulletTimeScale;
        else
        {
            Time.timeScale = 1.0f;
            bulletTimeCounter = bulletTime;
        }
        if (isBulletTimeActive && bulletTimeCounter > 0)
        {
            bulletTimeCounter -= Time.deltaTime;
            dash.DashButtonCheck();

            if (Dash.mouseSide == 0)
                rb.gravityScale = orginGravityScale;
            else
            {
                rb.gravityScale = 0f;
                isBulletTimeActive = false;
            }


        }
        else if (isBulletTimeActive&&bulletTimeCounter <= 0)
        {
            isBulletTimeActive = false;
            Time.timeScale = 1.0f;
            bulletTimeCounter = bulletTime;
        }

        
    }


    //测试
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

