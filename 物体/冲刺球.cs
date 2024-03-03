using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle: MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    Transform circle;//球体原位置
    public static List<string> CircleName = new List<string>();
    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        circle = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Player.PlayerSr.color == Color.yellow)
        {
            circleCollider2D.isTrigger = false;
        }
        else if((Player.PlayerSr.color == Color.white))
        {
            circleCollider2D.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region 存储球体名字和反激活
        if (collision.CompareTag("Player"))
        {
            //PlayerState_DashCircle_0.dashMount += 1;
            CircleName.Add(circle.gameObject.name);// 存储球体名字到列表中
            //Debug.Log("name:" + circle.gameObject.name);
            gameObject.SetActive(false);
            
        }
        #endregion
    }
}
