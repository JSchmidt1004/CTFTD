using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float Progress { get => progress; set { progress = Mathf.Clamp01(value); } }

    [SerializeField]
    private Image backgroundImage;
    private float progress;

    public void FadeIn()
    {
        //Pre-set everything to blank screen before fade in
        Progress = 0;
        Color imageColor = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        backgroundImage.color = imageColor;

        gameObject.SetActive(true);

        //Start fade in
        imageColor.a = 1f;
        backgroundImage.color = imageColor;
    }

    public void FadeOut()
    {
        //Start fade out

        gameObject.SetActive(false);
    }

}
