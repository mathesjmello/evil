using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWay : MonoBehaviour {

	//you can order a sanduich here
	private void OnTriggerEnter(Collider other)
	{
		other.gameObject.transform.parent = transform;
	}
	private void OnTriggerExit(Collider other)
	{
		other.gameObject.transform.parent = null;
	}
}
