using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaCompleta : MonoBehaviour
{
    public void Pantallacompleta(bool is_Fullscreen)
    {
        Screen.fullScreen = is_Fullscreen;
        //Debug.Log("Estoy en " + is_Fullscreen);
    }
}