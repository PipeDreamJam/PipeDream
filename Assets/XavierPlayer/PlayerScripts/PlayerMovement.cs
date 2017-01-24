using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 0f;
    public float rayDownDistance = 0f;
    public GameObject player;
    private bool hitFlag = false;
    public bool playerIsGrounded = false;
    public bool playerFallInPit = false;
    public bool playerIsDead = false;
    public bool playerHitObsticle = false;
    public Rigidbody rb;
    private Vector3 spawnPos;
    public Animator anim;
    private float time_limit, time_count;
    public GameObject tunnelManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform.position; // Sets Spawn Position

        time_limit = 2.3f;
        time_count = 0f;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Use this for initialization
    void Awake()
    {
        time_limit = 2.3f;
        time_count = 0f;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(time_count < time_limit)
        {
            time_count += Time.deltaTime;
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }

            Ray downRay = new Ray(transform.position, Vector3.down); // Creates RayCast for Underneath The Player
            RaycastHit bottomHit; // Creates RayCast Hit

            Color rayColor = Color.red;
            if (Physics.Raycast(downRay, out bottomHit, rayDownDistance)) // Sets the Raycast 
            {
                if (bottomHit.collider.tag == "Plat")
                {
                    if (!playerIsGrounded)
                    {
                    playerIsGrounded = true;
                    anim.SetBool("IsGrounded", true);
                    //Debug.Log("Grounded True");
                        rayColor = Color.green;
                    }
                }
            }
            else
            {
            playerIsGrounded = false;
            anim.SetBool("IsGrounded", false);
            //Debug.Log("Grounded False");

            }
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * rayDownDistance), rayColor);
        if (Input.GetButtonDown("Jump"))
        {
            if (playerIsGrounded == true)
            {
                jumpForce = 35.0f;
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

            }
            else if (playerIsGrounded == false) 
            {
                jumpForce = 0.0f;
            }
        }
        PieceManager pm = tunnelManager.GetComponent<PieceManager>();
        if (Input.GetButton("Left"))
        {
            pm.RotateRings(11.25f);
        }
        if (Input.GetButton("Right"))
        {
            pm.RotateRings(-11.25f);
        }
        if (Input.GetButton("Credits"))
        {
            Application.LoadLevel("Credits");
        }

        if (playerHitObsticle == true)
        {
            playerIsDead = true;
        }
       
    }
}
