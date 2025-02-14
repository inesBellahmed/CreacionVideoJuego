using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{

    [SerializeField]                                            //Para que se vea aunque esté privado
    private float vidaMaxima = 100;                             //Creamos la variable de vida máxima para almacenar la vida total

    public float vidaActual = 100;                              //Creamos la variable de vida actual para saber cuanta vida tiene el jugador
    [SerializeField]                                            //Para que se vea aunque esté privado
    private float danyoBala = 5;                                //Creamos la variable que almacene el daño de la bala
    [SerializeField]                                            //Para que se vea aunque esté privado
    private Image barraVida;                                    //Creamos la variable que almacene la imagen de la vida            

    [SerializeField]                                            //Para que se vea aunque esté privado
    private ParticleSystem explosionGrande;                     //Creamos variable que almacena partículas
    [SerializeField]                                            //Para que se vea aunque esté privado
    private ParticleSystem explosionPequnya;                    //Creamos variable para almacenar partículas

    private void Awake()
    {
        vidaActual = vidaMaxima;                                //Empezamos con que la vida actual es la máxima
        barraVida.fillAmount = 1;                               //Decimos que muestre la barra de vida (fillAmount --> 0 no muestra Imagen - 1 muestra Imagen completa)

        explosionGrande.Stop();                                 //La explosión de partículas no se ejecute
        explosionPequnya.Stop();                                //La explosión de partículas no se sejecute
    }

    private void OnTriggerEnter(Collider other)                 //Usamos el método OnTrigger para las colisiones
    {
        if (other.tag == "BalaJugador")                         //Si con lo que choca tiene el tag BalaJugador
        {                                                       
            vidaActual -= danyoBala;                            //Se le resta el daño de la bala a la vida actual
            barraVida.fillAmount = vidaActual / vidaMaxima;     //Decimos que la barra de vida sea el porcentaje de vida actual
            explosionPequnya.Play();                            //La explosión de partículas se ejecuta
            Destroy(other.gameObject);                          //Destruyan los gameObjects que colapsen

            if (vidaActual <= 0)                                //Si la vida actual es menos o igual a 0
            {
                explosionGrande.Play();                         //La explosión de partículas se ejecuta
                Muerte();                                       //Se ejecuta el método muerte
            }
        }
    }
   
    private void Muerte()                                       //Creamos el método muerte
    {
        Destroy(gameObject, 0.8f);                              //Se destruye el jugador en 0,8s
    }
}
