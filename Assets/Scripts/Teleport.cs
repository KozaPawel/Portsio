using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //private GameObject player;
    private GameObject portal;
    private GameObject portalsSpawn;
    public string portalsSpawnName;
    public string portalName;
    private bool justExited;
    private float delay = 2f;
    
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        portal = GameObject.FindGameObjectWithTag(portalName);
        portalsSpawn = GameObject.FindGameObjectWithTag(portalsSpawnName);
        justExited = false;
    }

    private void Update()
    {
        if (justExited)
        {
            StartCoroutine(TurnCollidersOn(delay));
            justExited = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckObjectTag(collision))
        {
            TeleportObject(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckObjectTag(collision))
        {
            TeleportObject(collision);
        }
    }

    IEnumerator TurnCollidersOn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<BoxCollider2D>().enabled = true;
        portal.GetComponent<BoxCollider2D>().enabled = true;
    }
    
    void TeleportObject(Collider2D collision)
    {
        if (portal.transform.position != portalsSpawn.transform.position)
        {
            collision.transform.position = portal.transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
            portal.GetComponent<BoxCollider2D>().enabled = false;
            justExited = true;
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
