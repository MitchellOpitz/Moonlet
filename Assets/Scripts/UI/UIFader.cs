using UnityEngine;
using TMPro;
using System.Collections;

public class UIFader : MonoBehaviour
{
    public float duration = 1f;

    public void FadeIn(TMP_Text text) => StartCoroutine(Fade(text, 0f, 1f, duration));
    public void FadeOut(TMP_Text text) => StartCoroutine(Fade(text, 1f, 0f, duration));

    private IEnumerator Fade(TMP_Text text, float from, float to, float duration)
    {
        if (text == null) yield break;

        float time = 0f;
        Color c = text.color;
        while (time < duration)
        {
            float t = time / duration;
            text.color = new Color(c.r, c.g, c.b, Mathf.Lerp(from, to, t));
            time += Time.deltaTime;
            yield return null;
        }
        text.color = new Color(c.r, c.g, c.b, to);
    }
}
