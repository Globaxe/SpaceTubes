using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageText : MonoBehaviour {

    public GameObject text;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //gère le placement du texte
        var camPos = Camera.main.transform.position + Camera.main.transform.forward;
        text.transform.position = camPos;
	}
}
