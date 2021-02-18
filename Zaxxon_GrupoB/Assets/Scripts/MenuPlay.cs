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
        //te lleva a una escena y despues del audio
        Invoke("CargarEscenaG", audioButton.length);
        
    }

    //boton play para ir a la escena de HighScore
    public void HighScore()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(audioButton);
        //te lleva a una escena y despues del audio
        Invoke("CargarEscenaHS", audioButton.length);
        
    }
    
    //cargar la escena
    void CargarEscenaHS()
    {
        SceneManager.LoadScene("Menu_HighScore");
    }
    //cargar la escena
    void CargarEscenaG()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }
}

