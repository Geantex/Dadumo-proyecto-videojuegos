using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters; // No volver a usar
using Random = UnityEngine.Random;

public class EncounterManager : MonoBehaviour
{
    public GameObject Mapa;
    // hola Dora la exploradora!! estoy por explorarme!!
    public GameObject EncounterCanvas;
    public GameObject ResultCanvas;
    public GameObject ResultDescription;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public List<Encounter> restsiteList = new List<Encounter>();
    public List<Encounter> treasureList = new List<Encounter>();

    // Start is called before the first frame update
    Encounter PopEncounter(int index)
    {
        Encounter encounter = GameController.Instancia.EncounterList.ElementAt(index);
        GameController.Instancia.EncounterList.RemoveAt(index);
        Debug.Log("He quitado el evento " + encounter.encounterName);
        return encounter;
    }



    // Estos son los métodos para empezar y acabar un encuentro aleatorio


    // en StartRandomEncounter es donde escribiremos cada "case",
    // que es donde rellenamos el canvas y asignamos las funciones a los botones con el evento correspondiente

    // Ahora puedes mandarle un int para coger un encuentro específico, si no, le mandas 0 para que te dé un evento aleatorio
    public void StartRandomEncounter(int encuentroEspecifico)
    {
        FadeToBlack.QuickReverseFade();
        // cogerá un numero entre 1 y 2, que son los dos encuentros actuales

        int encuentroAleatorioNumero;
        Encounter randomEncounter;
        if (encuentroEspecifico == 0)
        {
            encuentroAleatorioNumero = Random.Range(1, GameController.Instancia.EncounterList.Count + 1); // de 1 a uhhhhh
            randomEncounter = PopEncounter(encuentroAleatorioNumero - 1);


            // Aqui es si queremos un encuentro aleatorio
            // Meter aqui lo de eventos que no se repitan!
        }
        else
        {
            // Aqui es si queremos un encuentro específico
            encuentroAleatorioNumero = encuentroEspecifico;
            randomEncounter = GameController.Instancia.EncounterList.ElementAt(encuentroAleatorioNumero - 1);

        }
        showOnlyEncounterCanvas();
        randomEncounter.FillEncounterCanvas();
    }

    public void ShowResults(string results)
    {
        //FadeToBlack.QuickFade();
        //yield return new WaitForSeconds(0.24f);
        ResultCanvas.SetActive(true);
        EncounterCanvas.SetActive(false);
        ResultDescription.GetComponent<Text>().text = results;
        //FadeToBlack.QuickReverseFade();

    }


    public void finishRandomEncounter()
    {
        FadeToBlack.QuickFade();
        Invoke("finishRandomEncounterFade", 0.25f);
    }

    public void finishRandomEncounterFade()
    {

        ResetButtons();
        hideOnlyEncounterCanvas();
        FadeToBlack.QuickReverseFade();
    }


    // Tambien esconde el ResultCanvas
    void showOnlyEncounterCanvas()
    {
        Mapa.SetActive(false);
        EncounterCanvas.SetActive(true);
        ResultCanvas.SetActive(false);

    }
    // Esta función, "hideOnlyEncounterCanvas", quita el HUD de encuentros y muestra el mapa
    // Tambien esconde el ResultCanvas

    void hideOnlyEncounterCanvas()
    {
        Mapa.SetActive(true);
        EncounterCanvas.SetActive(false);
        ResultCanvas.SetActive(false);
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

    

    public void StartTreasureEncounter()
    {
        FadeToBlack.QuickReverseFade();
        Encounter treasureEncounter = treasureList.ElementAt(0);
        showOnlyEncounterCanvas();
        treasureEncounter.FillEncounterCanvas();
    }

}