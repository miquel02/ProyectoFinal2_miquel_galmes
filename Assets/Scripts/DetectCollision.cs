using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private PlayerController playerControllerScript;

    public int points;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem bigExplosionParticleSystem;

    public ParticleSystem coinParticleSystem;
    public ParticleSystem healthParticleSystem;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {

        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Destruyo el proyectil
            Destroy(gameObject);


            // Destruyo el animal contra el que colisiona
            Destroy(otherCollider.gameObject);

            //coinParticleSystem = Instantiate(coinParticleSystem, transform.position, coinParticleSystem.transform.rotation);
            //coinParticleSystem.Play();

            healthParticleSystem = Instantiate(healthParticleSystem, transform.position, healthParticleSystem.transform.rotation);
            healthParticleSystem.Play();

            explosionParticleSystem = Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            explosionParticleSystem.Play();


            playerControllerScript.UpdateScore(points);
        }

        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Building"))
        {

            
            bigExplosionParticleSystem = Instantiate(bigExplosionParticleSystem, transform.position, bigExplosionParticleSystem.transform.rotation);
            bigExplosionParticleSystem.Play();
            //Destruyo el proyectil
            Destroy(gameObject);


            // Destruyo el animal contra el que colisiona
            Destroy(otherCollider.gameObject);
        }

        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Nature"))
        {


            
            //Destruyo el proyectil
            Destroy(gameObject);


            // Destruyo el animal contra el que colisiona
            //Destroy(otherCollider.gameObject);
        }

        if (gameObject.CompareTag("Bullet") && otherCollider.gameObject.CompareTag("Player"))
        {
            //Destruyo el proyectil
            Destroy(gameObject);

            explosionParticleSystem = Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            explosionParticleSystem.Play();
        }

        if (gameObject.CompareTag("Bullet") && otherCollider.gameObject.CompareTag("Building"))
        {
            //Destruyo el proyectil
            Destroy(gameObject);


            bigExplosionParticleSystem = Instantiate(bigExplosionParticleSystem, transform.position, bigExplosionParticleSystem.transform.rotation);
            bigExplosionParticleSystem.Play();
            Destroy(bigExplosionParticleSystem);
            
        }

    }

}