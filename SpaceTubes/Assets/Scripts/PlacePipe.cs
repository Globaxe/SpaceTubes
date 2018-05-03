using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePipe : MonoBehaviour {

    private bool placing;
    private GameObject gameManager;
    public Transform rightJoin;
    public Transform leftJoin;
    // Use this for initialization
    void Start () {
        placing = false;
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void place()
    {
        placing = true;
    }

    public void unplace()
    {
        transform.parent.SetParent(null);
    }

    //place le tuyau en fonction du collider qui appels cette fonction
    public void recieveTriggerStay(string fromObject,Collider other)
    {
        if (placing)
        {
            if (other.tag == "end" || other.tag == "start" || other.tag == "connector")
            {
                if (fromObject == "Left")
                {
                    transform.parent.transform.position += (other.transform.position - leftJoin.position);
                    placing = false;

                }
                else if (fromObject == "Right")
                {
                    transform.parent.transform.position += (other.transform.position - rightJoin.position);
                    placing = false;
                }
                transform.parent.SetParent(gameManager.transform);
            }
        }
    }
}
