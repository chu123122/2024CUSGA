using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Player._Event_Behavior_;

public class PlayerLoad_System : AbstractSystem
{
    private bool _canPlaySound = true;
    protected override void OnInit()
    {
        this.RegisterEvent<Load_Event>(e =>
        {
            if (_canPlaySound)
            {
                Vector2 target = e.GameObject.transform.position-new Vector3(-1f,0.18f,0);
                if (PlayerSingleton.Instance.transform1.rotation.y != 0)
                {
                    target=e.GameObject.transform.position-new Vector3(0.8f,0.18f,0);
                }
                ParticleSystem effect = Object.Instantiate( PlayerSingleton.Instance.dustParticle
                    , target, Quaternion.identity);
                effect.Play();
                Object.Destroy(effect.gameObject, effect.main.duration);
                AudioClip audioClip = Resources.Load<AudioClip>("Music/jump_down");
                AudioSource.PlayClipAtPoint(audioClip,e.GameObject.transform.position);
                PlayerSingleton.Instance.animator.Play("LandStart",-1,0f);
                PlayerSingleton.Instance.animator.Play("Land",-1,0f);
                //需要音效（落地）
                _canPlaySound = false;
                PlayerSingleton.Instance.StartCoroutine(ResetSoundDelay());
            }
        });
    }
    IEnumerator ResetSoundDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _canPlaySound = true;
    }
}
