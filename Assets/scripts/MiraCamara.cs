using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraCamara : MonoBehaviour
{
    void Update()                                           //En el update
    {
        transform.LookAt(Camera.main.transform.position);   //Decimos que mire a cámara 
    }
}
