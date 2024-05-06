using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject player;
    public GameObject crate;
    public AudioSource respawn;
    private Vector3 playerSpawn;
    private Vector3 crateSpawn;

    void Start()
    {
        playerSpawn = player.transform.position;
        crateSpawn = crate.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = playerSpawn;
            respawn.Play();
        }
        if (collision.CompareTag("Crate"))
        {
            crate.transform.position = crateSpawn;
            crate.GetComponent<Rigidbody2D>().velocity = transform.right * 0f;
        }
    }
}
