using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject PlayerGo;
    public static Rigidbody2D PlayerRb;
    public static Transform PlayerTf;
    public static CircleCollider2D PlayerCo;
    public static float orginGravityScale;//≥ı º÷ÿ¡¶


    private void Awake()
    {
        PlayerGo = gameObject;
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerTf = transform;
        PlayerCo = GetComponent<CircleCollider2D>();
        orginGravityScale=PlayerRb.gravityScale;
    }



}

