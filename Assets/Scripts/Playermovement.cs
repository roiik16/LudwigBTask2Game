using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

    //Physics component
    Rigidbody rb;
    //In order to change the color of the player
    MeshRenderer renderer;
    //setting player movement speed
    public float forwardForce = 500f;
    public float sidewaysForce = 100f;
    //Jump speed
    public float jumpForce = 300f;
    Transform groundCheck;
    //Check when the box can jump
    public bool isGrounded = true;
    private bool isCoroutineExecuting = false;
    bool jumpunlocked = false;
    bool slowpower = false;

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        float h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(h * 15f, rb.velocity.y, rb.velocity.z);
        
        Vector3 pos = rb.position;

        if (Mathf.Abs (pos.x) > 7f)
        {
            pos.x = Mathf.Sign(pos.x) * 7f;
        }
        rb.position = pos;

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetButtonDown("Jump") && isGrounded && jumpunlocked)
        {
           rb.AddForce(Vector3.up * jumpForce);
        }


        //SLOWPOWERUP INITIATE
        if (slowpower)
        {
            renderer.material.color = Color.black;
            StartCoroutine(Slowpowerup());
            slowpower = false;
        }


        //JUMPPOWERUP INITIATE
        if (jumpunlocked && Input.GetButton("Jump") )
        {
            renderer.material.color = Color.red;
            jumpunlocked = false;
        }

    }

    void OnTriggerEnter(Collider c)
    {
        //UNLOCK JUMP POWERUP
        if (c.tag == "jumpPower")
        {
            jumpunlocked = true;
            renderer.material.color = Color.green;
        }


        //UNLOCK SLOW POWERUP
        if (c.tag == "slowPower")
        {
            slowpower = true;
            renderer.material.color = Color.black;
        }
 
    }

     IEnumerator Slowpowerup()
    {        
        forwardForce = 200f;
        yield return new WaitForSeconds(4);

        renderer.material.color = Color.red;
        
    }
}
