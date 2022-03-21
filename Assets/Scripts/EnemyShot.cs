using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE FER QUE ELS ENEMICS DISPARIN

    //Accedim al script PlayerController per tenir les variables gameOver i victory 
    private PlayerController playerControllerScript;

    //Variable per tenir el projectil
    public GameObject projectilePrefab;

    //Variables per determinar el temps que tarden entre dispars
    private bool IsCoolDown = true;
    private float shootSpeed = 4f;

    void Start()
    {
        //Accedim al script PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //L'enemic disparara si el gameOver i el victory son false
        if (IsCoolDown && !playerControllerScript.gameOver && !playerControllerScript.victory)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            StartCoroutine(CoolDown());
        }
    }

    //Funció per fer que l'enemic esperi per tornar a disparar
    private IEnumerator CoolDown()
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDown = true;
    }
}