using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //capturamos el canvas
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    //boton replay, vuelves a jugar
    public void Replay()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }

    //boton exit sales a la escena principal
    public void Exit()
    {
        SceneManager.LoadScene("Menu_Inicio");
    }
}
