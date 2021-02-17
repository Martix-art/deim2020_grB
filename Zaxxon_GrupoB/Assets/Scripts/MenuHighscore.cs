using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHighscore : MonoBehaviour
{
    //variables para acceder al sonidoplay
    [SerializeField] AudioClip volverButton;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //boton volver para ir a la escena de inicio
    public void Volver()
    {
        //suena un sonido cuando es pulsado
        audioSource.PlayOneShot(volverButton);
        SceneManager.LoadScene("Menu_Inicio");
    }

}
