using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float speed = 0.01f;
    private void LateUpdate()
    {
        transform.position+=new Vector3(speed,0,0);
    }
}
