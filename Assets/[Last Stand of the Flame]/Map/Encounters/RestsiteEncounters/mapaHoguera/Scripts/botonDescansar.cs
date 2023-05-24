using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonDescansar : MonoBehaviour
{
    public GameObject resultCanvasHoguera;


    public void ActivarResultCanvasHoguera()
    {
        FadeToBlack.QuickFade();
        Invoke("HolaDani", 0.25f);
        
    }

    // Hola Dani! Gracias por revisar nuestro código!
    public void HolaDani()
    {
        FadeToBlack.QuickReverseFade();
        //Debug.Log("Activando el canvas de resultados de la hoguera!");
        resultCanvasHoguera.SetActive(true);
    }
}
