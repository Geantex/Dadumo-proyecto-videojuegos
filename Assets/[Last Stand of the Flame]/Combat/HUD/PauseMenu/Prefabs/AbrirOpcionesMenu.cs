using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirOpcionesPausa : MonoBehaviour
{
    public GameObject Opciones;

    public void AbrirMenuOpcionesPausa()
    {
        Opciones.SetActive(true);
    }

    public void CerrarMenuOpcionesPausa()
    {
        Opciones.SetActive(false);
    }
}