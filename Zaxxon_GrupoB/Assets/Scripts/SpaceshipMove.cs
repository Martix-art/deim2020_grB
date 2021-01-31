using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI


public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    //Variable para parar el juego
    [SerializeField] MeshRenderer myMesh;
    //capturar canvas game over
    public GameObject Canvas;
    //capturas scrpt canvas game over
    private GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        //cuando nos chocamos sale el canvas de game over
        gameOver = GetComponent<GameOver>();

    }
   
    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

    }
    //codigo para la colision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            //desaparece la maya
            myMesh.enabled = false;
            //la velocidad se para
            speed = 0f;
            //la corutine se para
            StopCoroutine("Distancia");
            //aparece game over
            Canvas.SetActive(true);
        }

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 1)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n * speed;

            //cada ciclo aumenta la velocidad
            if(speed < 26)
            {
                speed = speed + 0.3f;
            }
           
            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(0.50f);
        }
        
    }


    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        if (transform.position.x < -5.6f && desplX < 0)
        {
            desplX = 0f;
        }
        else if (transform.position.x > 5.6f && desplX > 0)
        {
            desplX = 0f;
        }
        
        float desplY = Input.GetAxis("Vertical");

        if (transform.position.y < 0f && desplY < 0)
        {
            desplY = 0f;
        }
        else if (transform.position.y > 3f && desplY > 0)
        {
            desplY = 0f;
        }
        

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        //Space.World es lo que hace que la nave gire entorno a su eje al realizar los giros
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY, Space.World);

        //transform.rotation permitimos la arotacion en z, pero si no se mueve el joystick esta permanece horizontal
        //50 es el angulo maximo de inclinacion
        transform.rotation = Quaternion.Euler(0, 0, desplX * -50);
    }

}
