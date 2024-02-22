using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class dashCircle : MonoBehaviour
{
    //�ӵ�ʱ��ĳ���ʱ��
    public  float bulletTime=0.5f;
    public static float bulletTimeCounter;
    private bool isBulletTimeActive = false;

    // �ӵ�ʱ���ʱ�����ű���
    public float bulletTimeScale;

    public Rigidbody2D rb;
    private float orginGravityScale = 5.0f;
    Dash dash;

    //ʰȡ�����ı仯
    public static int circleDashMount=0;

    //��������
    GameObject cloneSphere;
    public GameObject spherePrefab; // Ԥ������
    public GameObject Player; // ���
    public static int cloneCount=0;//��¡������

   
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
        // ���ÿ�¡����Ĵ�С
        createCloneSphere.transform.localScale = Player.transform.localScale * 0.5f;

        // ���ÿ�¡�������ʾ�㼶
        SpriteRenderer spriteRenderer = createCloneSphere.GetComponent<SpriteRenderer>();

        // ������Ⱦ�����ʾ˳��
        spriteRenderer.sortingLayerName = "Default"; // �滻Ϊ������Ⱦ������
        spriteRenderer.sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        cloneCount =1;
        return createCloneSphere;
    }
    private void OnTriggerEnter2D(Collider2D other)//�����ײ���
    {
        if (other.CompareTag("DashCircle"))
        {
            print("Enter");
            Destroy(other.gameObject);//����ԭ������
            if (cloneCount == 0)
            {
                cloneSphere = CreateCloneSphere();//�������������Ӱ
            }
            circleDashMount += 1;
            Dash.dashButtonMount = 1;
            //�����ӵ�ʱ��
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


    //����
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

