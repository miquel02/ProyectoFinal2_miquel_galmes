using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE FER QUE LES BALES ES MOGUIN

    //Variable que determina la velocitat de la bala
    public float speed = 20f;
    
    void Update()
    {
        //Feim que la bala es mogui per envant
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}