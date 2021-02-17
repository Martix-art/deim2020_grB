using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
    //variables para acceder al sonidoplay
    [SerializeField] AudioClip audioButton;
    private AudioSource audioSource;

    void Start()
    {
        //acceder al componente del audio
        audioSource = GetComponent<AudioSource>();
    }

    //boton play para ir a la escena de zaxxon y jugar
    public void Play()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(audioButton);
        //te lleva a una escena
        SceneManager.LoadScene("zaxxon_scene1");
    }

    //boton highscore para ir a la escena de puntuacion 
    public void HIGHSCORE()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(audioButton);
        //te lleva a una escena
        SceneManager.LoadScene("Menu_HighScore");

    }
}

