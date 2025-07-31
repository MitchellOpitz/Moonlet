using UnityEngine;

public class PlanetDespawner : MonoBehaviour
{
    public float despawnOffsetX = 5f;

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
}
