using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameObject titleScreen;

    public void FindLobby()
    {
        Debug.Log("Finding Lobby");
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
