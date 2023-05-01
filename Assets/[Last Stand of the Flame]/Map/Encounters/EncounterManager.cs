using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
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
        string[] encounterPaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/RandomEncounters/Objects" });
        Encounter[] arrayEncounter = new Encounter[encounterPaths.Length];
        for (int i = 0; i < encounterPaths.Length; i++)
        {
            string pathEncounter = AssetDatabase.GUIDToAssetPath(encounterPaths[i]);
            arrayEncounter[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathEncounter);
        }
        encounterList = new List<Encounter>(arrayEncounter);

        string[] restsitePaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/RestsiteEncounters/Objects" });
        Encounter[] arrayRestsite = new Encounter[restsitePaths.Length];
        for (int i = 0; i < restsitePaths.Length; i++)
        {
            string pathRestsite = AssetDatabase.GUIDToAssetPath(restsitePaths[i]);
            arrayRestsite[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathRestsite);
        }
        restsiteList = new List<Encounter>(arrayRestsite);

        string[] treasurePaths = AssetDatabase.FindAssets("t: Encounter", new string[] { "Assets/[Last Stand of the Flame]/Map/Encounters/TreasureEncounters/Objects" });
        Encounter[] arrayTreasure = new Encounter[treasurePaths.Length];
        for (int i = 0; i < treasurePaths.Length; i++)
        {
            string pathTreasure = AssetDatabase.GUIDToAssetPath(treasurePaths[i]);
            arrayTreasure[i] = AssetDatabase.LoadAssetAtPath<Encounter>(pathTreasure);
        }
        treasureList = new List<Encounter>(arrayTreasure);
    }

    Encounter PopEncounter(int index)
    {
        Encounter encounter = encounterList.ElementAt(index);
        encounterList.RemoveAt(index);
        return encounter;
    }



    // Estos son los m�todos para empezar y acabar un encuentro aleatorio


    // en StartRandomEncounter es donde escribiremos cada "case",
    // que es donde rellenamos el canvas y asignamos las funciones a los botones con el evento correspondiente

    // Ahora puedes mandarle un int para coger un encuentro espec�fico, si no, le mandas 0 para que te d� un evento aleatorio
    public void StartRandomEncounter(int encuentroEspecifico)
    {
        // coger� un numero entre 1 y 2, que son los dos encuentros actuales

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
            // Aqui es si queremos un encuentro espec�fico
            encuentroAleatorioNumero = encuentroEspecifico;
            randomEncounter = encounterList.ElementAt(encuentroAleatorioNumero - 1);

        }
        showOnlyEncounterCanvas();
        randomEncounter.FillEncounterCanvas();
    }

    public void ShowResults(string results)
    {
        ResultCanvas.SetActive(true);
        ResultDescription.GetComponent<Text>().text = results;
    }

    public void finishRandomEncounter()
    {
        ResetButtons();
        hideOnlyEncounterCanvas();
    }

    void showOnlyEncounterCanvas()
    {
        Mapa.SetActive(false);
        EncounterCanvas.SetActive(true);
        ResultCanvas.SetActive(false);

    }
    // Esta funci�n, "hideOnlyEncounterCanvas", quita el HUD de encuentros y muestra el HUD de combate y el de girar la c�mara
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
        // borrar las funciones que se le han a�adido
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
    { // 0, 1, 2, 3
        if (Random.Range(0, 4) == 0)
        {
            // el dragon os quema por 40% de da�o
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que da�a a todo el grupo por un 40% de su salud)
            ShowResults("Mientras saque�is, una pila de tesoros particularmente ruidosos colapsa, �y el drag�n instintivamente lanza una llamarada!" +
                " Consegu�s escapar vivos y parcialmente chamuscados, sin nada de tesoro entre manos");
        }
        else
        {
            // robais 50 de oro
            // Economia.anyadirOro(50); (esta funcion no existe) y el oro deberia ser poco
            ShowResults("El drag�n duerme profundamente, y ahora es 50 monedas de oro m�s pobre que antes. El drag�n empieza a despertarse un poco," +
                " as� que el grupo huye de la cueva antes de que tengan un drac�nido enemigo reclam�ndoles dinero");
        }
    }

    void Encounter1Button2()
    {

        if (Random.Range(0, 2) == 0)
        {
            // El drag�n te quema!!!
            ShowResults("El tesoro parece que ten�a un encantamiento de alarma, �porque empieza a hacer un poderoso pitido que despierta al drag�n, quien lanza una llamarada!" +
                " Hu�s con las ropas chamuscadas y heridos, jurando jam�s robar otra vez al drag�n (lo har�is otra vez seguro)");
        }
        else
        {
            // oops
            ShowResults("");
        }
    }

    public void StartRestsiteEncounter()
    {
        Encounter restsiteEncounter = restsiteList.ElementAt(0);
        showOnlyEncounterCanvas();
        restsiteEncounter.FillEncounterCanvas();
    }

    public void StartTreasureEncounter()
    {
        Encounter treasureEncounter = treasureList.ElementAt(0);
        showOnlyEncounterCanvas();
        treasureEncounter.FillEncounterCanvas();
    }

    /*
    void createEncounters()
    {
        
        // Hacer un tutorial para como hacer un nuevo encuentro
        encounter1.encounterName = "Drag�n durmiente";
        encounter1.encounterDescription = "Pasando cerca de una cueva, escuch�is a un drag�n roncar en su cueva, con su gran pila de tesoro. Podr�ais intentar apropiaros con parte de su tesoro, pero si el drag�n despierta...";
        // Desconozco el motivo, pero no se ve bien la imagen
        encounter1.encounterImage = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Encounters/imagenesEncuentros/megaRobarDragon.png"); // poner path aqui
        encounter1.encounterButton1Text = "Robar 50 de oro (75% de �xito)";
        encounter1.encounterButton2Text = "Robar equipamiento (50% de �xito)";
        encounter1.encounterButton3Text = "�Nos largamos!";


        encounter2.encounterName = "Encuentro 2!!!";
        encounter2.encounterDescription = "Unity.Random funciona!!";
        //encounter2.encounterImage = encounter2image; // A�n no hay imagen para el segundo encuentro :(, joder jajaja, pero como se turbofolla?
        encounter2.encounterButton1Text = "Robar";

        encounter3.encounterName = "";




        //---------------------------------------------------
        // ENCUENTROS 1000 -> Estos encuentros no son aleatorios (puesto que no est�n en el rango de ser escogidos aleatorios)
        // Estos encuentros son para cosas como encuentros que van encadenados despu�s de otros,
        //  o para cuando clicas en el icono de descanso, tienda o tesoro en el mapa
        //---------------------------------------------------
        encounter1001.encounterName = "Lugar de acampada";
        switch (Random.Range(1, 4)) // de 1 a 3
        {
            case 1:
                encounter1001.encounterDescription = "Al llegar el anochecer, lleg�is a una cueva que parece lo suficientemente segura." +
                    " Encend�is una hoguera, descans�is y os prepar�is para los peligros que acechan m�s adelante";


                break;

            case 2:
                encounter1001.encounterDescription = "Se acerca la noche, y uno de vosotros ve una casa abandonada." +
                    " Ya sea por confianza o por cansancio, decid�s que es un lugar seguro para pasar la noche.";

                break;
            case 3:
                encounter1001.encounterDescription = "Fatigados por el esfuerzo del combate, encontr�is una humilde comunidad de elfos del bosque en una arboleda;" +
                    " sac�is las armas para defenderos, pero de alg�n modo, conocen de vuestra misi�n y os ofrecen descanso.";
                break;


        }
        bool Romero = true;
        bool DeenEcan = true;
        bool Galentin = true;
        bool JoseMaria = true;
        if (Romero)
        {
            encounter1001.encounterButton1Text = "Romero cuenta una historia mientras descans�is";
        }
        if (DeenEcan)
        {
            encounter1001.encounterButton2Text = "Deen Ecan cuenta una historia mientras descans�is";

        }
        if (Galentin)
        {
            encounter1001.encounterButton3Text = "Galentin cuenta una historia mientras descans�is";

        }
        if (JoseMaria)
        {
            encounter1001.encounterButton4Text = "Jose Maria cuenta una historia mientras descans�is";

        }


        encounter1002.encounterName = "Tesoro";

        // Esto es temporal, se supone que lo cogemos de una lista, que de hecho...
        List <String> listaTesoros = new List<String>()
        {"Mejora de armamento", "Mejora de armadura"};
        string Tesoro = listaTesoros.ElementAt(Random.Range(0, 2));
        switch (Tesoro)
        {
            case "Mejora de armamento":
                // hay que meter variaciones de esta descripcion pero aaah que pereza spluirgh spluirgh!
                encounter1002.encounterDescription = "Encuentras un ARMAMENTO (aqui se supone que cogemos el nombre del objeto mejoraDeArmamento)," +
                    " �se la puede equipar NOMBRE DE PERSONAJE (esta se explica sola spluirgh spluirgh!";
                break;

            case "Mejora de armadura":
                // hay que meter variaciones de esta descripcion tambien pero psshhh spluirgh spluirgh!
                encounter1002.encounterDescription = "Encuentras una ARMADURA (aqui se supone que cogemos el nombre del objeto mejoraDeArmadura)," +
                    " �se la puede equipar NOMBRE DE PERSONAJE (esta se explica sola spluirgh spluirgh!";
                break;
        }
        encounter1002.encounterButton1Text = "�Recoger el tesoro!";
        
    //--------------------------------------------
    // Aqu� ya deber�an estar definidos todos los encuentros
    }
    */

}