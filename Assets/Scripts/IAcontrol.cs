using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAcontrol : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject gotoposition;
    Animator anim;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination=gotoposition.transform.position;
	}

    public void Damage()
    {
        anim.enabled = false;
        agent.enabled = false;
        Destroy(gameObject, 5);
    }
}
