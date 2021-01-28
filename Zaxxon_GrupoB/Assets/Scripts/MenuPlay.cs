using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }

    public void HIGHSCORE()
    {
        SceneManager.LoadScene("Menu_HighScore");

    }
}

