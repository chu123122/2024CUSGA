using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerCollisionCheck :MonoBehaviour 
{
    public static bool PlayerTouchWall;
    public static bool PlayerTouchCircle;
    public float time=0.5f;
    bool first = true;
    private  void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall"))
        {
            PlayerTouchWall = true;
        }
        if (collider.CompareTag("DashCircle")&&Player.PlayerSr.color == Color.white)
        {
            DateTime DashTime = DateTime.Now;
            TimeSpan timeDifference = DashTime - PlayerState_DashCircle_1.ShotTime;
            if (timeDifference.TotalSeconds <time)
                first = false;
            else
                first = true;
            print("2");
            if (first)
            {
                PlayerTouchCircle = true;
                collider.gameObject.SetActive(false);
                PlayerState_DashCircle_0.dashMount = 1;

            }
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
