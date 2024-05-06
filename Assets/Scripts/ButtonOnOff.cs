using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour
{
    private Animator animator;
    private Animator doorAnimator;
    public GameObject door;
    private int numberOfObjectsOn = 0;
    public AudioSource push;
    public AudioSource doorClose;
    private BoxCollider2D doorCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
        doorCollider = door.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckObjectTag(collision))
        {
            animator.SetBool("isOn", true);
            numberOfObjectsOn += 1;
        }

        if (numberOfObjectsOn == 1)
        {
            push.Play();
            doorClose.Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckObjectTag(collision))
        {
            animator.SetBool("isOn", true);
            doorAnimator.SetBool("buttonPressed", true);
            doorCollider.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckObjectTag(collision))
        {
            numberOfObjectsOn -= 1;
            if (numberOfObjectsOn == 0)
            {
                animator.SetBool("isOn", false);
                push.Stop();
                doorClose.Play();
                doorAnimator.SetBool("buttonPressed", false);
                doorCollider.enabled = true;
            }
        }
    }

    bool CheckObjectTag(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Crate"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
