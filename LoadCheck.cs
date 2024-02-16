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
        Debug.Log("isLoad:" + hasLoad);
        if(hasLoad){
            ;//执行着陆后的有关行为
            hasLoad=false;
        }
    }

    void loadCheck()
    {
       if(rb.velocity.y<0){
           isLoad=true;
       }
       if(isGroundCheck.isGround&&isLoad){
           hasLoad=true;
           isLoad=false;
       }
    }
}
