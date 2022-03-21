using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE COBNTROLAR L'ESCENA DE MAIN MENU

    //Funcio per fer que el botó de start ens dugui al joc
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }

    //Funcio per fer que el botó de controles ens dugui als controls
    public void ControlsScene()
    {
        SceneManager.LoadScene("Controles");
    }
}
