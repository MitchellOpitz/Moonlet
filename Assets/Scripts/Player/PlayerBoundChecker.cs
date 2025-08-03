using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerBoundsChecker : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public float leftOffset = 3f;
    public float rightOffset = 5f;
    public float bottomOffset = 2f;
    public AudioSource deathSFX;

    private void Start()
    {
        GameObject go = GameObject.Find("GameOver");
        if (go != null) deathSFX = go.GetComponent<AudioSource>();
    }

    void Update()
    {
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = cam.aspect * camHeight;

        float left = camPos.x - camWidth / 2f - leftOffset;
        float right = camPos.x + camWidth / 2f + rightOffset;
        float bottom = camPos.y - camHeight / 2f - bottomOffset;

        Vector3 pos = transform.position;
        if (pos.x < left || pos.x > right || pos.y < bottom)
        {
            if (deathSFX != null) deathSFX.Play();
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}