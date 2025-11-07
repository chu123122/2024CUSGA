using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Savable/SettingsData", fileName = "SettingsData")]
public class SettingsData : ScriptableObject
{
    [Header("初始的设置参数")]
    [SerializeField]private int InitMusicIndex=5;
    [SerializeField]private int InitMusicEffectsIndex=5;
    [SerializeField]private bool InitShakeSwitch=true;
    [Header("设置参数")]
    [Tooltip("音乐的音量大小")]
    public int MusicIndex;
    [Tooltip("音效的音量大小")]
    public int MusicEffectsIndex;
    [Tooltip("震动开关")]
    public bool ShakeSwitch;
}
