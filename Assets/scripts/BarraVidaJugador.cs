using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaJugador : MonoBehaviour
{

    [SerializeField]                                            //Para que se vea aunque esté privado
    private float vidaMaxima = 100;                             //Creamos la variable de vida máxima para almacenar la vida total            
    
    public float vidaActual = 100;                              //Creamos la variable de vida actual para saber cuanta vida tiene el jugador
    [SerializeField]                                            //Para que se vea aunque esté privado
    private float danyoBala = 5;                                //Creamos la variable que almacene el daño de la bala
    [SerializeField]                                            //Para que se vea aunque esté privado
    private Image barraVida;                                    //Creamos la variable que almacene la imagen de la vida
 
    private void Awake()                                        //En el Awake
    {
        vidaActual = vidaMaxima;                                //Empezamos con que la vida actual es la máxima
        barraVida.fillAmount = 1;                               //Decimos que muestre la barra de vida (fillAmount --> 0 no muestra Imagen - 1 muestra Imagen completa)
    }

    private void OnTriggerEnter(Collider other)                 //Usamos el método OnTrigger para las colisiones
    {
        if (other.tag == "BalaEnemigo"){                        //Si con lo que choca tiene el tag BalaEnemigo
            vidaActual -= danyoBala;                            //Se le resta el daño de la bala a la vida actual
            barraVida.fillAmount = vidaActual / vidaMaxima;     //Decimos que la barra de vida sea el porcentaje de vida actual
            Destroy(other.gameObject);                          //Destruyan los gameObjects que colapsen

            if (vidaActual <= 0)                                //Si la vida actual es menos o igual a 0
            {
                Muerte();                                       //Se ejecuta el método muerte
            }
        }
    }

    private void Muerte()                                       //Creamos el método muerte
    {
        Camera.main.transform.SetParent(null);                  //La cámara se desenparenta
        Destroy(gameObject, 0.8f);                              //Se destruye el jugador en 0,8s
        GameOver.Instance.GameeOver();                          //Se ejecuta la pantalla de GameOver
    }
}
