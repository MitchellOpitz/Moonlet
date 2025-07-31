using UnityEngine;

public class Moonlet : MonoBehaviour
{
    public float gravityForce = 1f;
    public float maxFallSpeed = 5f;
    public float orbitForce = 5f;

    private Rigidbody2D rb;
    private Transform orbitTarget;
    private bool isOrbiting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isOrbiting && Input.GetKeyDown(KeyCode.Space))
        {
            StopOrbit();
        }
    }

    void FixedUpdate()
    {
        if (isOrbiting && orbitTarget != null)
        {
            OrbitPlanet();
        }
        else
        {
            ApplyNaturalGravity();
        }
    }

    void OrbitPlanet()
    {
        Vector2 toCenter = (orbitTarget.position - transform.position);
        Vector2 direction = toCenter.normalized;
        Vector2 velocity = rb.velocity;

        Vector2 tangent = Vector2.Perpendicular(direction);
        if (Vector2.Dot(velocity, tangent) < 0)
            tangent = -tangent;

        float distance = toCenter.magnitude;
        float centripetalForce = Mathf.Clamp(orbitForce / distance, 0f, orbitForce * 2f);
        Vector2 orbitalVelocity = tangent.normalized * orbitForce;
        Vector2 pullTowardCenter = direction * centripetalForce;

        Vector2 desiredVelocity = orbitalVelocity + pullTowardCenter;
        rb.velocity = Vector2.Lerp(rb.velocity, desiredVelocity, 0.1f);
    }

    void ApplyNaturalGravity()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = Mathf.Max(velocity.y - gravityForce * Time.fixedDeltaTime, -maxFallSpeed);
        rb.velocity = velocity;
    }

    public void StartOrbit(Transform planet)
    {
        Debug.Log("Entered orbit around: " + planet.name);
        isOrbiting = true;
        orbitTarget = planet;
    }

    public void StopOrbit()
    {
        Debug.Log("Exited orbit");
        isOrbiting = false;
        orbitTarget = null;
    }
}
