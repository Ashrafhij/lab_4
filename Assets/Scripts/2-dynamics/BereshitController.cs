using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BereshitController : MonoBehaviour
{
    [SerializeField] float distanceToStartSlowdown = 0;
    [SerializeField] float dragForceForSlowdown = 0;
    [SerializeField] float thrustForce = 10f; // Adjust this value based on the desired thrust force.

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Handle spaceship control using keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Apply thrust force
        Vector2 thrust = new Vector2(horizontalInput, verticalInput) * thrustForce;
        rb.AddForce(thrust);

        // Send a ray to the moon and "drag" the spaceship when the moon is nearby
        RaycastHit2D hit = Physics2D.Raycast(origin: transform.position, direction: Vector2.down, distance: Mathf.Infinity);
        if (hit.collider != null && hit.distance <= distanceToStartSlowdown)
        {
            // Add drag to slow down the spaceship.
            rb.drag = dragForceForSlowdown;
        }
        else
        {
            // If not close to the moon, reset drag to zero.
            rb.drag = 0f;
        }

        // To see the Gizmo of the ray in the Scene view:
        Debug.DrawRay(transform.position, Vector2.down * distanceToStartSlowdown, Color.red);
    }
}
