using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleAutoGrabCheck : MonoBehaviour
{
    #region 判定参数
    public int segments = 50; // 扇形的线段数
    public float radius = 1f; // 扇形的半径
    public float startAngle = 45f;
    public float endAngle = -45f;
    #endregion

    public static bool isAutoTouch = false;
    void Update()
    {
        UpdateCollider();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void UpdateCollider()
    {
        PolygonCollider2D polyCollider = GetComponent<PolygonCollider2D>();
        float angleDelta = (endAngle - startAngle) / segments;
        Vector2[] points = new Vector2[segments + 2];
        for (int i = 0; i <= segments; i++)
        {
            float angle = Mathf.Deg2Rad * (startAngle + angleDelta * i);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            points[i] = new Vector2(x, y);
        }
        points[segments + 1] = Vector2.zero;
        polyCollider.points = points;
    }
    public static Vector3 CirclePosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("DashCircle")&&!isAutoTouch))
        {
            GameObject DashCircle = collision.gameObject;
            SpriteRenderer spriteRenderer = DashCircle.GetComponent<SpriteRenderer>();

            spriteRenderer.color = Color.green;
            CirclePosition = DashCircle.transform.parent.TransformPoint(DashCircle.transform.localPosition);
            //Debug.Log("CirclePosition" + CirclePosition);
            isAutoTouch = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DashCircle"))
        {
            GameObject DashCircle = collision.gameObject;
            SpriteRenderer spriteRenderer = DashCircle.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.yellow;
            isAutoTouch = false;
        }
    }
}
