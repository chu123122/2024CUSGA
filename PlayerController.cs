using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private PlayerState currentState;
  //  DistalPulling distalPulling;

    private void Start()
    {
        // 初始状态为站立状态
        TransitionToState(new PlayerIdleState());
      //  distalPulling = gameObject.AddComponent<DistalPulling>();
    }

    private void Update()
    {
        // 根据玩家输入更新状态
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransitionToState(new PlayerJumpState());
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            TransitionToState(new PlayerWalkState());
        }else if (Input.GetMouseButtonDown(0))
        {
            TransitionToState(new PlayerDashState());
        }

        // 执行当前状态的行为
        currentState.UpdateState();
       // Debug.Log("side:" + distalPulling.side);
    }
    public void TransitionToState(PlayerState state)
    {
        // 切换到新的状态
        currentState = state;
        currentState.EnterState(this);
    }

    public abstract class PlayerState
    {
        protected PlayerController playerController;

        public abstract void EnterState(PlayerController playerController);
        public abstract void UpdateState();
    }

    // 站立状态
    public class PlayerIdleState : PlayerState
    {
        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void UpdateState()
        {
            // 站立状态下的行为
            Debug.Log("Player is idle.");
        }
    }
     
    // 行走状态
    public class PlayerWalkState : PlayerState
    {
        private Move moveComponent;
        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
            moveComponent = playerController.GetComponent<Move>();
        }

        public override void UpdateState()
        {
            // 行走状态下的行为
            moveComponent.Walk();
        }
    }

    // 跳跃状态
    public class PlayerJumpState : PlayerState
    {
        private Jump jumpComponent;

        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
            jumpComponent = playerController.GetComponent<Jump>();
        }

        public override void UpdateState()
        {
            // 跳跃状态下的行为
            jumpComponent.Jumping();
        }
    }

    // 冲刺状态
    public class PlayerDashState : PlayerState
    {
        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void UpdateState()
        {
            // 冲刺状态下的行为
            Debug.Log("Player is dashing.");
        }
    }

}
