using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFadeEffect : MonoBehaviour
{
    [SerializeField] private float _fadeTime;

    public float FadeTime => _fadeTime;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine(_fadeTime));
    }

    private IEnumerator FadeInCoroutine(float fadeOutTime)
    {
        float elapsedTime = 0;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        _canvasGroup.alpha = 0;

        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            _canvasGroup.alpha = elapsedTime / fadeOutTime;

            yield return waitForEndOfFrame;
        }

        _canvasGroup.alpha = 1;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine(_fadeTime));
    }

    private IEnumerator FadeOutCoroutine(float fadeOutTime)
    {
        float elapsedTime = 0;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        _canvasGroup.alpha = 1;

        while(elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            _canvasGroup.alpha = 1 - elapsedTime / fadeOutTime;

            yield return waitForEndOfFrame;
        }

        _canvasGroup.alpha = 0;
    }
}
