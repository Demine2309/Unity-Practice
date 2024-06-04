using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dragForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerRotatation();

        MoveForward();
    }

    private void PlayerRotatation()
    {
        float rotationSpeed = 90;

        if (Input.GetKey(KeyCode.A))
            rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    private void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 force = transform.up * moveSpeed;

            rb.AddForce(force);

            rb.drag = dragForce;
        }
    }
}
