using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawm : MonoBehaviour {
    public GameObject playerref;
	// Use this for initialization
	void Start () {
        Instantiate(playerref, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
