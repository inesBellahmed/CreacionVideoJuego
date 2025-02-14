using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDanyo : MonoBehaviour
{

    [SerializeField]                                //Para que se vea aunque est� privado
    private ParticleSystem explosionGrande;         //Creamos variable que almacena part�culas
    [SerializeField]                                //Para que se vea aunque est� privado
    private ParticleSystem explosionPequnya;        //Creamos variable que almacena part�culas
    [SerializeField]                                //Para que se vea aunque est� privado
    private BarraVidaJugador vidaJugador;           //Llamamos al Script de la barra de vida del jugador

    private void Awake()
    {
        explosionGrande.Stop();                     //La explosi�n de part�culas no se ejecute
        explosionPequnya.Stop();                    //La explosi�n de part�culas no se sejecute
    }

    private void OnTriggerEnter(Collider other)     //Usamos el m�todo OnTrigger para las colisiones
    {
        if (other.tag == "BalaEnemigo")             //Si con lo que choca tiene el tag BalaEnemigo
        {
            explosionPequnya.Play();                //La explosi�n de part�culas se ejecuta
        }

        if (vidaJugador.vidaActual == 0)            //Si la vida actual es menos o igual a 0
        {
            explosionGrande.Play();                 //La explosi�n de part�culas se ejecuta
        }
    }


}
