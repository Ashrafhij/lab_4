using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class CollisionExploder : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] GameObject explosionEffect = null;
    [SerializeField] float explosionEffectTime = 0.68f;

    [SerializeField] float timeOnFloorThreshold = 1.2f;

    private bool onFloor = false;
    private float timeOnFloor = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (onFloor)
        {
            // Increment the time spent on the floor
            timeOnFloor += Time.deltaTime;

            // Check if the threshold is reached
            if (timeOnFloor >= timeOnFloorThreshold)
            {
                SceneManager.LoadScene("scene3");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        Debug.Log(gameObject.name + " collides with " + collision.collider.name
            + " at velocity " + collision.relativeVelocity + " [m/s], impulse " + impulse + " [kg*m/s]");

        if (impulse > minImpulseForExplosion && collision.collider.name != "Floor")
        {
            StartCoroutine(ExplosionAndLoadScene());
        }
        if (collision.collider.name == "Floor")
        {
            // The Bereshit is on the floor
            onFloor = true;
        }
    }

    IEnumerator ExplosionAndLoadScene()
    {
        explosionEffect.SetActive(true);
        yield return new WaitForSeconds(explosionEffectTime);

        // Wait for one more second before loading the scene
        yield return new WaitForSeconds(0.5f);

        // Load the scene after waiting for one second
        SceneManager.LoadScene("scene1");
    }
}
