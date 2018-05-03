using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    int counter;
    bool isGameFinished;
    LeftCollider[] leftColliders;
    RightCollider[] rightColliders;
    EndStart[] endStarts;
    public GameObject winText;
    // Use this for initialization
    void Start () {
        counter = transform.childCount;
        isGameFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
        //check si tous les tuyaux et la fin et l'arivée sont connectés
        //si c'est le cas on affiche le message de fin
        if (counter != transform.childCount)
        {
            isGameFinished = true;
            leftColliders = GetComponentsInChildren<LeftCollider>();
            rightColliders = GetComponentsInChildren<RightCollider>();
            endStarts = GetComponentsInChildren<EndStart>();

            foreach(LeftCollider lc in leftColliders)
            {
                if(!lc.connected)
                {
                    isGameFinished = false;
                }
            }

            foreach (RightCollider rc in rightColliders)
            {
                if (!rc.connected)
                {
                    isGameFinished = false;
                }
            }

            foreach (EndStart es in endStarts)
            {
                if(!es.connected)
                {
                    isGameFinished = false;
                }
            }
            if(isGameFinished)
            {
                winText.SetActive(true);
            }
            counter = transform.childCount;
        }
	}
}
