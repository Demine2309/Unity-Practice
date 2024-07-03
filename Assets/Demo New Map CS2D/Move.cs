using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player

    void Update()
    {
        // Get input from AWSD keys
        float moveX = Input.GetAxis("Horizontal");  // A/D keys
        float moveY = Input.GetAxis("Vertical");    // W/S keys

        // Create a new vector for movement
        Vector2 move = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Update the player's position
        transform.Translate(move);
    }
}
