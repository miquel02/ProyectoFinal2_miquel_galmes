using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
   public float speed = 20f;
   public float turnspeed = 40f;
    private float horizontalInput;
    private float verticalInput;

    public ParticleSystem trailParticleSystem;
    /*

   private Rigidbody playerRigidbody;

  public float speed = 10f;
  public float turnspeed = 40f;
  private GameObject focalPoint;
  */

    void Start()
    {
       //playerRigidbody = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        // Usamos los inputs del Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Mueve el tanque hacia delante y atras. 
       transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        
        transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
        
        
        if(verticalInput > 0 && verticalInput < 0)
        {
            trailParticleSystem = Instantiate(trailParticleSystem, transform.position, trailParticleSystem.transform.rotation);
            trailParticleSystem.Play();
        }

        /*
        float verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(transform.forward * speed * verticalInput);
        //float horizontalInput = Input.GetAxis("Horizontal");
        //playerRigidbody.AddTorque(Vector3.up * turnspeed * horizontalInput);

        Debug.Log(speed * verticalInput);
        */

    }

    
}

