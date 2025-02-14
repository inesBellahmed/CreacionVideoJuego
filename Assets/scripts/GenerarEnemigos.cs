using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
        
    [SerializeField]                                                            //Para que se vea aunque esté privado
    private GameObject enemigo;                                                 //Creamos un gameObject que almacene al enemigo
    [SerializeField]                                                            //Para que se vea aunque esté privado
    private Transform[] enemigos;                                               //Creamos un array tipo transform para almacenar las coordenadas
    [SerializeField]                                                            //Para que se vea aunque esté privado
    private float tiempoEntreEnemigos = 5.0f;                                   //Creamos una variable para almacenar el tiempo entre los enemigos
    
    void Start()                                                                //En el start
    {
        InvokeRepeating("CrearEnemigos", 1.0f, tiempoEntreEnemigos);            //Decimos que ejecute el método CrearEnemigos 1vez cada X tiempo
    }

    private void CrearEnemigos()                                                //Creamos el método de CrearEnemigos
    {
        int n = Random.Range(0, enemigos.Length);                               //Creamos una variable que almacene numeros random para generar los enemigos desde la posición 0 hasta donde se hayan creado las posiciones
        Instantiate(enemigo, enemigos[n].position, enemigos[n].rotation);       //Instancie los enemigos en las posiciones y rotaciones de las coordeanas almacenadas anteriormente de forma aleatoria
    }
}
