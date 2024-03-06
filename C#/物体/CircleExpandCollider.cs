using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleExpandCollider : MonoBehaviour
{
    [Tooltip("�����ĵ�����С")]
    public float baseBounceForce;
    [Tooltip("�ٶȳ���,�ٶȶԵ�����Ӱ��̶�")]
    public float speedMultiplier = 1f;

    CircleCollider2D largeCollder;
    private void Start()
    {
        largeCollder = GameObject.Find("CircleCheck").GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        //Debug.Log("Player.magnitude:" + Player.PlayerRb.velocity.magnitude);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCheck_1") && Player.PlayerSr.color == Color.yellow)
        {
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            Player.PlayerRb.AddForce(direction * baseBounceForce, ForceMode2D.Impulse);
        }
    }
}
