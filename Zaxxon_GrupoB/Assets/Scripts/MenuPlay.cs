using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    //boton play para ir a la escena de zaxxon y jugar
    public void Play()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }

    //boton highscore para ir a la escena de puntuacion 
    public void HIGHSCORE()
    {
        SceneManager.LoadScene("Menu_HighScore");

    }
}

