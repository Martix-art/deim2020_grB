using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHighscore : MonoBehaviour
{
    //boton volver para ir a la escena de inicio
    public void Volver()
    {
        SceneManager.LoadScene("Menu_Inicio");
    }

}
