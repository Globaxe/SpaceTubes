using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour {

    private PlacePipe parent;
    public bool connected { get; set; }
    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<PlacePipe>();
        connected = false;
    }


    // Update is called once per frame
    void Update () {
		
	}


    //gère les connections
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end" || other.tag == "start" || other.tag == "connector")
        {
            connected = true;
        }
    }

    //gère les connections
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "end" || other.tag == "start" || other.tag == "connector")
        {
            connected = false;
        }
    }

    //appels une fonction dans le script parent
    private void OnTriggerStay(Collider other)
    {
        parent.recieveTriggerStay("Left", other);
    }

}
