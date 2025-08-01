using UnityEngine;
using UnityEngine.Events;

public class PlanetScoreTrigger : MonoBehaviour
{
    public static UnityEvent onPlanetPassed = new UnityEvent();

    public LayerMask playerLayer;
    public float rayDistance = 1f;

    private bool scored = false;

    private void Update()
    {
        if (scored) return;

        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, rayDistance, playerLayer);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, playerLayer);

        if (hitUp.collider != null || hitDown.collider != null)
        {
            scored = true;
            onPlanetPassed.Invoke();
        }
    }
}
