using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDanyo : MonoBehaviour
{

    [SerializeField]                                //Para que se vea aunque esté privado
    private ParticleSystem explosionGrande;         //Creamos variable que almacena partículas
    [SerializeField]                                //Para que se vea aunque esté privado
    private ParticleSystem explosionPequnya;        //Creamos variable que almacena partículas
    [SerializeField]                                //Para que se vea aunque esté privado
    private BarraVidaJugador vidaJugador;           //Llamamos al Script de la barra de vida del jugador

    private void Awake()
    {
        explosionGrande.Stop();                     //La explosión de partículas no se ejecute
        explosionPequnya.Stop();                    //La explosión de partículas no se sejecute
    }

    private void OnTriggerEnter(Collider other)     //Usamos el método OnTrigger para las colisiones
    {
        if (other.tag == "BalaEnemigo")             //Si con lo que choca tiene el tag BalaEnemigo
        {
            explosionPequnya.Play();                //La explosión de partículas se ejecuta
        }

        if (vidaJugador.vidaActual == 0)            //Si la vida actual es menos o igual a 0
        {
            explosionGrande.Play();                 //La explosión de partículas se ejecuta
        }
    }


}
