using QFramework.Player._Event_Behavior_;
using QFramework.Player.NewPlayerAutoGrab.Event;
using QFramework.Player.NewPlayerGrab.Event;
using UnityEditor;
using UnityEngine;

namespace QFramework.Player.Grab.System
{
    public class PlayerGrab_System:AbstractSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<GrabStart_Event>(e =>
            {
                PlayerSingleton.FlipAll();
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hook_shot");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                PlayerSingleton.Instance.animator.Play("SprintStart",-1,0f);
                //需要音效（钩爪射出）
            });
            this.RegisterEvent<GrabHit_Event>(e =>
            {
                AudioClip audioClip = Resources.Load<AudioClip>("Music/hook_hit");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                //需要音效（钩爪碰到物体）
            });

            this.RegisterEvent<GrabMove_Event>(e =>
            {
                PlayerSingleton.Instance.animator.Play("Sprint",-1,0f);
            });
        }
    }
}