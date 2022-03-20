using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public bool gameOver;
   
    public float speed = 20f;
    public float turnspeed = 40f;
    private float horizontalInput;
    private float verticalInput;

    public ParticleSystem explosionParticleSystem;

    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;

    public TextMeshProUGUI scoreText;
    private int score = 0;


    void Start()
    {
        //gameOver = false;
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth);       
    }

    void Update()
    {
        if(!gameOver)
        {
            // Usamos los inputs del Input Manager
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //Mueve el tanque hacia delante y atras. 
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
        }
        

        if(currentHealth == 0)
        {
            gameOver = true;
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void HealDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Building"))
        {
            
            TakeDamage(5);

            explosionParticleSystem = Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            explosionParticleSystem.Play();
            //Destroy(explosionParticleSystem);
        }

        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }

        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Healing"))
        {
            HealDamage(30);
            Destroy(otherCollider.gameObject);

        }

       

    } 
    public void UpdateScore(int pointsToAdd)
        {
            score ++;//Linea per actualitzar l'score
            scoreText.text = $"TANKS LEFT: {score}/16";
        }
    
}