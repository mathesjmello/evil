using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    CharacterController charctrl;
    Vector3 vecMove=Vector3.zero;
    Vector3 vecLook = Vector3.zero;
    public GameObject Head;
    float headAngle=0;
    public float velocity = 0.1f;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        charctrl = GetComponent<CharacterController>();
    }
	void ControlPlayer()
    {
        vecMove = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
        vecLook = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        headAngle -= vecLook.x;
        headAngle = Mathf.Clamp(headAngle, -70, 70);
    }

	// Update is called once per frame
	void Update () {
        ControlPlayer();
        charctrl.Move(transform.TransformDirection(vecMove* velocity));
        transform.Rotate(Vector3.up, vecLook.y);
        Head.transform.localRotation = Quaternion.Euler(headAngle, 0, 0);
    }

    

}
