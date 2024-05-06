using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody;
    private GameObject portal1;
    private GameObject portal2;
    private float delay = 10f;

    void Start()
    {
        rigidBody.velocity = transform.right * speed;
        portal1 = GameObject.FindWithTag("PortalA");
        portal2 = GameObject.FindWithTag("PortalB");
    }

    private void Update()
    {
        StartCoroutine(DestroyLooseBullet(delay));
        if (CompareTag("BulletN"))
        {
            StartCoroutine(FastBullet());
        }
    }

    IEnumerator FastBullet()
    {
        yield return new WaitForSeconds(5f);
        rigidBody.velocity = transform.right * 50f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.CompareTag("BulletN"))
        {
            if (collision.CompareTag("Up") || collision.CompareTag("Right") || collision.CompareTag("Left"))
            {
                PlacePortal(collision);
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("BulletN"))
        {
            if (collision.CompareTag("Up") || collision.CompareTag("Right") || collision.CompareTag("Left"))
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Down") || collision.CompareTag("PortalA") || collision.CompareTag("PortalB"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Crate")
        {
            Destroy(gameObject);
        }
    }

    void PlacePortal(Collider2D collision)
    {
        Quaternion rotation;
        float offsetX = 0f;
        float offsetY = 0f;

        if (collision.CompareTag("Up"))
        {
            rotation = Quaternion.Euler(0f, -180f, 90f);
            offsetY = -0.3f;
        }
        else if (collision.CompareTag("Right"))
        {
            rotation = Quaternion.Euler(0f, 0f, 0f);
            offsetX = -0.4f;
        }
        else
        {
            rotation = Quaternion.Euler(0f, 180f, 0f);
            offsetX = 0.4f;
        }

        if(gameObject.CompareTag("BulletA"))
        {
            portal1.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);
            portal1.transform.rotation = rotation;
        }
        if (gameObject.CompareTag("BulletB"))
        {
            portal2.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);
            portal2.transform.rotation = rotation;
        }
    }

    private IEnumerator DestroyLooseBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
