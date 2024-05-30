using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform startPos;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private float moveInput;
    private Vector3 moveDelta;

    private bool isJump = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveDelta = new Vector3(moveInput, 0, 0);

        if(Input.GetKeyDown(KeyCode.W))
            isJump = true;

        SwapDirection();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void SwapDirection()
    {
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(0.8f, 1.3f, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-0.8f, 1.3f, 1);
        }
    }

    private void MovePlayer()
    {
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
    }

    private void JumpPlayer()
    {
        if(IsCanJumping() && isJump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }

        isJump = false;
    }

    private bool IsCanJumping()
    {
        float laserLength = 1.5f;

        int layerMask = LayerMask.GetMask("Ground", "Cloud");

        RaycastHit2D hit = Physics2D.Raycast(startPos.position, Vector2.down, laserLength, layerMask);

        Color rayColor = Color.red;

        if (hit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(startPos.position, Vector2.down * laserLength, rayColor);

        return hit.collider != null;
    }
}
