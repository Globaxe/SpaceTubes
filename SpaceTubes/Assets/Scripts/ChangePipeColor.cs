using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePipeColor : MonoBehaviour {

    Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
    public void changeColor(Material mat)
    {
        rend.material = mat;
    }

}
