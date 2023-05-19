using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter3 : MonoBehaviour
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
        //+ 20 monedas
        GameController.Instancia.modifyGoldCoins(50f);
        EncounterManager.ShowResults("Rebusc�is en el dormitorio y encontr�is algo de dinero (+20 monedas)");
    }
    public void functionButton2()
    {
        // -10 de vida a toda
        GameController.Instancia.modifyPartyHealthPoints(-1f);
        EncounterManager.ShowResults("Rebusc�is en el comedor y un libro os llama la atenci�n. Lo le�is y al rato notais un picor por las manos. La tapa del libro estaba" +
            " hecha con plantas venenosas");
    }
    public void functionButton3()
    {
        // -50 de dinero
        GameController.Instancia.modifyPartyHealthPoints(-5f);
        EncounterManager.ShowResults("Rebusc�is en la cocina y os cae una viga de madera podrida en la cabeza");
    }
    public void functionButton4()
    {
        EncounterManager.ShowResults("Pas�is de largo");
    }
}
