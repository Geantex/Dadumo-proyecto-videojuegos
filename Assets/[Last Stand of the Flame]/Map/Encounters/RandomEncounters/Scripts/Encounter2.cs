using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter2 : MonoBehaviour
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
        robada();
    }
    public void functionButton3()
    {
        robada();
    }
    public void functionButton4()
    {
        EncounterManager.ShowResults("Te despides del vendedor, pero este para y te regala una roca, la aceptas, esta resulta ser una roca mágica," +
            " pero defectuosa, toda tu equipo pierde 5 de vida ");
    }
    public void opcion1()
    {
        EncounterManager.ShowResults("Gastas 5 monedas en comprar la roca, pero resultó ser una roca normal");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion2()
    {
        //suma 10 de vida a toda la party
        GameController.Instancia.modifyPartyHealthPoints(10f);
        EncounterManager.ShowResults("Gastas 5 monedas en comprar la roca, reultó ser una roca mágica," +
            "esta cura 10 de vida a cada miembro de te equipo");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion3()
    {
        //quita 1 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(-1f);
        EncounterManager.ShowResults("Te despides del vendedor, pero este para y te regala una roca, la aceptas, esta resulta ser una roca mágica," +
            " pero defectuosa, toda tu equipo pierde 1 de vida ");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
       public void robada()
    {
        //-5 de dinero por comprar la roca
        GameController.Instancia.modifyGoldCoins(-5f);
        int elegir = Random.Range(0, 3);
        if (elegir == 0)
        {  
            opcion1();
        }
        else if (elegir == 1)
        {
            opcion2();
        }
        else if(elegir == 2)
        {
            opcion3();
        }
    }
}
