using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundCheck : MonoBehaviour
{
    public static bool isGround;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (/*(other.gameObject.CompareTag("Wall")&& other.transform.parent.name=="Ground") ||*/ other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (/*(other.gameObject.CompareTag("Wall") && other.transform.parent.name == "Ground")||*/ other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
