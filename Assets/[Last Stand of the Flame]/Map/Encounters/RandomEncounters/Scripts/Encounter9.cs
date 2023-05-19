using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter9 : MonoBehaviour
{
    public int NumDado;
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
        amanyar();
        if(NumDado == 0)
        {
            GameController.Instancia.modifyGoldCoins(20f);
            EncounterManager.ShowResults("Ganáis la apuesta");
        }
        else
        {
            GameController.Instancia.modifyGoldCoins(-10f);
            EncounterManager.ShowResults("Perdéis la apuesta");
        }
    }
    public void functionButton2()
    {
        amanyar();
        if (NumDado == 1)
        {
            GameController.Instancia.modifyGoldCoins(20f);
            EncounterManager.ShowResults("Ganáis la apuesta");
        }
        else
        {
            GameController.Instancia.modifyGoldCoins(-10f);
            EncounterManager.ShowResults("Perdéis la apuesta");
        }

    }
    public void functionButton3()
    {
        EncounterManager.ShowResults("Irse");
    }

    public void amanyar()
    {
        NumDado = Random.Range(0, 3);
    }
}
