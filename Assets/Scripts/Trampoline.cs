using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounce = 20f;
    private Animator animator;
    AudioSource bounceAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bounceAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            animator.SetBool("isOn", true);
            bounceAudio.Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isOn", false);
    }
}
