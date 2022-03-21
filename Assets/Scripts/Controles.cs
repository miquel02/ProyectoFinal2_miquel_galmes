using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles: MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE COBNTROLAR L'ESCENA DE CONTROLES

    //Funcio per fer que el botó de main menu ens dugui al menu
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

}

