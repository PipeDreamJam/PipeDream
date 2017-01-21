using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 new_pos = player.position;
        new_pos.z += 100;
        new_pos.y += 20;
        transform.position = new_pos;
    }
}
