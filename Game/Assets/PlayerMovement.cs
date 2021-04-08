using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Used for input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 characterScale = transform.localScale;
        if (movement.x < 0) {
            characterScale.x = -1;
        }
        else if (movement.x >= 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        animator.SetFloat("Move", movement.sqrMagnitude);
    }
    // Used for movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
