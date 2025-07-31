using UnityEngine;

public class PlanetScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        foreach (Transform child in transform)
        {
            child.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }
    }
}
