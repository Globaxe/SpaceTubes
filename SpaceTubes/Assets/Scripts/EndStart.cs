using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStart : MonoBehaviour {

    public bool connected { get; set; }

    void Start()
    {
        connected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "connector")
        {
            connected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "connector")
        {
            connected = false;
        }
    }
}
