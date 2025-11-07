using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private Animator anim;
    public SettingsData Data;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("shake", Data.ShakeSwitch);
        anim.SetInteger("music", Data.MusicIndex);
        anim.SetInteger("effects", Data.MusicEffectsIndex);
    }
    public void OnResumeButton()
    {
        EventCenter.Broadcast(EventType.resume);
    }
    #region ÉèÖÃ°´Å¥
    public void OnMusicRightButton()
    {
        if (Data.MusicIndex >= 0 && Data.MusicIndex < 9)
        {
            Data.MusicIndex++;
        }
    }
    public void OnMusicLeftButton()
    {
        if (Data.MusicIndex > 0 && Data.MusicIndex <= 9)
        {
            Data.MusicIndex--;
        }
    }
    public void OnEffectsRightButton()
    {
        if (Data.MusicEffectsIndex >= 0 && Data.MusicEffectsIndex < 9)
        {
            Data.MusicEffectsIndex++;
        }
    }
    public void OnEffectsLeftButton()
    {
        if (Data.MusicEffectsIndex > 0 && Data.MusicEffectsIndex <= 9)
        {
            Data.MusicEffectsIndex--;
        }
    }
    public void OnShakeButton()
    {
        if(Data.ShakeSwitch)
        {
            Data.ShakeSwitch = false;
        }
        else
        {
            Data.ShakeSwitch = true;
        }
    }
    #endregion
}
