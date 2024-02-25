using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMachine : MonoBehaviour
{

    private PlayerState currentState;
    Dash dash;
    //  DistalPulling distalPulling;
    #region 状态初始化
    private void Start()
    {
        // 初始状态为站立状态
        TransitionToState(new PlayerIdleState());
        dash = gameObject.AddComponent<Dash>();

        //  distalPulling = gameObject.AddComponent<DistalPulling>();
    }
    #endregion

    #region 更新状态模式
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            TransitionToState(new PlayerGrabState());
        }

        // 执行当前状态的行为
        currentState.UpdateState();
        // Debug.Log("side:" + distalPulling.side);
    }
    #endregion

    #region 切换模式函数
    public void TransitionToState(PlayerState state)
    {
        // 切换到新的状态
        currentState = state;
        currentState.EnterState(this);
    }
    #endregion

    #region 状态类
    public abstract class PlayerState
    {
        protected PlayMachine playMachine;

        public abstract void EnterState(PlayMachine playMachine);
        public abstract void UpdateState();
    }
    #endregion

    #region 模式
    // 初始状态
    public class PlayerIdleState : PlayerState
    {
        public override void EnterState(PlayMachine playMachine)
        {
            this.playMachine = playMachine;
        }

        public override void UpdateState()
        {
            // 站立状态下的行为
            Debug.Log("Player is idle.");
        }
    }

    // 抓取状态
    public class PlayerGrabState : PlayerState
    {
        private Grab GrabComponet;

        public override void EnterState(PlayMachine playMachine)
        {
            this.playMachine = playMachine;
            GrabComponet = playMachine.GetComponent<Grab>();
        }

        public override void UpdateState()
        {
            // 抓取状态下的行为
            GrabComponet.grabCheck();
            GrabComponet.GrabEffect();
            GrabComponet.GrabAddforce();

        }
    }

    // 冲刺状态
    public class PlayerDashState : PlayerState
    {
        public override void EnterState(PlayMachine playMachine)
        {
            this.playMachine = playMachine;
        }

        public override void UpdateState()
        {
            // 冲刺状态下的行为
            Debug.Log("Player is dashing.");
        }
    }
    #endregion 
}
