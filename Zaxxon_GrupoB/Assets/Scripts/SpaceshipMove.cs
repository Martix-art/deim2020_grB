using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importa esta librería para usar la UI
using UnityEngine.Rendering;


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
    //Capturo el texto del UI que indicará la velocidad
    [SerializeField] Text TextSpeed;
    //Variable para parar el juego
    //[SerializeField] MeshRenderer myMesh;
    //capturar canvas game over
    public GameObject Pantalla;
    //capturas script canvas game over
    private GameOver gameOver;
    //variables para la explosion de la nave
    public Transform explosionPrefab;
    public GameObject SpaceShip;
    public Component[] Renderizado;
    public AudioSource motor;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        //llamo a la corrutina velocidad
        StartCoroutine("Speed");
        //cuando nos chocamos sale el canvas de game over
        gameOver = GetComponent<GameOver>();
        //llamanos al objeto de la nave
        SpaceShip = GameObject.Find("Spaceship");
        //variable sonido motor
        motor = GetComponent<AudioSource>();
       
    }
   
    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

    }
    //codigo para la colision
    void OnCollisionEnter(Collision collision)
    {
        
        //desaparece la maya de la nave
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);

        Renderer[] rs = SpaceShip.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        r.enabled = false;

        //la velocidad se para
        speed = 0f;
        //la corutine se para
        StopCoroutine("Distancia");
        //invocar el menu de game over
        Invoke("MostrarPantalla", 4.5f);
        //parar sonido motor
        motor.Stop();

    }

    void MostrarPantalla()
    {
        //aparece game over
        Pantalla.SetActive(true);
    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 1)
        {
            float distance;
            distance = n * speed;
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCE - " + distance.ToString("F0");
            
            //cada ciclo aumenta la velocidad
            if(speed < 26f)
            {
                speed = speed + 0.2f;
            }
           
            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    IEnumerator Speed()
    {
        for (int s = 0; ; s += 5)
        {
            TextSpeed.text = "SPEED - " + (speed * 5f).ToString("F0");
            yield return new WaitForSeconds(1f);    
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
        else if (transform.position.y > 4f && desplY > 0)
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
