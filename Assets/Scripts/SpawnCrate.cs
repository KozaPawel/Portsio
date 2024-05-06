using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrate : MonoBehaviour
{
    public GameObject crate;
    public GameObject spawnPoint;
    private bool canSpawn = false;
    private Animator animator;
    public AudioSource press;

    void Update()
    {
        if (canSpawn && Input.GetKeyDown(KeyCode.E))
        {
            crate.transform.position = spawnPoint.transform.position;
            press.Play();
            GetComponent<Animator>().SetBool("isOn", true);
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(Wait());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canSpawn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canSpawn = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("isOn", false);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
