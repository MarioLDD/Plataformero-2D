using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private float speed;
    [SerializeField] private float speedMax;
    private bool grounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private ParticleSystem stela;
     private int coin;
    [SerializeField] private int coinMultl;
    public TMP_Text coinText;
    // private bool falls;
    private float moveH;

    // [SerializeField] private int maxRebound = 5;
    //[SerializeField] private float amortiguacion = 0.5f;
    // [SerializeField] private float velocityMin = 0.1f;
    // [SerializeField] private int numRebounds;
    // private Vector2 velInitial;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        coin = 0;
        coinText.text = "Coins: " + coin.ToString();
        grounded = true;
        // falls = false;
        // numRebounds = 0;
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
        /*
        if (playerRb.velocity.magnitude < velocityMin)
        {
            playerRb.velocity = Vector2.zero;
        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            /*numRebounds++;
            if (numRebounds >= maxRebound)
            {
                playerRb.velocity = Vector2.zero;
            }
            */
        }



        //stela.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin += coinMultl;
            Destroy(collision.gameObject);
            coinText.text = "Coins: " + coin.ToString();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            SceneManager.LoadScene("Victoria");
        }

    }

    void LimitMaxSpeed()
    {
        if (playerRb.velocity.x > speedMax)
        {
            playerRb.velocity = new Vector2(speedMax, playerRb.velocity.y);
        }
    }
}
