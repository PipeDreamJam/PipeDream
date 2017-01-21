using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl_basic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        y *= -1;
        //x *= -1;

        transform.Rotate(y, x, 0, Space.World);
	}
}
