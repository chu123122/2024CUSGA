using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    #region 抓取参数
    [Tooltip("抓取速度")]
    public float grabForce;
    #endregion

    public static int grabMount = 1;
    public static bool oneTouchWall = false;
    public static bool oneTouchDashCircle = false;
    public static Vector3 direction;
    private bool hadGrab = false;
   
    CircleAutoGrabCheck circleAutoGrabCheck;// = GameObject.Find("RaycastHitCheck").GetComponent<CircleAutoGrabCheck>();
    private void Update()
    {
        circleAutoGrabCheck = GameObject.Find("RaycastHitCheck").GetComponent<CircleAutoGrabCheck>();

        //Debug.Log("autoState:" + circleAutoGrabCheck.autoState());
        grabCheck();
        GrabEffect();  
        GrabAddforce();
    }
    public void grabCheck()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        direction = (targetPosition - Player.PlayerTf.position).normalized;
    }

    
    public void GrabAddforce()
    {
       
        
        if (hadGrab)
        {
            GetComponent<Move>().enabled = true;
            hadGrab = false;
        }
        #region 抓取墙壁
        if (Input.GetMouseButtonDown(0)&&!PlayerCollisionCheck.PlayerTouchWall && GrabCheck.touchWall && RaycastHit.hitWall&&grabMount > 0)
        {

            print("GrabWall");
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            GetComponent<Move>().enabled = false;     
            Player.PlayerRb.AddForce(direction * grabForce * 100, ForceMode2D.Force);
            grabMount = 0;          
        }
        else if (PlayerCollisionCheck.PlayerTouchWall && !oneTouchWall)
        {       
            print("Return");
            GetComponent<Move>().enabled = true;
            Player.PlayerRb.velocity = Vector2.zero;
            oneTouchWall = true;
            hadGrab = true;
        }

        #endregion

        #region 抓取冲刺球
        if (Input.GetMouseButtonDown(0) && !PlayerCollisionCheck.PlayerTouchCircle && GrabCheck.touchDashCircle&& CircleAutoGrabCheck.isAutoTouch)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            GetComponent<Move>().enabled = false;
            direction = (CircleAutoGrabCheck.CirclePosition-Player.PlayerTf.position).normalized;
            Player.PlayerRb.AddForce(direction * grabForce * 100, ForceMode2D.Force);
            grabMount = 0;

            hadGrab = true;
        }
        else if (PlayerCollisionCheck.PlayerTouchCircle )
        {
            print("233");
            GetComponent<Move>().enabled = true;
            Player.PlayerRb.velocity = Vector2.zero;
        }
        #endregion
    }
    public void GrabEffect()
    {
        if (grabMount == 0&& !PlayerState_DashCircle_0.isBulletTimeActive&&!PlayerCollisionCheck.touchWallZero)
        {
            print("4");
            Player.PlayerRb.gravityScale = Player.orginGravityScale;
        }
    }
}
