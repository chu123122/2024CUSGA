using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleAutoGrabCheck : MonoBehaviour
{
    #region 判定参数
    [Tooltip("进入和离开判定的角度")]
    public float angle;
    [Tooltip("离开判定的额外角度")]
    public float extraAngle;
    #endregion
    private void Update()
    {
        RaycastDraw();
        RaycastHitCheck();
    }
    void RaycastDraw()//画线
    {
        #region 生成线

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - Player.PlayerTf.position).normalized;
        #endregion

        Debug.DrawLine(Player.PlayerTf.position, (Quaternion.Euler(0, 0, angle) * direction) * 1000f, Color.green, 0.001f);
        Debug.DrawLine(Player.PlayerTf.position, (Quaternion.Euler(0, 0, angle+ extraAngle) * direction) * 1000f, Color.black, 0.001f);
        Debug.DrawLine(Player.PlayerTf.position, (Quaternion.Euler(0, 0, -angle) * direction) * 1000f, Color.green, 0.001f);
        Debug.DrawLine(Player.PlayerTf.position, (Quaternion.Euler(0, 0, -angle - extraAngle) * direction) * 1000f, Color.black, 0.001f);
    }
    void RaycastHitCheck()//射线碰撞检测
    {
        #region 生成线

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - (Vector3)Player.PlayerTf.position).normalized;

        #region 线1
        RaycastHit2D hit1_0 = Physics2D.Raycast(Player.PlayerTf.position, (Quaternion.Euler(0, 0, angle) * direction) * 1000f,
            Mathf.Infinity, ~(1 << Player.PlayerCo.gameObject.layer));
        RaycastHit2D hit1_1 = Physics2D.Raycast(Player.PlayerTf.position, (Quaternion.Euler(0, 0, angle+ extraAngle) * direction) * 1000f,
            Mathf.Infinity, ~(1 << Player.PlayerCo.gameObject.layer));
        SpriteRenderer spriteRenderer1_0 = hit1_0.collider.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer1_1 = hit1_1.collider.GetComponent<SpriteRenderer>();
        #endregion

        #region 线2
        RaycastHit2D hit2_0 = Physics2D.Raycast(Player.PlayerTf.position, (Quaternion.Euler(0, 0, -angle) * direction) * 1000f,
            Mathf.Infinity, ~(1 << Player.PlayerCo.gameObject.layer));
        RaycastHit2D hit2_1 = Physics2D.Raycast(Player.PlayerTf.position, (Quaternion.Euler(0, 0, -angle- extraAngle) * direction) * 1000f,
            Mathf.Infinity, ~(1 << Player.PlayerCo.gameObject.layer));
        SpriteRenderer spriteRenderer2_0 = hit2_0.collider.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2_1 = hit2_1.collider.GetComponent<SpriteRenderer>();
        #endregion

        #endregion


        Debug.Log("spriteRenderer1:" + spriteRenderer1_0.color);

        if (hit1_0.collider.CompareTag("DashCircle") && spriteRenderer1_0.color!= Color.green&& !hit1_1.collider.CompareTag("DashCircle"))
        {
            spriteRenderer1_0.color = Color.green;
        }
        else if (hit1_1.collider.CompareTag("DashCircle") && spriteRenderer1_1.color == Color.green)
        {
            spriteRenderer1_1.color = Color.yellow;
        }

        if (hit2_0.collider.CompareTag("DashCircle") && spriteRenderer2_0.color != Color.green && !hit2_1.collider.CompareTag("DashCircle"))
        {
            spriteRenderer2_0.color = Color.green;
        }
        else if (hit2_1.collider.CompareTag("DashCircle") && spriteRenderer2_1.color == Color.green)
        {
            spriteRenderer2_1.color = Color.yellow;
        }
    }
}
