using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private float speed = 7f;
    public LayerMask layerMask;
    private bool facingRight = true;
    private float directionX;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(directionX * speed, rigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            float jumpVelocity = 8f;
            rigidBody.velocity = new Vector2(0, jumpVelocity);
        }
        //flipping character
        if (directionX > 0f && !facingRight)
        {
            Flip();
        }
        else if (directionX < 0f && facingRight)
        {
            Flip();
        }

        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("isGrounded", IsGrounded());
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, layerMask);
        return raycastHit2D.collider != null;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180f, 0);
    }
}
