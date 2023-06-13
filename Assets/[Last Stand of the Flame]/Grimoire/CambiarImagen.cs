using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CambiarImagen : MonoBehaviour
{
    public List<Sprite> imagenes;
    private int indiceActual = 0;
    public Image imagenBoton;

    void Start()
    {
        imagenBoton.sprite = imagenes[indiceActual];
    }

    public void MostrarSiguienteImagen()
    {
        indiceActual++;
        if (indiceActual >= imagenes.Count)
        {
            indiceActual = 0;
        }

        imagenBoton.sprite = imagenes[indiceActual];
        Debug.Log("Imagen actual:" + imagenes[indiceActual].name);
    }

    public void MostrarImagenAnterior()
    {
        indiceActual--;
        if (indiceActual < 0)
        {
            indiceActual = imagenes.Count - 1;
        }

        imagenBoton.sprite = imagenes[indiceActual];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            MostrarSiguienteImagen();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MostrarImagenAnterior();
        }
    }
}
