using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOffset : MonoBehaviour
{
    //componente de tipo renderer
    Renderer rend;
    //vector de desplazamiento
    [SerializeField] Vector2 despl;
    //Datos del juego
    SpaceshipMove initgame;

    // Start is called before the first frame update
    void Start()
    {
        //asignamos el componente render
        rend = GetComponent<Renderer>();

        //obtener el script
        GameObject InitEmpty = GameObject.Find("Spaceship");
        initgame = InitEmpty.GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollSpeed = initgame.speed / 3.5f;//velocidad de desplazamiento
        //distancia de desplazamiento, segun el tiemp transc.
        float offset = Time.time * scrollSpeed;
        //vector de desplazamiento
        despl = new Vector2(0, offset);
        //desplazamos la textura albedo y la normal
        rend.material.SetTextureOffset("_MainTex", despl);
        rend.material.SetTextureOffset("_BumpMap", despl);
       
    }
}
