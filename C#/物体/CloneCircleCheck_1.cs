using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCircleCheck_1 : MonoBehaviour
{
    Collider2D Circle;
    private void Start()
    {
        Circle = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCheck_1"))
        {
            Circle.isTrigger = true;
        }
        else
        {
            Circle.isTrigger = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCheck_1"))
        {
            Circle.isTrigger = true;
        }
        else
        {
            Circle.isTrigger = false;
        }
    }
}
