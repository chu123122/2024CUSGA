using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDashCheck : MonoBehaviour
{
    public static bool wallDash = false;
    public static bool isRight;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            wallDash = true;
            isRight = collision.transform.position.x > Player.PlayerTf.position.x ? true : false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            wallDash = false;
        }
    }
}
