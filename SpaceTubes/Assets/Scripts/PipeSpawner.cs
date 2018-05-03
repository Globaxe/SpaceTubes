using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

    public GameObject pipe;
    private Vector3 positionSpawn;
    public GameObject actualPipe;

	// Use this for initialization
	void Start () {
        positionSpawn = actualPipe.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //fait spawn les tuyau un part un
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == actualPipe.GetComponentInChildren<HandDragging>().gameObject)
        {
            actualPipe =Instantiate(pipe, positionSpawn, pipe.transform.rotation);
        }
        
    }
}
