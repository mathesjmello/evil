using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public int level = 0;
    public Vector3[] levelposition;
    public Animator[] leveldoor;
    public Animator mydoor;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    void Translating()
    {
        transform.position =
            Vector3.Lerp(transform.position, levelposition[level], Time.deltaTime);
        if (Vector3.Distance(transform.position, levelposition[level]) < 0.1f)
        {
            mydoor.SetBool("opened", true);
            leveldoor[level].SetBool("opened", true);
            CancelInvoke("Translating");
        }
    }

    public void ChangeLevel(int golevel)
    {
        leveldoor[level].SetBool("opened", false);
        mydoor.SetBool("opened", false);
        if (golevel >= 0 && golevel < levelposition.Length) {
            level = golevel;
        }
        InvokeRepeating("Translating", 1, 0.01f);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.parent = null;
    }
}
