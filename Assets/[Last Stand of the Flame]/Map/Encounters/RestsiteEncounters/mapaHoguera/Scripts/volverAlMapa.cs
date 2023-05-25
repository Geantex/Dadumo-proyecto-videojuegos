using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverAlMapa : MonoBehaviour
{
    public GameObject botonMatar;
    public void volverMapa()
    {
        botonMatar.SetActive(false);
        FadeToBlack.QuickFade();
        Invoke("HolaDani2", 0.28f);
    }

    // Hola otra vez Dani!
    public void HolaDani2()
    {
        //Debug.Log("Cargando mapa desde la hoguera");
        SceneManager.LoadScene("Map");
    }
}
