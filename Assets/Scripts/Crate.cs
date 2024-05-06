using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public AudioSource move;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!PauseMenu.gameIsPaused)
        {
            if (collision.gameObject.tag == "Player" && !move.isPlaying && rigidBody.velocity.magnitude >= 0.2f)
            {
                move.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && move.isPlaying)
        {
            move.Stop();
        }
    }
}
