using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
public class NormalState_System : AbstractSystem
{
    protected override void OnInit()
    {
        this.RegisterEvent<EnterNormalState_Event>(e =>
        {
              // e.spriteRenderer.color = Color.black;
        });
    }
}
