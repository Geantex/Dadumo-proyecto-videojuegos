using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter6 : MonoBehaviour
{

    private EncounterManager encounterManager;

    public EncounterManager EncounterManager
    {
        get
        {
            if (encounterManager == null)
            {
                encounterManager = GameObject.FindObjectOfType<EncounterManager>();
            }
            return encounterManager;
        }
    }
    public void functionButton1()
    {
        //-5 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(-5f);
        EncounterManager.ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
    public void functionButton2()
    {
        //+ 20 monedas
        GameController.Instancia.modifyGoldCoins(20f);
        EncounterManager.ShowResults("cruzáis con total seguridad y de camino os encontráis con un pequeño cofre");
    }
    public void functionButton3()
    {
        //+50 monedas
        GameController.Instancia.modifyGoldCoins(50f);
        EncounterManager.ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
    public void functionButton4()
    {
        //-5 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(-5f);
        EncounterManager.ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
}
