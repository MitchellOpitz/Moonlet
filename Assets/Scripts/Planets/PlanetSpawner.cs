using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnOffsetX = 3f;

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPlanet();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void SpawnPlanet()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camBottom = cam.transform.position.y - camHeight / 2f;
        float camTop = cam.transform.position.y + camHeight / 2f;
        float y = Random.Range(camBottom, camTop);
        float x = cam.transform.position.x + cam.aspect * cam.orthographicSize + spawnOffsetX;

        Vector3 spawnPos = new Vector3(x, y, 0f);
        Instantiate(planetPrefab, spawnPos, Quaternion.identity, transform);
    }
}
