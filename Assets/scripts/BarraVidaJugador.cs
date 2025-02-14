using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaJugador : MonoBehaviour
{

    [SerializeField]                                            //Para que se vea aunque est� privado
    private float vidaMaxima = 100;                             //Creamos la variable de vida m�xima para almacenar la vida total            
    
    public float vidaActual = 100;                              //Creamos la variable de vida actual para saber cuanta vida tiene el jugador
    [SerializeField]                                            //Para que se vea aunque est� privado
    private float danyoBala = 5;                                //Creamos la variable que almacene el da�o de la bala
    [SerializeField]                                            //Para que se vea aunque est� privado
    private Image barraVida;                                    //Creamos la variable que almacene la imagen de la vida
 
    private void Awake()                                        //En el Awake
    {
        vidaActual = vidaMaxima;                                //Empezamos con que la vida actual es la m�xima
        barraVida.fillAmount = 1;                               //Decimos que muestre la barra de vida (fillAmount --> 0 no muestra Imagen - 1 muestra Imagen completa)
    }

    private void OnTriggerEnter(Collider other)                 //Usamos el m�todo OnTrigger para las colisiones
    {
        if (other.tag == "BalaEnemigo"){                        //Si con lo que choca tiene el tag BalaEnemigo
            vidaActual -= danyoBala;                            //Se le resta el da�o de la bala a la vida actual
            barraVida.fillAmount = vidaActual / vidaMaxima;     //Decimos que la barra de vida sea el porcentaje de vida actual
            Destroy(other.gameObject);                          //Destruyan los gameObjects que colapsen

            if (vidaActual <= 0)                                //Si la vida actual es menos o igual a 0
            {
                Muerte();                                       //Se ejecuta el m�todo muerte
            }
        }
    }

    private void Muerte()                                       //Creamos el m�todo muerte
    {
        Camera.main.transform.SetParent(null);                  //La c�mara se desenparenta
        Destroy(gameObject, 0.8f);                              //Se destruye el jugador en 0,8s
        GameOver.Instance.GameeOver();                          //Se ejecuta la pantalla de GameOver
    }
}
