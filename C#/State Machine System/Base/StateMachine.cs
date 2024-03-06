using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState currenntState;
    void Update()
    {
        currenntState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currenntState.PhysicUpdate();
    }
    protected void SwitchOn(IState newState)
    {
        currenntState = newState;
        currenntState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currenntState.Exit();
        SwitchOn(newState);
    }
}
