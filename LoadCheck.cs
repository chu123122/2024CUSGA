using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheck : MonoBehaviour
{
    public Rigidbody2D rb;
    public static bool isLoad;
    bool hasLoad;
    bool spawnDust;

    private void Update()
    {
        loadCheck();
        Debug.Log("isLoad:" + isLoad);
    }

    void loadCheck()
    {
       
    }
}
