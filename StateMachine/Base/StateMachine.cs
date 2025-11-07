using UnityEngine;
public class StateMachine : MonoBehaviour
{
    protected IState currenntState;
    private void Update()
    {
        currenntState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currenntState.PhysicUpdate();
    }
    /// <summary>
    /// ??????
    /// </summary>
    /// <param name="newState"></param>
    protected void SwitchOn(IState newState)
    {
        currenntState = newState;
        currenntState.Enter();
    }
    /// <summary>
    /// ?????
    /// </summary>
    /// <param name="newState"></param>
    protected void SwitchState(IState newState)
    {
        currenntState.Exit();
        SwitchOn(newState);
    }
}
