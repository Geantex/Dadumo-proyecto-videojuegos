using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    private GameObject HUD;
    private GameObject CameraButtons;
    private GameObject EncounterCanvas;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;


    [SerializeField] Material encounter1image;
    // Start is called before the first frame update
    void Start()
    {
        HUD = GameObject.Find("HUD");
        CameraButtons = GameObject.Find("CameraButtons");
        EncounterCanvas = GameObject.Find("EncounterCanvas");

        

        createEncounters();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Encounter encounter1 = new Encounter();
        encounter1.encounterName = "Encuentro 1!!!";
        encounter1.encounterDescription = "ESTOY POR FOLLAR AD PROFUNDIS ESTOY POR FOLLAR AD PROFUNDIS ESTOY POR FOLLAR AD PROFUNDIS ESTOY POR FOLLAR AD PROFUNDIS ";
        // Desconozco el motivo, pero no se ve bien la imagen
        encounter1.encounterImage = encounter1image;
        encounter1.encounterButton1Text = "Kill yourself";
        encounter1.encounterButton2Text = "EXPLOTATE LOS TESTICULOS EN ESTE INSTANTE";


        Encounter encounter2 = new Encounter();
        encounter2.encounterName = "Encuentro 2!!!";
        encounter2.encounterDescription = "Eres Mario Climent, haz una de tus actividades favoritas!!!";
        //encounter2.encounterImage = encounter2image; // Aún no hay imagen para el segundo encuentro :(
        encounter2.encounterButton1Text = "Spluirgh";

        //button1.onClick.AddListener(Encounter1Button1);
        


        //--------------------------------------------
        // Aquí ya deberían estar definidos todos los encuentros

        
        // cogerá un numero entre 1 y 2, que son los dos encuentros actuales
        int encuentroAleatorioNumero = UnityEngine.Random.Range(1, 3);
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


        // Esto es de prueba; esta función debe ser llamada con un encuentro al azar

    }







    //-----------------------------------------------------------------------
    // ENCOUNTER 1
    //-----------------------------------------------------------------------

    void Encounter1Button1()
    {
        Debug.Log("You should kill yourself, now!");
        
    }

    void Encounter1Button2()
    {
        Debug.Log("Muere en el infierno estúpido!");
    }



    //-----------------------------------------------------------------------
    // ENCOUNTER 2
    //-----------------------------------------------------------------------

    void Encounter2Button1()
    {
        Debug.Log("OOOOOOH ME CORROOOOOOOOOOOOOO");
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
