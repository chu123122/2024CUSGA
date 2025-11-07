using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.Player._Event_Behavior_;
using QFramework.Player.NewPlayerGrab.Event;

public class PlayerMove_System : AbstractSystem
{
    private bool _canPlaySound = true;
    protected override void OnInit()
    {
        this.RegisterEvent<PlayerMoveStart_Event>(e =>
        {
            if (_canPlaySound&&Mathf.Abs(PlayerSingleton.Instance.rigidbody2D.velocity.x) >0.01f)
            {
                AudioClip[] audioClips =
                {
                    Resources.Load<AudioClip>("Music/move_1"),
                    Resources.Load<AudioClip>("Music/move_2"),
                    Resources.Load<AudioClip>("Music/move_3"),
                    Resources.Load<AudioClip>("Music/move_4")
                };
                int index = Random.Range(0, audioClips.Length);
                AudioSource.PlayClipAtPoint(audioClips[index], e.GameObject.transform.position);
                PlayerSingleton.Instance.animator.Play("Run");
                // 需要音效（按下移动按键）
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

