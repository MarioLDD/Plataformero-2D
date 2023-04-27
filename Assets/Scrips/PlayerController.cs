using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    
    public float speed;
    public float speedMax;
    private bool grounded;
    public float jumpForce;
    public ParticleSystem stela;
    private bool falls;
    private float moveH;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        grounded = true;
        falls = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("saltar");
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
        
       
        
    }

    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * moveH * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
       LimitMaxSpeed();
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Ground");
        grounded=true;
        //stela.Play();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        falls = true;
      //  stela.Stop();
    }

    void LimitMaxSpeed()
    {
        if(playerRb.velocity.magnitude > speedMax)
        {
            playerRb.velocity = playerRb.velocity.normalized * speedMax;
        }
    }
}
