using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    #region 镜头偏移参数

    [Tooltip("x轴偏移")]
    public float x;
    [Tooltip("y轴偏移")]
    public float y;
    #endregion

    Vector3 offer;

    void Start()
    {
        offer = transform.position - Player.PlayerTf.transform.position;
    }
    void Update()
    {
        transform.position = Player.PlayerTf.transform.position + offer + new Vector3(x, y, 0);
    }
}
