using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter5 : MonoBehaviour
{
    public int elegir;

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
        robada();
    }
    public void functionButton2()
    {
        EncounterManager.ShowResults("Os vais sin acercaros mucho al cadaver ");
    }
    public void opcion1()
    {
        GameController.Instancia.modifyGoldCoins(50f);
        EncounterManager.ShowResults("Rebuscáis en el cadaver y encontráis en su interior dinero (+50 monedas)");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion2()
    {
        //suma 10 de vida a toda la party
        GameController.Instancia.modifyPartyHealthPoints(-5f);
        EncounterManager.ShowResults("Rebuscáis en el cadaver y este por dentro se encontraba en pésimas condiciones, este os contrae unas arcadas terribles y os encontráis muy mal durante un rato");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion3()
    {
        //quita 1 de vida a todo el equipo
        GameController.Instancia.modifyGoldCoins(-50f);
        EncounterManager.ShowResults("Os acercáis al cadaver, pero este reultó no estar muerto del todo, os agarra de una pierna, mientras intentáis quitar su mano de vuestra" +
            " pierna este alcanza vuestro botín y os quita oro y sale corriendo");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void robada()
    {
        int elegir = Random.Range(0, 3);
        if (elegir == 0)
        {
            opcion1();
        }
        else if (elegir == 1)
        {
            opcion2();
        }
        else if (elegir == 2)
        {
            opcion3();
        }
    }
}