using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem bigExplosionParticleSystem;

    private void OnTriggerEnter(Collider otherCollider)
    {

        if (gameObject.CompareTag("Shell") && otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Destruyo el proyectil
            Destroy(gameObject);


            // Destruyo el animal contra el que colisiona
            Destroy(otherCollider.gameObject);

            
            explosionParticleSystem = Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            explosionParticleSystem.Play();
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


            bigExplosionParticleSystem = Instantiate(bigExplosionParticleSystem, transform.position, bigExplosionParticleSystem.transform.rotation);
            bigExplosionParticleSystem.Play();
            //Destruyo el proyectil
            Destroy(gameObject);


            // Destruyo el animal contra el que colisiona
            //Destroy(otherCollider.gameObject);
        }

    }

}