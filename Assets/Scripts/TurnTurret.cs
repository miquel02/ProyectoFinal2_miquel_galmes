using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurret : MonoBehaviour
{


    public float speedH;
    public float speedV;

    float yaw;
    float pitch;

    public GameObject cabina;

    public GameObject projectilePrefab;

    private bool IsCoolDown = true;
    private float shootSpeed = 1f;

    void Update()
    {   
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        cabina.transform.Rotate(Vector3.up, yaw * Time.deltaTime);


        //Disoaro
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsCoolDown)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            StartCoroutine(CoolDown());
        }       

    }

    
    
    
    private IEnumerator CoolDown()
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDown = true;
        
    }
    




}
