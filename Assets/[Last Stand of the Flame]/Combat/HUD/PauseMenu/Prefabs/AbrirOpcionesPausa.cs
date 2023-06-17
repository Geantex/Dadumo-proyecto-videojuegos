using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Opciones;

    public void ActivarMenuOpciones()
    {
        Opciones.SetActive(true);
    }

    public void DesactivarMenuOpciones()
    {
        Opciones.SetActive(false);
    }
}