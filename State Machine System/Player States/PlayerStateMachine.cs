using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public  PlayerState_DashCircle_0 dashState_0;
    public  PlayerState_DashCircle_1 dashState_1;
    public PlayerState_NoneCIrcle noneState;
    private void Awake()
    {
        //≥ı ºªØ
        dashState_0.Initialize(this);
        dashState_1.Initialize(this);
        noneState.Initialize(this);
    }
    private void Start()
    {
        SwitchOn(noneState);
    }
    private void Update()
    {
        if (PlayerCollisionCheck.PlayerTouchCircle)
        {
            SwitchState(dashState_0);
        }else if (!PlayerState_DashCircle_0.isBulletTimeActive)
        {
            SwitchState(dashState_1);
        }
        currenntState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currenntState.PhysicUpdate();
    }
}
