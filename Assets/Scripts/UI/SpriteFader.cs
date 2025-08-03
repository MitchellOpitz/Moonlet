
using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour
{
    public float duration = 1f;

    public void FadeIn(SpriteRenderer sprite) => StartCoroutine(Fade(sprite, 0f, 1f, duration));
    public void FadeOut(SpriteRenderer sprite) => StartCoroutine(Fade(sprite, 1f, 0f, duration));

    private IEnumerator Fade(SpriteRenderer sprite, float from, float to, float duration)
    {
        if (sprite == null) yield break;

        float time = 0f;
        Color c = sprite.color;
        while (time < duration)
        {
            if (sprite == null) yield break;

            float t = time / duration;
            sprite.color = new Color(c.r, c.g, c.b, Mathf.Lerp(from, to, t));
            time += Time.deltaTime;
            yield return null;
        }

        if (sprite != null)
            sprite.color = new Color(c.r, c.g, c.b, to);
    }

}
