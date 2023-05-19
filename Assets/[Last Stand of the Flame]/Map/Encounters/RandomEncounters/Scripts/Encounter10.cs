using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter10 : MonoBehaviour
{
    public int movimientoEnemigo;
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
        adProfundis();
        if(movimientoEnemigo == 1)
        {
            GameController.Instancia.modifyGoldCoins(200f);
            EncounterManager.ShowResults("¡Ganáis! Os lleváis el premio");
        }
        else
        {
            GameController.Instancia.modifyPartyHealthPoints(-1f);
            EncounterManager.ShowResults("¡Perdeis y no os lleváis nada");
        }
        
    }
    public void functionButton2()
    {
        adProfundis();
        if (movimientoEnemigo == 2)
        {
            GameController.Instancia.modifyGoldCoins(200f);
            EncounterManager.ShowResults("¡Ganáis! Os lleváis el premio");
        }
        else
        {
            GameController.Instancia.modifyPartyHealthPoints(-1f);
            EncounterManager.ShowResults("¡Perdeis y no os lleváis nada");
        }
    }
    public void functionButton3()
    {
        adProfundis();
        if (movimientoEnemigo == 0)
        {
            GameController.Instancia.modifyGoldCoins(200f);
            EncounterManager.ShowResults("¡Ganáis! Os lleváis el premio");
        }
        else
        {
            GameController.Instancia.modifyPartyHealthPoints(-1f);
            EncounterManager.ShowResults("¡Perdeis y no os lleváis nada");
        }
    }
    public void functionButton4()
    {
        EncounterManager.ShowResults("Os negais y seguis con vuestro camino");
    }

    public void adProfundis()
    {
        movimientoEnemigo = Random.Range(0, 3);
    }
}