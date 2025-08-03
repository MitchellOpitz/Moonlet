using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using System;

public class TitleScreen : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text subtitleText;
    public float fadeDuration = 1f;
    public float postFadeDelay = 1f;
    public AudioSource startSFX;

    private UIFader fader;
    public static event Action OnGameStart;

    private void Start()
    {
        fader = FindObjectOfType<UIFader>();
        StartCoroutine(TitleRoutine());
    }

    private IEnumerator TitleRoutine()
    {
        yield return new WaitForSeconds(fadeDuration);
        fader.FadeIn(titleText);
        fader.FadeIn(subtitleText);
        yield return new WaitForSeconds(fadeDuration);

        yield return new WaitUntil(() => Input.anyKeyDown);
        if (startSFX != null) startSFX.Play();

        fader.FadeOut(titleText);
        fader.FadeOut(subtitleText);
        yield return new WaitForSeconds(fadeDuration + postFadeDelay);

        OnGameStart?.Invoke();
    }
}
