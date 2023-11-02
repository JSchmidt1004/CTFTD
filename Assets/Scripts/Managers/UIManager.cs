using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => instance; }

    private static UIManager instance;

    [SerializeField]
    private MainMenu titleMenu;
    [SerializeField]
    private InGameHud inGameHUD;
    [SerializeField]
    private LoadingScreen loadingScreen;

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

    public void SetActionItem(string actionText)
    {
        inGameHUD?.SetActionText(actionText);
    }

    public async void StartLoadSceneMenu(string sceneName)
    {
        await loadingScreen.FadeIn();

        titleMenu.gameObject.SetActive(false);
        inGameHUD.gameObject.SetActive(false);
        
        if (!sceneName.IsNullOrEmpty()) SceneLoadingManager.Instance.StartLoadScene(sceneName);
        
        StartCoroutine(LoadingScreen());
    }

    private IEnumerator LoadingScreen()
    {
        AsyncOperation loadingOperation = SceneLoadingManager.Instance?.LoadingOperation;
        if (loadingOperation != null)
        {
            while (!loadingOperation.isDone)
            {
                //Update loading screen progress
                loadingScreen.Progress = loadingOperation.progress;
                yield return null;
            }

            loadingScreen.FadeOut();
            if (SceneLoadingManager.Instance?.ActiveScene.name == "TestingScene") inGameHUD.gameObject.SetActive(true);
        }

        yield return null;
    }
}
