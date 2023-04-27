using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stela : MonoBehaviour
{
    private ParticleSystem stela;
    private ParticleSystem.EmissionModule emissionModule;
    public GameObject player;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        stela = GetComponent<ParticleSystem>();
        emissionModule = stela.emission;
       playerRb = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position;
        if (playerRb.velocity.x >0)
        {
            Debug.Log("derecha");
            transform.rotation = Quaternion.Euler(-170, 90, 90);
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(-10, 90, 0);
            Debug.Log("izquierda");
            

        }
        emissionModule.rate = playerRb.velocity.magnitude;
       // stela.emission.
        
    }
}
