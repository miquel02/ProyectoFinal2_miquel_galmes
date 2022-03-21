using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE DETECTAR LES COLISIONS ENTRE LES BALES I ELS ALTRES OBJECTES DEL MAPA

    //Accedim al script PlayerController per tenir les variables gameOver i victory 
    private PlayerController playerControllerScript;

    //Variable per acutalizar la puntuació
    public int points;

    //Variables per guardar els sistemes de particuales
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem bigExplosionParticleSystem;   
    public ParticleSystem healthParticleSystem;

    void Start()
    {
        //Accedim al script PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //Funció per fer una accio quna 2 colliders entren en contacte
    private void OnTriggerEnter(Collider otherCollider)
    {
        //Si la bala entre en contacte amb un enemic
        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Destruim la bala
            Destroy(gameObject);

            //Destruim l'enemic
            Destroy(otherCollider.gameObject);

            //Instanciam el sistema de particules de curació
            healthParticleSystem = Instantiate(healthParticleSystem, transform.position, healthParticleSystem.transform.rotation);
            healthParticleSystem.Play();

            //Instanciam el sistema de particules de explosió
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            
            //Actualitzam la puntuació
            playerControllerScript.UpdateScore(points);
        }

        //Si la bala entre en contacte amb un edifici
        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Building"))
        {
            //Destruim la bala                                 
            Destroy(gameObject);

            //Destruim l'edifici
            Destroy(otherCollider.gameObject);

            //Instanciam el sistema de particules de explosió
            Instantiate(bigExplosionParticleSystem, transform.position, bigExplosionParticleSystem.transform.rotation);
        }

        //Si la bala entre en contacte amb una roca
        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Nature"))
        {
            //Destruim la bala
            Destroy(gameObject);    
        }

        //Si la bala enemiga entre en contacte amb el player
        if (gameObject.CompareTag("Bullet") && otherCollider.gameObject.CompareTag("Player"))
        {
            //Destruim la bala 
            Destroy(gameObject);

            //Instanciam el sistema de particules de explosió
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            explosionParticleSystem.Play();
        }

        //Si la bala enemiga entre en contacte amb un edifici
        if (gameObject.CompareTag("Bullet") && otherCollider.gameObject.CompareTag("Building"))
        {
            //Destruim la bala 
            Destroy(gameObject);

            //Instanciam el sistema de particules de explosió
            Instantiate(bigExplosionParticleSystem, transform.position, bigExplosionParticleSystem.transform.rotation);                            
        }

    }

}