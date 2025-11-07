using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Player.State.Dah_0_State.NewEvent;

public class Dash_0State_System : AbstractSystem
{
    protected override void OnInit()
    {
        this.RegisterEvent<EnterDash_0_Event>(e =>
        {
            //PlayerSingleton.Instance.spriteRenderer.color = Color.yellow;
        });

    }
}
