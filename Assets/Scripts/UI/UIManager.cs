using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => instance; }

    static UIManager instance;

    public MainMenu titleMenu;
    public GameObject ingameHUD;
    public TMP_Text actionText;

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
}
