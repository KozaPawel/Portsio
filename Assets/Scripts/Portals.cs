using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    private GameObject instantiatedPortal1;
    private GameObject instantiatedPortal2;

    void Start()
    {
        instantiatedPortal1 = Instantiate(portal1, transform.position, transform.rotation);
        instantiatedPortal2 = Instantiate(portal2, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            instantiatedPortal1.transform.position = transform.position;
            instantiatedPortal2.transform.position = transform.position;
        }
    }
}
