using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameHud : MonoBehaviour
{
    [SerializeField]
    private TMP_Text actionText;

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
