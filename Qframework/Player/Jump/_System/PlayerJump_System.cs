using QFramework;
using System.Collections;
using System.Collections.Generic;
using QFramework.Player._Event_Behavior_;
using UnityEngine;

public class PlayerJump_System : AbstractSystem
{
    protected override void OnInit()
    {
        this.RegisterEvent<Jump_Event>(e =>
        { 
            Vector2 target = e.GameObject.transform.position-new Vector3(-1f,0.18f,0);
            if (PlayerSingleton.Instance.transform1.rotation.y != 0)
            {
                target=e.GameObject.transform.position-new Vector3(0.8f,0.18f,0);
            }
            ParticleSystem effect = Object.Instantiate( PlayerSingleton.Instance.jumpDustParticle1
                , target, Quaternion.identity);
            effect.Play();
            Object.Destroy(effect.gameObject, effect.main.duration);
            AudioClip audioClip = Resources.Load<AudioClip>("Music/jump_up");
            AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
            PlayerSingleton.Instance.animator.Play("Jump",-1,0f);
            //需要音效（跳跃）
        });
    }
}
