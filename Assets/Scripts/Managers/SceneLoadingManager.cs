using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager: MonoBehaviour
{
    public static SceneLoadingManager Instance { get => instance; }

    public AsyncOperation LoadingOperation { get => loadingOperation; }
    public Scene ActiveScene { get => SceneManager.GetActiveScene(); }

    private static SceneLoadingManager instance;
    private AsyncOperation loadingOperation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartLoadScene(string sceneName)
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
    }

    public void StartLoadScene(int sceneId)
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneId);
    }
}
