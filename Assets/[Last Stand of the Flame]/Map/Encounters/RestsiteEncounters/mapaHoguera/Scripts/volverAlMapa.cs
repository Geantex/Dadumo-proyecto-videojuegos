using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverAlMapa : MonoBehaviour
{
    public void volverMapa()
    {
        Debug.Log("Cargando mapa desde la hoguera");
        SceneManager.LoadScene("Map");
    }
}
