using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceSwitch : MonoBehaviour
{
    [Tooltip("¼ÓÔØ³¡¾°Ãû×Ö")]
    public string targetSceneName;
    [Tooltip("ºÚÆÁ")]
    public GameObject loadingScreen;
    [Tooltip("±³¾°ÒôÀÖ")]
    public AudioSource audioSource;
    
    private GameObject _mainCamera;

    private void Awake()
    {
        _mainCamera=Camera.main.gameObject;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DontDestroyOnLoad(_mainCamera);
            loadingScreen.SetActive(true); // ºÚÆÁ
            StartCoroutine(WaitForMusic());
        }
    }
    IEnumerator WaitForMusic()
    {
        while (audioSource.isPlaying&&audioSource.volume>=0.2f)
        {
            audioSource.volume -= Time.deltaTime * 0.5f;
            yield return null;
        }
        SceneManager.LoadSceneAsync(targetSceneName);
    }
}
