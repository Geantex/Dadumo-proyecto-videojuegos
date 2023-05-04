using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter2 : MonoBehaviour
{
    public GameObject encounterManager;
    public int elegir;

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
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("Te despides del vendedor, pero este para y te regala una roca, la aceptas, esta resulta ser una roca mágica," +
            " pero defectuosa, toda tu equipo pierde 5 de vida ");
    }
    public void opcion1()
    {
        //gasta 5 monedas
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("Gastas 5 monedas en comprar la roca, pero resultó ser una roca normal");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion2()
    {
        //gasta 5 de oro
        //suma 5 de vida a toda la party
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("Gastas 5 monedas en comprar la roca, reultó ser una roca mágica," +
            "esta cura 10 de vida a cada miembro de te equipo");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public void opcion3()
    {
        //gasta 5 de oro
        //quita 1 de vida a todo el equipo
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("Te despides del vendedor, pero este para y te regala una roca, la aceptas, esta resulta ser una roca mágica," +
            " pero defectuosa, toda tu equipo pierde 1 de vida ");
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
       public void robada()
    {
        //-5 de dinero por comprar la roca
        int elegir = Random.Range(0, 3);
        if (elegir == 0)
        {
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins - 5f;
            opcion1();
        }
        else if (elegir == 1)
        {
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins - 5f;
            opcion2();
        }
        else if(elegir == 2)
        {
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins - 5f;
            opcion3();
        }
    }
}
