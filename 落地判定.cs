using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 落地判定 : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isLoad;//正在落地
    private bool hasLoad;//已经落地

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        loadCheck();
        // Debug.Log("dashMount:" + Dash.dashMount);
        if (hasLoad)
        {
            Grab.grabMount = 1;//抓取次数重置
            Dash.dashMount = 1;//冲刺次数重置
            Grab.oneTouchWall = false;
            hasLoad = false;
        }
        if (IsGroundCheck.isGround)
        {
            Dash.dashMount = 1;
        }
    }

    void loadCheck()
    {
        if (rb.velocity.y < 0)
        {
            isLoad = true;
        }
        if (IsGroundCheck.isGround && isLoad)
        {
            hasLoad = true;
            isLoad = false;
        }
    }
}
