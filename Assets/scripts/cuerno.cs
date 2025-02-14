using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerno : MonoBehaviour
{
    private int velocidad = 100;                                        //Creamos una variable para almacenar la velocidad del cuerno

    void Start()                                                        //En el Start
    {
        Destroy(gameObject, 5);                                         //Destruimos el cuerno cada 5s
    }

    void Update()                                                       //En el update ejecutamos
    {
        Moverse();                                                      //Moverse
    }

    private void Moverse()                                              //Creamos el método moverse
    {
        Vector3 direccion = Vector3.forward;                            //Creamos un vector que vaya hacia delante
        transform.Translate(direccion * velocidad * Time.deltaTime);    //Decimos que se mueva hacia delante con X velocidad por fotograma por segundo
    }
}
