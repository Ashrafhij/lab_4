using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] float movementRange = 5f; // Range of movement in units
    [SerializeField] float movementSpeed = 2f; // Speed of movement in units per second

    private bool movingRight = true;

    void Update()
    {
        // Move the planet right and left along a straight line
        if (movingRight)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        // Change direction when reaching the movement range
        if (transform.position.x > movementRange / 2 && movingRight)
        {
            movingRight = false;
        }
        else if (transform.position.x < -movementRange / 2 && !movingRight)
        {
            movingRight = true;
        }
    }
}
