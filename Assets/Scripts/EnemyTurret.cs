using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE FER QUE ELS ENEMICS MIRIN AL PLAYER

    //Variable per guardar la posicio el player
    public Transform target;
   
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;       
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}
