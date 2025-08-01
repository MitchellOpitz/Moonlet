using UnityEngine;

public class PlanetGravityZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Moonlet moonlet))
        {
            moonlet.StartOrbit(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Moonlet moonlet))
        {
            moonlet.StopOrbit();
        }
    }
}
