using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayStop : MonoBehaviour {

    PlayerMovement PMove;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(PMove.playerIsGrounded == true)
        {
            PMove.anim.SetBool("Start", true);
        }
        else if(PMove.playerIsGrounded == false)
        {
            PMove.anim.SetBool("Stop", true);
        }
	}
}
