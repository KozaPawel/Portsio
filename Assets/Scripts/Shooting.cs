using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shooting & arm rotation
public class Shooting : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public GameObject bulletBlue;
    public GameObject bulletPink;
    public GameObject bulletNormal;
    private bool gunInWall = false;
    public AudioSource shootPortal;
    public AudioSource shootNormalBullet;
    private bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            if (rotationZ < -90 || rotationZ > 90)
            {
                if (player.transform.eulerAngles.y <= 0)
                {
                    transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
                }
                else if (player.transform.eulerAngles.y >= 180)
                {
                    transform.localRotation = Quaternion.Euler(180f, 180f, -rotationZ);
                }
            }

            if (Input.GetButtonDown("Fire1") && !gunInWall)
            {
                Shoot("blue");
                shootPortal.Play();
            }
            if (Input.GetButtonDown("Fire2") && !gunInWall)
            {
                Shoot("pink");
                shootPortal.Play();
            }

            if (canShoot)
            {
                if (Input.GetButtonDown("Fire3") && !gunInWall)
                {
                    Instantiate(bulletNormal, firePoint.position, firePoint.rotation);
                    shootNormalBullet.Play();
                    canShoot = false;
                    StartCoroutine(WaitToShoot());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Left") || collision.CompareTag("Right") || collision.CompareTag("PortalA") || collision.CompareTag("PortalB") || collision.CompareTag("Ground"))
        {
            gunInWall = true;
        }
        else
        {
            gunInWall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gunInWall = false;
    }

    private void Shoot(string bullet)
    {
        if(bullet == "pink")
        {
            Instantiate(bulletPink, firePoint.position, firePoint.rotation);
        }
        else
        {
            Instantiate(bulletBlue, firePoint.position, firePoint.rotation);
        }
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(5f);
        canShoot = true;
    }
}
