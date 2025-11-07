using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "State/Player/Normal", fileName = "Normal_State")]
public class Normal_State : PlayerState
{
    public override void Enter()
    {
        Debug.Log("Enter Normal_State");
    }
    public override void Exit()
    {
        Debug.Log("Exit Normal_State");
    }
}
