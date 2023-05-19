using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonDescansar : MonoBehaviour
{
    public GameObject resultCanvasHoguera;


    public void ActivarResultCanvasHoguera()
    {
        Debug.Log("Activando el canvas de resultados de la hoguera!");
        resultCanvasHoguera.SetActive(true);
    }
}
