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
    private bool air;
    private float moveH;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        grounded = true;
        air = false;
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

        moveH = -Input.GetAxis("Horizontal");
        if (air)
        {
          //  transform.Translate(Vector2.left * moveH * speed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {

        playerRb.AddTorque(moveH * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
       LimitMaxSpeed();
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Ground");
        grounded=true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        air= true;
    }
    void LimitMaxSpeed()
    {
        if(playerRb.velocity.magnitude > speedMax)
        {
            playerRb.velocity = playerRb.velocity.normalized * speedMax;
        }
    }
}
