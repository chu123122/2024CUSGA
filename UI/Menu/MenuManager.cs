using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Setting;

    public GameObject AboutUS;

    public CanvasGroup BG;

    public GameObject ExitBtn;

    public void OnStartButton()
    {
        BG.gameObject.SetActive(true);
        BG.DOFade(1, 0).OnComplete(() => { SceneManager.LoadScene(1); });
        EventCenter.Broadcast(EventType.entergame);
    }
    public void OnSettingsButton()
    {
        Setting.SetActive(true);
        Setting.GetComponent<Animator>().DOPlay();
        EventCenter.Broadcast(EventType.settings);
    }
    public void OnAboutButton()
    {
        AboutUS.SetActive(true);
        AboutUS.GetComponent<CanvasGroup>().DOFade(1, 2f);
        EventCenter.Broadcast(EventType.aboutus);
    }
    public void OnExitButton()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
