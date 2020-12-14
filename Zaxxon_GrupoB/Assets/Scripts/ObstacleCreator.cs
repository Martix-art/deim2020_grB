using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;
    
	//Distancia a la que se crean las columnas iniciales
    [SerializeField] float distanciaInicial = 5;
    
	//Acceder a los componentes de la nave
    public GameObject Nave;
    //Creamos una variable de tipo clase publica "SpaceshipMove"
    private SpaceshipMove spaceshipMove;

    // Start is called before the first frame update
    void Start()
    {
        //Distancia inical 25 columnas
        for (int n = 1; n < 25; n++)
        {
            randomNumber = Random.Range(-7f, 6f);
            Vector3 RandomPos = InitPos.position + new Vector3(randomNumber, 0, n*-5);
            Instantiate(Columna, RandomPos, Quaternion.identity);
            
        }

        //Accedo al script de la nave
        spaceshipMove = Nave.GetComponent<SpaceshipMove>();

        
		
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");

    }

    //Función que crea una columna en una posición Random
    void CrearColumna()
    {
        randomNumber = Random.Range(-7f, 6f);
        RandomPos = new Vector3(randomNumber, 0, 0);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna();
            float interval = 4 / spaceshipMove.speed;
            yield return new WaitForSeconds(interval);
        }

    }


}
