using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPulling: MonoBehaviour
{
    DistalPulling distalPulling;
    public Transform Player;
    public Rigidbody2D rb;
    public float moveSpeed;

    public float radius = 5f;//�����ж�
    private CircleCollider2D circleCollider;
    public CircleCollider2D playerCollider;
    bool touchWall;
    bool touchIronWall;
    private void Start()
    {
        distalPulling = GetComponent<DistalPulling>();
        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.radius = radius;
    }

    private void Update()
    {
        circleCollider.radius = radius;

        Mouse();

        if (touchWall&&Input.GetMouseButtonDown(0))
        {
            ProcessMouseClick();

        }else if (touchIronWall && Input.GetMouseButtonDown(0))
        {
            ProcessMouseClick();
             //�෴����
        }

        Debug.Log("touchWall:" + touchWall);
    }

    void Mouse()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;

        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);

        
        Vector2 direction = (targetPosition - (Vector3)Player.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.position, direction, ~(1 << playerCollider.gameObject.layer));
       
        Debug.DrawLine(Player.position, direction * 1000f, Color.red, 0.01f);
        
    }

    void ProcessMouseClick()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;

        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);

        
        Vector2 direction = (targetPosition - (Vector3)Player.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.position, direction, Mathf.Infinity, ~(1 << playerCollider.gameObject.layer));
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            Debug.Log("Hit Wall: " + hit.collider.gameObject.name);
            MoveToWall(targetPosition);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // �����ײ���Ӵ���ͨǽ
        if (other.CompareTag("Wall"))
        {
            touchWall = true;
        }
        // �����ײ���Ӵ���ǽ
        if (other.CompareTag("IronWall"))
        {
            touchWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // �����ײ���뿪��ͨǽ
        if (other.CompareTag("Wall"))
        {
            touchWall = false;
        }
        // �����ײ���뿪��ǽ
        if (other.CompareTag("IronWall"))
        {
            touchWall = false;
        }
    }

    void MoveToWall(Vector3 targetPosition)
    {
        
        Vector2 moveDirection = (targetPosition - Player.position).normalized;

        
        rb.AddForce (moveDirection * moveSpeed, ForceMode2D.Impulse);

       
    }
}
