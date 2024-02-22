using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class circlePosition: MonoBehaviour
{
    //«ÚÃÂ‘≠Œª÷√
    Transform Circle;
    public static List<Vector3> CirclePosition = new List<Vector3>();
    private void Start()
    {
        Circle = GetComponent<Transform>();
    }

}
