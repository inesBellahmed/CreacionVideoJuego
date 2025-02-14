using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misil : MonoBehaviour
{

    private int velocidad = 100;                                        //Creamos la velocidad del misil
    
    void Start()                                                        //En el Start 
    {
        Destroy(gameObject, 5);                                         //Decimos que se destruya el objeto en 5 segundos
    }

    void Update()                                                       //En el Update ejecutamos
    {
        Moverse();                                                      //El movimiento
    }

    private void Moverse()                                              //Creamos el método para que se mueva
    {
        Vector3 direccion = Vector3.forward;                            //Creamos un vector que vaya hacia delante            
        transform.Translate(direccion * velocidad * Time.deltaTime);    //Se mueva hacia el frente a X velocidad por fotograma por segundo
    }
}
