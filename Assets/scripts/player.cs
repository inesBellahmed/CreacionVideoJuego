using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    private int speed = 50;                                                     //Creamos velocidad del jugador para avanzar
    [SerializeField]                                                            //Para que se vea aunque est� privado
    private int turnSpeed = 150;                                                //Creamos velocidad del jugador para girar

    [SerializeField]                                                            //Para que se vea aunque est� privado
    private GameObject misil;                                                   //Creamos un GameObject que contenga el misil
    [SerializeField]                                                            //Para que se vea aunque est� privado
    private Transform[] misiles;                                                //Creamos un array de transforms para que contenga las coordenadas
   
    private AudioSource misilSource;                                            //Creamos un audio que contenga el audio del misil

    private void Awake()                                                        //En el Awake(se ejecuta antes de empezar)
    {
      misilSource = GetComponent<AudioSource>();                                //Decimos que coja el audio del audioSource
        Cursor.lockState = CursorLockMode.Locked;                               //Decimos que el cursor no salga de la pantalla(que no aparezca)
    }

    void Update()                                                               //En el update ejecutamos
    {
        movimiento();                                                           //El movimiento
        Giro();                                                                 //El giro
        Ataque();                                                               //El ataque
    }

    private void movimiento()                                                   //Creamos el m�todo del movimiento
    {
        float horizontal = Input.GetAxis("Horizontal");                         //Creamos variable que vaya horizontal
        float vertical = Input.GetAxis("Vertical");                             //Creamos variable que vaya vertical
        Vector3 direction = new Vector3(horizontal, 0, vertical);               //Creamos la direcci�n que ser�: horizontal, 0, vertical
        transform.Translate(direction.normalized * speed * Time.deltaTime);	    //Que se mueva en la direcci�n a la velocidad dada por cada frame
    }

    private void Giro()                                                         //Creamos el m�todo de giro
    {
        float xMouse = Input.GetAxis("Mouse X");                                //Creamos variable que vaya horizontal
        float yMouse = Input.GetAxis("Mouse Y");                                //Creamos variable que vaya vertical
        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);                     //Creamos la rotaci�n que ser�: -vertical(para que funcione bien), horizontal, 0
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);     //Que se rote en la rotaci�n dada con la velocidad y cada frame
    }

    private void Ataque()                                                       //Creamos el m�todo de atacar
    {
        if (Input.GetMouseButtonDown(0))                                        //Si se pulsa el boton Izquierdo del rat�n
        {
            for (int i = 0; i < misiles.Length; i++) {                          //Creamos un bucle
                Instantiate(misil, misiles[i].position, misiles[i].rotation);   //Que instancia los misiles en X posici�n y X rotaci�n
            }
            misilSource.Play();                                                 //Se llama al sonido del misil
        }
    }

    

}
