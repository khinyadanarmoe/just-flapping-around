using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveScript : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float deadzone = -50; // Position at which the rock will be destroyed
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // Moves the rock to the left at the specified speed
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject); // Destroys the rock if it goes past the deadzone
        }
    }
}
