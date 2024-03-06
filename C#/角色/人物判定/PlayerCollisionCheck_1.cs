using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck_1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            print("Wall!!!!");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button down");
                PlayerCollisionCheck.touchWallZero = true;
                Player.PlayerRb.gravityScale = 0;
                Player.PlayerRb.velocity = Vector2.zero;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Mouse button held down");
                PlayerCollisionCheck.touchWallZero = true;
                Player.PlayerRb.gravityScale = 0;
                Player.PlayerRb.velocity = Vector2.zero;
            }
             if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse button released");
                PlayerCollisionCheck.touchWallZero = false;
                Player.PlayerRb.gravityScale = Player.orginGravityScale;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Debug.Log("Player left the wall");
            PlayerCollisionCheck.touchWallZero = false;
            Player.PlayerRb.gravityScale = Player.orginGravityScale;
        }
    }
}
