using UnityEngine;
using TMPro;

public class CambioPaginas : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshProObjects;  // Arreglo de todos los objetos TextMeshPro que deseas controlar
    private int currentPage = 1;  // �ndice de la p�gina actual
    public int totalPages = 7;
    public SoundManager soundManager;


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
       

        // Calcular el �ndice del nuevo objeto TextMeshPro
        int newPage = currentPage + pageOffset;

        // Verificar los l�mites del arreglo
        if (newPage <= 0)
        {
            newPage = totalPages;  // Ir al �ltimo objeto TextMeshPro
        }
        else if (newPage > totalPages)
        {
            newPage = 1;  // Ir al primer objeto TextMeshPro
        }

        foreach (var textObj in textMeshProObjects)
        {
            textObj.pageToDisplay = newPage;

        }
        // Actualizar el �ndice de la p�gina actual
        currentPage = newPage;
        Debug.Log("Pagina actual" + currentPage);
        // Activar el nuevo objeto TextMeshPro
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();

            soundManager.PlayButtonSound1();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPage();
            soundManager.PlayButtonSound2();
        }
    }
}
