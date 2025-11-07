using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        // 播放指定名称的动画
        _animator.Play(animationName);
    }
    public void OnAnimationEnd()
    {
        // 切换到其他动画状态，比如 Idle
        _animator.Play("Idle");
    }
}
