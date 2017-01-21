using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 0f;
    public float rayDownDistance = 0f;
    public float rayForwardDistance = 0f;
    public GameObject player;
    private bool hitFlag = false;
    public bool playerIsGrounded = false;
    public bool playerHitObsticle = false;
    public bool playerFallInPit = false;
    public bool playerIsDead = false;
    public Rigidbody rb;
    private Vector3 spawnPos;
    public Animator anim;
  
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        spawnPos = transform.position; // Sets Spawn Position
        
            
    }
   

    // Update is called once per frame
    void Update()
    {
            Ray downRay = new Ray(transform.position, Vector3.down); // Creates RayCast for Underneath The Player
            RaycastHit bottomHit; // Creates RayCast Hit

            Color rayColor = Color.red;
            if (Physics.Raycast(downRay, out bottomHit, rayDownDistance)) // Sets the Raycast 
            {
                if (bottomHit.collider.tag == "Map")
                {
                    if (!playerIsGrounded)
                    {
                    playerIsGrounded = true;
                    //anim.SetBool("Stop", false);
                    //anim.SetBool("Start", true);
                    Debug.Log("Grounded True");
                        rayColor = Color.green;
                    }
                }
            }
            else
            {
            playerIsGrounded = false;
            //anim.SetBool("Start", false);
            //anim.SetBool("Stop", true);
            Debug.Log("Grounded False");

            }
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * rayDownDistance), rayColor);



        Ray forwardRay = new Ray(transform.position, Vector3.down);
        RaycastHit forwardHit;

        Color forwardColor = Color.black;
        if (Physics.Raycast(forwardRay, out forwardHit, rayForwardDistance))
        {
            if (forwardHit.collider.tag == "Obsticle")
            {
                if (!playerHitObsticle)
                {
                    playerHitObsticle = true;
                    Debug.Log("Obsticle Hit");
                    rayColor = Color.cyan;
                }
            }
        }
        else
        {
            playerHitObsticle = false;
            Debug.Log("Obsticle Not Hit");

        }
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * rayDownDistance), rayColor);

        if (Input.GetButtonDown("Jump"))
        {
            if (playerIsGrounded == true)
            {
                jumpForce = 75.0f;
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

            }
            else if (playerIsGrounded == false) 
            {
                jumpForce = 0.0f;
            }
        }
        if (playerHitObsticle == true)
        {
            playerIsDead = true;
        }
       
    }
}
