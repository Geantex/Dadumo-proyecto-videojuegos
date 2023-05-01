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



    // Estos son los métodos para empezar y acabar un encuentro aleatorio


    // en StartRandomEncounter es donde escribiremos cada "case",
    // que es donde rellenamos el canvas y asignamos las funciones a los botones con el evento correspondiente

    // Ahora puedes mandarle un int para coger un encuentro específico, si no, le mandas 0 para que te dé un evento aleatorio
    public void StartRandomEncounter(int encuentroEspecifico)
    {
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
    // Esta función, "hideOnlyEncounterCanvas", quita el HUD de encuentros y muestra el HUD de combate y el de girar la cámara
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

    //-----------------------------------------------------------------------
    // ENCOUNTER 1
    //-----------------------------------------------------------------------

    void Encounter1Button1()
    { // 0, 1, 2, 3
        if (Random.Range(0, 4) == 0)
        {
            // el dragon os quema por 40% de daño
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que daña a todo el grupo por un 40% de su salud)
            ShowResults("Mientras saqueáis, una pila de tesoros particularmente ruidosos colapsa, ¡y el dragón instintivamente lanza una llamarada!" +
                " Conseguís escapar vivos y parcialmente chamuscados, sin nada de tesoro entre manos");
        }
        else
        {
            // robais 50 de oro
            // Economia.anyadirOro(50); (esta funcion no existe) y el oro deberia ser poco
            ShowResults("El dragón duerme profundamente, y ahora es 50 monedas de oro más pobre que antes. El dragón empieza a despertarse un poco," +
                " así que el grupo huye de la cueva antes de que tengan un dracónido enemigo reclamándoles dinero");
        }
    }

    void Encounter1Button2()
    {

        if (Random.Range(0, 2) == 0)
        {
            // El dragón te quema!!!
            ShowResults("El tesoro parece que tenía un encantamiento de alarma, ¡porque empieza a hacer un poderoso pitido que despierta al dragón, quien lanza una llamarada!" +
                " Huís con las ropas chamuscadas y heridos, jurando jamás robar otra vez al dragón (lo haréis otra vez seguro)");
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
        encounter1.encounterName = "Dragón durmiente";
        encounter1.encounterDescription = "Pasando cerca de una cueva, escucháis a un dragón roncar en su cueva, con su gran pila de tesoro. Podríais intentar apropiaros con parte de su tesoro, pero si el dragón despierta...";
        // Desconozco el motivo, pero no se ve bien la imagen
        encounter1.encounterImage = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Encounters/imagenesEncuentros/megaRobarDragon.png"); // poner path aqui
        encounter1.encounterButton1Text = "Robar 50 de oro (75% de éxito)";
        encounter1.encounterButton2Text = "Robar equipamiento (50% de éxito)";
        encounter1.encounterButton3Text = "¡Nos largamos!";


        encounter2.encounterName = "Encuentro 2!!!";
        encounter2.encounterDescription = "Unity.Random funciona!!";
        //encounter2.encounterImage = encounter2image; // Aún no hay imagen para el segundo encuentro :(, joder jajaja, pero como se turbofolla?
        encounter2.encounterButton1Text = "Robar";

        encounter3.encounterName = "";




        //---------------------------------------------------
        // ENCUENTROS 1000 -> Estos encuentros no son aleatorios (puesto que no están en el rango de ser escogidos aleatorios)
        // Estos encuentros son para cosas como encuentros que van encadenados después de otros,
        //  o para cuando clicas en el icono de descanso, tienda o tesoro en el mapa
        //---------------------------------------------------
        encounter1001.encounterName = "Lugar de acampada";
        switch (Random.Range(1, 4)) // de 1 a 3
        {
            case 1:
                encounter1001.encounterDescription = "Al llegar el anochecer, llegáis a una cueva que parece lo suficientemente segura." +
                    " Encendéis una hoguera, descansáis y os preparáis para los peligros que acechan más adelante";


                break;

            case 2:
                encounter1001.encounterDescription = "Se acerca la noche, y uno de vosotros ve una casa abandonada." +
                    " Ya sea por confianza o por cansancio, decidís que es un lugar seguro para pasar la noche.";

                break;
            case 3:
                encounter1001.encounterDescription = "Fatigados por el esfuerzo del combate, encontráis una humilde comunidad de elfos del bosque en una arboleda;" +
                    " sacáis las armas para defenderos, pero de algún modo, conocen de vuestra misión y os ofrecen descanso.";
                break;


        }
        bool Romero = true;
        bool DeenEcan = true;
        bool Galentin = true;
        bool JoseMaria = true;
        if (Romero)
        {
            encounter1001.encounterButton1Text = "Romero cuenta una historia mientras descansáis";
        }
        if (DeenEcan)
        {
            encounter1001.encounterButton2Text = "Deen Ecan cuenta una historia mientras descansáis";

        }
        if (Galentin)
        {
            encounter1001.encounterButton3Text = "Galentin cuenta una historia mientras descansáis";

        }
        if (JoseMaria)
        {
            encounter1001.encounterButton4Text = "Jose Maria cuenta una historia mientras descansáis";

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
                    " ¡se la puede equipar NOMBRE DE PERSONAJE (esta se explica sola spluirgh spluirgh!";
                break;

            case "Mejora de armadura":
                // hay que meter variaciones de esta descripcion tambien pero psshhh spluirgh spluirgh!
                encounter1002.encounterDescription = "Encuentras una ARMADURA (aqui se supone que cogemos el nombre del objeto mejoraDeArmadura)," +
                    " ¡se la puede equipar NOMBRE DE PERSONAJE (esta se explica sola spluirgh spluirgh!";
                break;
        }
        encounter1002.encounterButton1Text = "¡Recoger el tesoro!";
        
    //--------------------------------------------
    // Aquí ya deberían estar definidos todos los encuentros
    }
    */

}