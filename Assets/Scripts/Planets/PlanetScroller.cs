using UnityEngine;

public class PlanetScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private bool isScrolling = false;

    void Update()
    {
        if (!isScrolling) return;

        foreach (Transform child in transform)
        {
            child.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }
    }

    public void StartScroller()
    {
        isScrolling = true;
    }

    public void StopScroller()
    {
        isScrolling = false;
    }
}
