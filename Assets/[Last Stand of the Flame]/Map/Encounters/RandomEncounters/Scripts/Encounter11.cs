using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter11 : MonoBehaviour
{
    public int mimico;
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
        DSReferencia();

        if(mimico == 0)
        {
            GameController.Instancia.modifyGoldCoins(100f);
            EncounterManager.ShowResults("¡Es un cofre lleno de oro!");
        }
        else
        {
            GameController.Instancia.modifyPartyHealthPoints(-10f);
            EncounterManager.ShowResults("¡Es un cofre mimico, en realidad es un monstruo y te ataca!");
        }
    }
    public void functionButton2()
    {
        EncounterManager.ShowResults("Pasáis de largo sin acercaros mucho al cofre");
    }

    public void DSReferencia()
    {
        mimico = Random.Range(0, 2);
    }
}