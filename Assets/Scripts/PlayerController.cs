using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE CONTROLAR EL PLAYER

    //Variables per determinar el estat de gameover i victori
    public bool gameOver;
    public bool victory;

    //Variables per determinar el moviment
    public float speed = 20f;
    public float turnspeed = 40f;
    private float horizontalInput;
    private float verticalInput;

    //Variables per guardar els sistemes de particuales
    public ParticleSystem explosionParticleSystem;

    //Variables per controlar la vida
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBar;

    //Variables per controlar l'score
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int maxScore = 20;


    void Start()
    {
        victory = false;
        gameOver = false;
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth);       
    }

    void Update()
    {
        //Si gameover i victory son falses
        if(!gameOver && !victory)
        {
            // Usamos los inputs del Input Manager
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //Mueve el tanque hacia delante y atras. 
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime * horizontalInput);
        }
        
        //Si sa vida baixa a 0 gameover=true
        if(currentHealth == 0)
        {
            gameOver = true;
        }

        //Per no passarnos de la vida maxima
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //Si arriban a maxScore victory = true
        if(score == maxScore)
        {
            victory = true;
        }
    }

    //funcio per baixar la vida
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //funcio per pujar la vida
    void HealDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
    }

    //funcio per detecgar colisions
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Building") && !gameOver && !victory)
        {
            //Si ferima un edifici rebem mal
            TakeDamage(5);
            //Instanciam les particules
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
        }

        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Bullet") && !gameOver && !victory)
        {
            //Si en feren perdem vida
            TakeDamage(10);
        }

        if (gameObject.CompareTag("Player") && otherCollider.gameObject.CompareTag("Healing") && !gameOver && !victory)
        {
            //Si agafam una curaciò ens curam
            HealDamage(30);
            Destroy(otherCollider.gameObject);
        }
    } 

    //Funció per actualitzar la puntuacio
    public void UpdateScore(int pointsToAdd)
        {
            score ++;//Linea per actualitzar l'score
            scoreText.text = $"TANKS LEFT: {score}/{maxScore}";
        }
    
}