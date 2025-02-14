using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    private int velocidadEnemigo = 25;                                                          //Creamos la variable de la velocidad del enemigo
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    private float distanciaJugador = 55;                                                        //Creamos la variable de la distancia con el jugador
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    GameObject jugador;                                                                         //Creamos un gameObject que contenga al jugador
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    private GameObject cuerno;                                                                  //Creamos un gameObject que almacene el cuerno
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    private Transform[] cuernos;                                                                //Creamos un array de transform para almacenar las coordenadas
    [SerializeField]                                                                            //Para que se vea aunque esté privado
    private float tiempoBalas;                                                                  //Creaoms una variable para almacenar el tiempo entre las balas
    private AudioSource Cuernada;                                                               //Creamos un audioSource para almacenar el audio del cuerno

    void Update()                                                                               //En el update
    {
        if (jugador == null)                                                                    //Si el jugador ha sido destruido 
        {
            CancelInvoke("Atacar");                                                             //Paran de atacar
            return;                                                                             //Paramos la ejecución
        }
                                                                                        
        transform.LookAt(jugador.transform.position);                                           //Que el enemigo mire al jugador
        Perseguir();                                                                            //Ejecutamos el método de perseguir
    }

    private void Awake()                                                                        //En el awake
    {
        jugador = GameObject.                                                                   //Decimos que el jugador es un gameObject
            FindGameObjectWithTag("Player");                                                    //Que busque el gameObject con el tag de Player

        Cuernada = GetComponent<AudioSource>();                                                 //Que coja el audio del audioSource
        InvokeRepeating("Atacar", 1, tiempoBalas);                                              //Que ejecute el método Atacar 1 vez cada X tiempo

    }

    private void Perseguir()                                                                    //Creamos el método de perseguir
    {
        float distancia = Vector3.Distance(transform.position, jugador.transform.position);     //Creamos una variable que almacene la distancia entre el enemigo y el jugador
            
        if (distancia > distanciaJugador) {                                                     //Si la distancia es mayor que la distancia del jugador
            transform.Translate(Vector3.forward * velocidadEnemigo * Time.deltaTime);           //Se mueve hacia delante a X velocidad por fotograma por segundo 
        }
    }

    private void Atacar()                                                                       //Creamos el método atacar
    {
        Cuernada.Play();                                                                        //Ejecutamos el audio del cuerno                                 
        for (int i = 0; i < cuernos.Length; i++) {                                              //Creamos un bucle que
            Instantiate(cuerno, cuernos[i].position, cuernos[i].rotation);                      //Instancia los cuernos en X posición y en X rotación
        }
    }
}
