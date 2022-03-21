using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE FER QUE LES BALES DESAPERESQUIN SI SURTEN DEL MAPA

    //Variables per determinar el limits
    private float upperLim = 50f;
    private float lowerLim = -50f;
 
    void Update()
    {       
        if (transform.position.z > upperLim)
        {
            Destroy(gameObject);
        }
       
        if (transform.position.z < lowerLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > upperLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < lowerLim)
        {
            Destroy(gameObject);
        }
    }
}
