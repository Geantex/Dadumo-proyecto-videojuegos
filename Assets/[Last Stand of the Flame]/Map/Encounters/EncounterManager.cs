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

    public List<Encounter> encounterList = new List<Encounter>();
    public List<Encounter> restsiteList = new List<Encounter>();
    public List<Encounter> treasureList = new List<Encounter>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("getEncounterList", 1.5f);
    }
    void getEncounterList()
    {
        //Aquí uno de los problemas que causan el fallo el ASSETDATABASE, es mejor añadir a mano directamente los encuentros
        //en el ENCOUNTERMANAGER directamente a mano para no tener problemas de compilación el el futuro

        /*string[] encounterPaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/RandomEncounters/Objects" });
        Encounter[] arrayEncounter = new Encounter[encounterPaths.Length];
        for (int i = 0; i < encounterPaths.Length; i++)
        {
            string pathEncounter = AssetDatabase.GUIDToAssetPath(encounterPaths[i]);
            arrayEncounter[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathEncounter);
        }
        encounterList = new List<Encounter>(arrayEncounter);*/

        /*string[] restsitePaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/RestsiteEncounters/Objects" });
        Encounter[] arrayRestsite = new Encounter[restsitePaths.Length];
        for (int i = 0; i < restsitePaths.Length; i++)
        {
            string pathRestsite = AssetDatabase.GUIDToAssetPath(restsitePaths[i]);
            arrayRestsite[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathRestsite);
        }
        restsiteList = new List<Encounter>(arrayRestsite);*/

        /*string[] treasurePaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/TreasureEncounters/Objects" });
        Encounter[] arrayTreasure = new Encounter[treasurePaths.Length];
        for (int i = 0; i < treasurePaths.Length; i++)
        {
            string pathTreasure = AssetDatabase.GUIDToAssetPath(treasurePaths[i]);
            arrayTreasure[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathTreasure);
        }
        treasureList = new List<Encounter>(arrayTreasure);*/
    }

    Encounter PopEncounter(int index)
    {
        Encounter encounter = encounterList.ElementAt(index);
        encounterList.RemoveAt(index);
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
            encuentroAleatorioNumero = Random.Range(1, encounterList.Count + 1); // de 1 a uhhhhh
            randomEncounter = PopEncounter(encuentroAleatorioNumero - 1);


            // Aqui es si queremos un encuentro aleatorio
            // Meter aqui lo de eventos que no se repitan!
        }
        else
        {
            // Aqui es si queremos un encuentro específico
            encuentroAleatorioNumero = encuentroEspecifico;
            randomEncounter = encounterList.ElementAt(encuentroAleatorioNumero - 1);

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