using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private PlayerState currentState;
  //  DistalPulling distalPulling;

    private void Start()
    {
        // ��ʼ״̬Ϊվ��״̬
        TransitionToState(new PlayerIdleState());
      //  distalPulling = gameObject.AddComponent<DistalPulling>();
    }

    private void Update()
    {
        // ��������������״̬
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

        // ִ�е�ǰ״̬����Ϊ
        currentState.UpdateState();
       // Debug.Log("side:" + distalPulling.side);
    }
    public void TransitionToState(PlayerState state)
    {
        // �л����µ�״̬
        currentState = state;
        currentState.EnterState(this);
    }

    public abstract class PlayerState
    {
        protected PlayerController playerController;

        public abstract void EnterState(PlayerController playerController);
        public abstract void UpdateState();
    }

    // վ��״̬
    public class PlayerIdleState : PlayerState
    {
        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void UpdateState()
        {
            // վ��״̬�µ���Ϊ
            Debug.Log("Player is idle.");
        }
    }
     
    // ����״̬
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
            // ����״̬�µ���Ϊ
            moveComponent.Walk();
        }
    }

    // ��Ծ״̬
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
            // ��Ծ״̬�µ���Ϊ
            jumpComponent.Jumping();
        }
    }

    // ���״̬
    public class PlayerDashState : PlayerState
    {
        public override void EnterState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void UpdateState()
        {
            // ���״̬�µ���Ϊ
            Debug.Log("Player is dashing.");
        }
    }

}
