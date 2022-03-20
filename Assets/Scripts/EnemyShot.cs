using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public GameObject projectilePrefab;

    private bool IsCoolDown = true;
    private float shootSpeed = 4f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        //Disoaro
        if (IsCoolDown && !playerControllerScript.gameOver)
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