using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => instance; }

    private static UIManager instance;

    [SerializeField]
    private MainMenu titleMenu;
    [SerializeField]
    private GameObject ingameHUD;
    [SerializeField]
    private LoadingScreen loadingScreen;
    [SerializeField]
    private TMP_Text actionText;


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

    void Start()
    {
        if (actionText != null) actionText.text = "";
    }


    public void SetActionText(string message)
    {
        if (actionText == null || message == null) return;
        actionText.text = message;
    }

    public void StartLoadSceneMenu(string sceneName)
    {
        loadingScreen.FadeIn();

        titleMenu.gameObject.SetActive(false);
        ingameHUD.gameObject.SetActive(false);

        //Wait a couple seconds
        SceneLoadingManager.Instance.StartLoadScene("TestingScene");

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

            Debug.Log("Fade Out");
            loadingScreen.FadeOut();
            if (SceneLoadingManager.Instance?.ActiveScene.name == "TestingScene") ingameHUD.gameObject.SetActive(true);
        }

        yield return null;
    }
}
