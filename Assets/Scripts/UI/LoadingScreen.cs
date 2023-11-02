using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float Progress { get => progress; set { progress = Mathf.Clamp01(value); } }

    [SerializeField]
    private Image backgroundImage;
    [SerializeField, Range(0f, 10f)]
    private float fadeInTime;
    [SerializeField, Range(0f, 10f)]
    private float fadeOutTime;
    private float progress;


    public async Task FadeIn()
    {
        Progress = 0;
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        gameObject.SetActive(true);

        await backgroundImage.DOFade(1f, fadeInTime).AsyncWaitForCompletion();
    }

    public async void FadeOut()
    {
        await backgroundImage.DOFade(0f, fadeOutTime).AsyncWaitForCompletion();
        gameObject.SetActive(false);
    }

}
