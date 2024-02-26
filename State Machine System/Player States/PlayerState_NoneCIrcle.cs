using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/NoneCIrcle", fileName = "PlayerState_NoneCIrcle")]
public class PlayerState_NoneCIrcle : PlayerState
{
    public override void Enter()
    {
        Debug.Log("Enter NoneCIrcle");
    }
    public override void Exit()
    {
        Debug.Log("Exit NoneCIrcle");
    }
}
