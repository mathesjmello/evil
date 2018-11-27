using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject gunPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
           if( Physics.Raycast(gunPoint.transform.position,
               gunPoint.transform.forward,out hit)){
                Debug.DrawLine(gunPoint.transform.position, hit.point);
                hit.collider.gameObject.SendMessageUpwards("Damage", 
                    SendMessageOptions.DontRequireReceiver);

            }

        }
	}
}
