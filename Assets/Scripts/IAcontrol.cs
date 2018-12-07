using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAcontrol : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject gotoposition;
	public Movement Player;
    Animator anim;
	// Use this for initialization
	private void Awake()
	{
		Player = FindObjectOfType<Movement>();
	}

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

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.gameObject)
		{
			Player.Damed();
		}
		
			
		
	}
}
