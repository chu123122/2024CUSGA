using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class Dash_1State_System : AbstractSystem
{

    protected override void OnInit()
    {
        this.RegisterEvent<EnterDash_1State_Event>(e =>
        {

        });
    }

}
