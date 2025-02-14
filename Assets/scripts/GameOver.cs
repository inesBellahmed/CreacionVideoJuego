using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance { get; private set; }       //Hacemos que el Script pueda ser llamado?

    [SerializeField]                                            //Para que se vea aunque est� privado
    private GameObject panelGameOver;                           //Creamos un gameObject para almacenar el panel
    [SerializeField]                                            //Para que se vea aunque est� privado
    private GenerarEnemigos enemigos;                           //Llamamos al Script de generarEnemigos
  
    void Awake()                                                //En el Awake
    {
        Instance = this;                                        //Es la declaraci�n del singeltone
    }

    public void GameeOver()                                     //Creamos el m�todo gameOver
    {
        panelGameOver.SetActive(true);                          //Decimos que el panel se active
        enemigos.enabled = false;                               //Decimos que el Script de los enemigos se desactive(Enabled es el tick de activar o desactivar)
        enemigos.CancelInvoke("CrearEnemigos");                 //Cancela el invoke del generador de enemigos para que no salgan m�s
        Cursor.lockState = CursorLockMode.Confined;             //El cursor se puede mover por la pantalla
    }

    public void CargarNivel()                                   //Creamos el m�todo de Cargarnivel
    {
        SceneManager.LoadScene("Level01");                      //En el se carga el nivel
    }
}
