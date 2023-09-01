using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        UIManager.Instance.StartLoadSceneMenu("TestingScene");
    }
    public void FindLobby()
    {
        Debug.Log("Finding Lobby");
        StartGame();
    }

    public void Settings()
    {
        Debug.Log("Opening Settings");
    }

    public void QuitGame() 
    {
        Debug.Log("Quitting Game");
    }
}
