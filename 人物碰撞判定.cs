using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    public static bool PlayerTouchWall;
    public static bool PlayerTouchCircle;

    private void Update()
    {
        //Debug.Log("PlayerTouchCircle:" + PlayerTouchCircle);
        //Debug.Log("dashMount:" + PlayerState_DashCircle_0. dashMount);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall"))
        {
            PlayerTouchWall = true;
        }
        if (collider.CompareTag("DashCircle")&&Player.PlayerSr.color == Color.white)
        {
            PlayerTouchCircle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall"))
        {
            PlayerTouchWall = false;
        }
    }
}
