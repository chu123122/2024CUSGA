using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public  PlayerState_DashCircle_0 dashState_0;
    public  PlayerState_DashCircle_1 dashState_1;
    public PlayerState_NoneCIrcle noneState;
    public static float state = 0; 
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
        if (state!=1&&PlayerCollisionCheck.PlayerTouchCircle)
        {
            SwitchState(dashState_0);
            state = 1;
        }
        else if (state!=2  && !PlayerState_DashCircle_0.isBulletTimeActive && Player.PlayerSr.color == Color.yellow)
        {
            SwitchState(dashState_1);
            state = 2;
        }
        else if(state!=0&&Player.PlayerSr.color == Color.white)
        {
            SwitchState(noneState);
            state = 0;
        }
        currenntState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currenntState.PhysicUpdate();
    }
}
