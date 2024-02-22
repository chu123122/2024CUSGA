using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class dashCircleHit : MonoBehaviour
{
    public Rigidbody2D Player;
    public GameObject spherePrefab; // Ԥ������
    public GameObject OriginCircle;
    public float decelerationRate = 1f; // ����ļ�����
    public float disappearDelay = 3f; // ������ʧ���ӳ�ʱ��
    public float circleHitForce=3f;
    private GameObject cloneSphereHit;
    private bool isMoving = true;
    public float saveTime=1.0f;
    float saveTimeCollor;

    [HideInInspector] public static bool circleBack = false;
    public static int instantiateMount = 1;
    bool circleSaveColler = false;

    public CircleCollider2D playerCollider;
    //���俪ʼʱ�Ľ���
    public float time = 0.02f;
    float timeCollar;

    void Start()
    {
        timeCollar = time;
        saveTimeCollor = saveTime;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && dashCircle.cloneCount != 0)
        {
            print("Mouse1");
            Launch();
        }
        if (isMoving)
        {
            Decelerate();
        }
        else
        {
            saveTimeCollor -= Time.deltaTime;
            if (saveTimeCollor<=0)
            {
                //print("Destroy");
                if (cloneSphereHit != null)
                {
                    if (cloneQueue.Count > 0)
                    {
                        GameObject cloneToDestroy = cloneQueue.Dequeue(); 
                        Destroy(cloneToDestroy);
                    }
                    instantiateMount -= 1;
                    isMoving = true;
                }
                if (instantiateMount ==0)
                    Origin();
                if (circleSaveColler)
                {
                    circleBack = true;
                }
                circleSaveColler = false;
                saveTimeCollor = saveTime;
            }
        }
    }

    
    void Origin()
    {
        if (circlePosition.CirclePosition.Count > 0)
        {
            // ��ȡ���һ��λ��
            Vector3 lastPosition = circlePosition.CirclePosition[circlePosition.CirclePosition.Count - 1];

            // ��ʹ�ú���б����Ƴ����һ��λ��
            circlePosition.CirclePosition.RemoveAt(circlePosition.CirclePosition.Count - 1);
            Instantiate(OriginCircle, lastPosition, Quaternion.identity);
            instantiateMount += 1;
        }
        
    }
    private Queue<GameObject> cloneQueue = new Queue<GameObject>();
    void Launch()//��������
    {
        print("Put");
        Vector2 playerEdgePosition = playerCollider.ClosestPoint(ClearPulling.Player.position);// ��Եλ��
        cloneSphereHit = Instantiate(spherePrefab, ClearPulling.Player.position, Quaternion.identity);
        cloneQueue.Enqueue(cloneSphereHit);
        circleSaveColler = true;
         

        Rigidbody2D cloneSphereRb = cloneSphereHit.GetComponent<Rigidbody2D>();

        // ��ȡ��귴����
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 mouseDirection = (mouseWorldPosition - ClearPulling.Player.position).normalized;
        Vector3 negativeMouseDirection = -mouseDirection;

        CircleCollider2D cloneCollider = cloneSphereHit.GetComponent<CircleCollider2D>();
        // �ڷ���ǰ������ײ
        Physics2D.IgnoreCollision(cloneCollider, ClearPulling.Player.GetComponent<Collider2D>(), true);
        cloneSphereRb.AddForce(negativeMouseDirection * circleHitForce, ForceMode2D.Impulse);// һ��ʱ���ָ���ײ
        StartCoroutine(EnableCollisionAfterDelay());

        IEnumerator EnableCollisionAfterDelay()
        {
            yield return new WaitForSeconds(1.0f); // �ȴ�һ��ʱ��
            Physics2D.IgnoreCollision(cloneCollider, ClearPulling.Player.GetComponent<Collider2D>(), false); // �ָ���ײ
        }
    }

    void Decelerate()//��������
    {
        if (cloneSphereHit == null)
        {
            return;
        }
        Rigidbody2D rb = cloneSphereHit.GetComponent<Rigidbody2D>();
        //Debug.Log("magnitude " + rb.velocity.magnitude);
        if (rb.velocity.magnitude > 0.5f)
        {
            rb.velocity -= rb.velocity.normalized * decelerationRate * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
            isMoving = false;
        }
    }

    void OnCollisionEnter(Collision collision)//���巴��
    {
        // ���㷴�䷽��
        Rigidbody2D rb = cloneSphereHit.GetComponent<Rigidbody2D>();
        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflectedVelocity;
    }
}
