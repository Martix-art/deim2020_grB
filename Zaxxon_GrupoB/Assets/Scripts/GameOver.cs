using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //capturamos el canvas
    public GameObject gameOver;
    //variables para acceder al sonidoplay
    [SerializeField] AudioClip audioButton;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        //acceder al componente del audio
        audioSource = GetComponent<AudioSource>();
    }

    //boton replay, vuelves a jugar
    public void Replay()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(audioButton);
        //te lleva a una escena
        SceneManager.LoadScene("zaxxon_scene1");
    }

    //boton exit sales a la escena principal
    public void Exit()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(audioButton);
        //te lleva a una escena
        SceneManager.LoadScene("Menu_Inicio");
    }
}
