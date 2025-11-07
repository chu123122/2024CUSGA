using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField]private SceneField[] sceneToLoad;
    [SerializeField]private SceneField[] sceneToUnLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadScenes();
            UnLoadScenes();
        }
    }

    private void LoadScenes()
    {
        for(int i = 0; i < sceneToLoad.Length; i++)
        {
            bool isSceneLoaded = false;
            for(int j = 0;j<SceneManager.sceneCount; j++)
            {
                Scene loadedScene=SceneManager.GetSceneAt(j);
                if (loadedScene.name == sceneToLoad[i].SceneName)
                {
                    isSceneLoaded = true;
                    break;  
                }
            }

            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(sceneToLoad[i],LoadSceneMode.Additive);
            }
        }
    }

    private void UnLoadScenes()
    {
        for(int i = 0;i < sceneToUnLoad.Length; i++)
        {
            for(int j = 0; j<SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == sceneToUnLoad[i].SceneName)
                {
                    SceneManager.UnloadSceneAsync(sceneToUnLoad[i]);
                }
            }
        }
    }

}
