
public interface IState
{
    /// <summary>
    /// 进入状态时执行的函数
    /// </summary>
    void  Enter();
    /// <summary>
    /// 退出状态时执行的函数
    /// </summary>
    void Exit();
    /// <summary>
    /// 在该状态中的Update函数
    /// </summary>
    void LogicUpdate();
    /// <summary>
    /// 在该状态中的FixtedUpdate函数
    /// </summary>
    void PhysicUpdate();
}
