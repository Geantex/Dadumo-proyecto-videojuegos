using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject CameraButtons;
    public GameObject EncounterCanvas;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    Encounter encounter1 = new Encounter();
    Encounter encounter2 = new Encounter();

    [SerializeField] Material encounter1image;
    // Start is called before the first frame update
    void Start()
    {
        createEncounters();
        //startRandomEncounter();
    }



    // Estos son los métodos para empezar y acabar un encuentro aleatorio


    // en startRandomEncounter es donde escribiremos cada "case",
    // que es donde rellenamos el canvas y asignamos las funciones a los botones con el evento correspondiente

    // Ahora puedes mandarle un int para coger un encuentro específico, si no, le mandas 0 para que te dé un evento aleatorio
    public void startRandomEncounter(int encuentroEspecifico)
    {
        // cogerá un numero entre 1 y 2, que son los dos encuentros actuales

        int encuentroAleatorioNumero;
        if(encuentroEspecifico == 0)
        {
            encuentroAleatorioNumero = UnityEngine.Random.Range(1, 3);
        } else
        {
            encuentroAleatorioNumero = encuentroEspecifico;
        }
        showOnlyEncounterCanvas();
        switch (encuentroAleatorioNumero)
        {
            case 1:
                encounter1.FillEncounterCanvas();
                button1.onClick.AddListener(Encounter1Button1);
                button2.onClick.AddListener(Encounter1Button2);
                break;
            case 2:
                encounter2.FillEncounterCanvas();
                button1.onClick.AddListener(Encounter2Button1);
                break;
        }
    }

    public void finishRandomEncounter()
    {
        ResetButtons();
        hideOnlyEncounterCanvas();
    }
   
    void showOnlyEncounterCanvas()
    {
        HUD.SetActive(false);
        CameraButtons.SetActive(false);
        EncounterCanvas.SetActive(true);
    }
    // Esta función, "hideOnlyEncounterCanvas", quita el HUD de encuentros y muestra el HUD de combate y el de girar la cámara
    void hideOnlyEncounterCanvas()
    {
        HUD.SetActive(true);
        CameraButtons.SetActive(true);
        EncounterCanvas.SetActive(false);
    }

    void createEncounters()
    {
        // Hacer un tutorial para como hacer un nuevo encuentro
        encounter1.encounterName = "Encuentro 1!!!";
        encounter1.encounterDescription = "Esta es la descripcion del encuentro 1! Texto de descripcion Texto de descripcion Texto de descripcion Texto de descripcion ";
        // Desconozco el motivo, pero no se ve bien la imagen
        encounter1.encounterImage = encounter1image;
        encounter1.encounterButton1Text = "Saltar";
        encounter1.encounterButton2Text = "Huir muy rapido rapidin";


        encounter2.encounterName = "Encuentro 2!!!";
        encounter2.encounterDescription = "Unity.Random funciona!!";
        //encounter2.encounterImage = encounter2image; // Aún no hay imagen para el segundo encuentro :(
        encounter2.encounterButton1Text = "Robar";
        //--------------------------------------------
        // Aquí ya deberían estar definidos todos los encuentros
    }
    private void ResetButtons()
    {
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        button4.gameObject.SetActive(true);
        // borrar las funciones que se le han añadido
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();
        // yippie!
    }






    //-----------------------------------------------------------------------
    // ENCOUNTER 1
    //-----------------------------------------------------------------------

    void Encounter1Button1()
    {
        Debug.Log("El boton 1 del encuentro 1 funciona");
        finishRandomEncounter();
    }

    void Encounter1Button2()
    {
        Debug.Log("El 2 tambien funciona :)");
        finishRandomEncounter();
        startRandomEncounter(2);
    }



    //-----------------------------------------------------------------------
    // ENCOUNTER 2
    //-----------------------------------------------------------------------

    void Encounter2Button1()
    {
        Debug.Log("Robas 1 millon de oro!");
        finishRandomEncounter();
    }

    //-----------------------------------------------------------------------
    // ENCOUNTER 3
    //-----------------------------------------------------------------------


    //-----------------------------------------------------------------------
    // ENCOUNTER 4
    //-----------------------------------------------------------------------

    //-----------------------------------------------------------------------
    // ENCOUNTER 5
    //-----------------------------------------------------------------------
}
