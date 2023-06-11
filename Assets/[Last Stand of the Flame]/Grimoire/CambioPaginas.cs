using UnityEngine;
using TMPro;

public class CambioPaginas : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshProObjects;  // Arreglo de todos los objetos TextMeshPro que deseas controlar
    private int currentPage = 1;  // Índice de la página actual
    public int totalPages = 7;

    private void Start()
    {
        
    }

    public void NextPage()
    {
        ChangePage(1);
    }

    public void PreviousPage()
    {

        ChangePage(-1);
    }

    private void ChangePage(int pageOffset)
    {
       

        // Calcular el índice del nuevo objeto TextMeshPro
        int newPage = currentPage + pageOffset;

        // Verificar los límites del arreglo
        if (newPage <= 0)
        {
            newPage = totalPages;  // Ir al último objeto TextMeshPro
        }
        else if (newPage > totalPages)
        {
            newPage = 1;  // Ir al primer objeto TextMeshPro
        }

        foreach (var textObj in textMeshProObjects)
        {
            textObj.pageToDisplay = newPage;

        }
        // Actualizar el índice de la página actual
        currentPage = newPage;
        Debug.Log("Pagina actual" + currentPage);
        // Activar el nuevo objeto TextMeshPro
    }
}
