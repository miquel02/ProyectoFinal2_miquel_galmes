using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurret : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE CONTROLAR LA TORRETA I CAMERA DEL PLAYER

    //Accedim al script PlayerController per tenir les variables gameOver i victory 
    private PlayerController playerControllerScript;

    //Determinam la velocitat de la camara
    public float speedH;
    public float speedV;

    float yaw;
    float pitch;

    public GameObject cabina;

    //Determinam la bala
    public GameObject projectilePrefab;

    //Determinam el temps entre dispars
    private bool IsCoolDown = true;
    private float shootSpeed = 1f;

    void Start()
    {
        //Accedim al script PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //Controlam la camara
        if(!playerControllerScript.gameOver && !playerControllerScript.victory)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch += speedV * Input.GetAxis("Mouse Y");

            cabina.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
        }
        
        //Dispar
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsCoolDown && !playerControllerScript.gameOver && !playerControllerScript.victory)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            StartCoroutine(CoolDown());
        }       
    }
    
    //Funciò per el cooldown 
    private IEnumerator CoolDown()
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDown = true;
        
    }   

}
