using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject player;
    public Camera mainCamera;
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
       
        this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
   public void OnResumeButton()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
       
        EventCenter.Broadcast(EventType.returntogame);
    }
    public void OnSettingsButton()
    {
        Setting.SetActive(true);
        EventCenter.Broadcast(EventType.settings);
    }
    public void OnExitButton()
    {
        SceneManager.LoadScene(0);
        Destroy(player);
        Destroy(mainCamera);
        EventCenter.Broadcast(EventType.restart);
    }
    public void OnSelectButton()
    {
        EventCenter.Broadcast(EventType.init);
        EventCenter.Broadcast(EventType.returntogame);
    }
}
