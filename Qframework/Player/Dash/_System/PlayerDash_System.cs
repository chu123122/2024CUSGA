using System.Collections;
using System.Collections.Generic;
using QFramework;
using QFramework.Player._Event_Behavior_;
using UnityEditor;
using UnityEngine;

public class PlayerDash_System : AbstractSystem
{

    protected override void OnInit()
    {
        this.RegisterEvent<Dash_Event>(e =>
        {
            
            PlayerSingleton.Instance.animator.Play("Rush",-1,0f);
            AudioClip audioClip = Resources.Load<AudioClip>("Music/dash");
            AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
           
            //–Ë“™“Ù–ß£®≥Â¥Ã£©
        });
    }

  
}
