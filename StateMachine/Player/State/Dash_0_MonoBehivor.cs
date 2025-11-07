using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_0_MonoBehivor : MonoBehaviour
{
    private static Dash_0_MonoBehivor instance;

    public static Dash_0_MonoBehivor Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
