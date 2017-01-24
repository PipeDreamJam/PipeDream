using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class RayCastObject : MonoBehaviour
{
    public bool playerHitObsticle = false;
    public float rayForwardDistance = 0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray forwardRay = new Ray(transform.position, Vector3.forward);
        RaycastHit forwardHit;

        Color forwardColor = Color.black;
        if (Physics.Raycast(forwardRay, out forwardHit, rayForwardDistance))
        {
            {
                //if (forwardHit.collider.tag == "Map")
               
                   //if (!playerHitObsticle)
                   // {
                   //     playerHitObsticle = true;
                   //     Debug.Log("Obsticle Hit");
                   //     //Application.Quit();
                   //     //SceneManager.LoadScene("Load");
                   //     //audio.stop();
                   // }
                }
            }
        
        else
        {
            playerHitObsticle = false;
            //Debug.Log("Obsticle Not Hit");

        }
        Debug.DrawLine(transform.position, transform.position + (Vector3.forward * rayForwardDistance), forwardColor);

    }
}
