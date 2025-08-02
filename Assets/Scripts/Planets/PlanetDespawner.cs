using UnityEngine;

public class PlanetDespawner : MonoBehaviour
{
    public float despawnOffsetX = 5f;
    public SpriteFader spriteFader;

    void Update()
    {
        float leftBound = Camera.main.transform.position.x - Camera.main.aspect * Camera.main.orthographicSize - despawnOffsetX;

        foreach (Transform child in transform)
        {
            if (child.position.x < leftBound)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void FadeAndDestroyAll()
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
                spriteFader.FadeOut(sr);
            Destroy(child.gameObject, spriteFader.duration);
        }
    }
}
