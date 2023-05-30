using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter7 : MonoBehaviour
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
        GameController.Instancia.modifyGoldCoins(-5f);
        GameController.Instancia.modifyPartyHealthPoints(5f);
        EncounterManager.ShowResults(" Decidís darle 5 monedas y el mendigo te lo agradece con algunas vendas");
    }
    public void functionButton2()
    {
        //+10 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(-5f);
        EncounterManager.ShowResults("Decidís no darle nada al mendigo, este se enfada con vosotros y saca algo parecido a un puñal y os ataca");
    }
}