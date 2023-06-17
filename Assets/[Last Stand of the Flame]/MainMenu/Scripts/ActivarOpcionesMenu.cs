using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarOpcionesMenu : MonoBehaviour
{
    public GameObject MenuOpciones;

    public void ActivarMenuOpciones()
    {
        MenuOpciones.SetActive(true);
    }

    public void DesactivarMenuOpciones()
    {
        MenuOpciones.SetActive(false);
    }
}