using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

    //Physics component
    public Rigidbody rb;

    //setting player movement speed
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    //Jump speed
    public float jumpForce = 500f;

    Transform groundCheck;

    //Check when the box can jump
    public bool isGrounded = true;

    private bool isCoroutineExecuting = false;

    bool jumpunlocked = false;

    bool slowpower = false;

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
    }

    void FixedUpdate()
    {
        isGrounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        //PLAYER CONTROLS
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetButtonDown("Jump") && isGrounded && jumpunlocked)
        {
           rb.AddForce(Vector3.up * jumpForce);
        }


        //SLOWPOWERUP INITIATE
        if (slowpower == true)
        {
            StartCoroutine(Slowpowerup());
        }

    }

    void OnTriggerEnter(Collider c)
    {
        //UNLOCK JUMP POWERUP
        if (c.tag == "jumpPower")
        {
            jumpunlocked = true;
        }


        //UNLOCK SLOW POWERUP
        if (c.tag == "slowPower")
        {
            slowpower = true;
        }
        
    }


     IEnumerator Slowpowerup()
    {        
        forwardForce = 200f;
        yield return new WaitForSeconds(2);
        forwardForce = 2000f;
    }
}
