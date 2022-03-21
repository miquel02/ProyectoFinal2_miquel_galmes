using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE CONTROLAR EL PANEL DE GAMEOVER  I VICTORY

    //Accedim al script PlayerController per tenir les variables gameOver i victory 
    private PlayerController playerControllerScript;

    //Variables per guardar el dos panels
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    void Start()
    {
        //Ens asseguram de que els panels estiguin desactivats quan començam el joc
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        //Accedim al script PlayerController
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //Si gameOver es true activam el panel
        if(playerControllerScript.gameOver)
        {
            gameOverPanel.SetActive(true);
        }

        //Si voctory es true activam el panel
        if (playerControllerScript.victory)
        {
            victoryPanel.SetActive(true);
        }
    }

    //Funcio per fer que el botó de main menu ens dugui al menu
    public void GameScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
