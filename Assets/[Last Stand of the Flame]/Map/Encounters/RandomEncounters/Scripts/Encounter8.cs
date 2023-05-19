using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter8 : MonoBehaviour
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
        EncounterManager.ShowResults("Ladras a los lobos y estos te ladran de nuevo, el doctor morbius te mira mal mientras se va con sus lobos");
    }
    public void functionButton2()
    {
        //+10 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(10f);
        EncounterManager.ShowResults("Morbius dice: Como supiste que se llama Pastelito, no es como que todos los lobos que parecen que puedan tumbarte de un mordisco " +
            "tengan este tipo de nombres ridículos jajaja. Toma me has caído bien, una de las muestras de sangre de Pastelito");
    }
    public void functionButton3()
    {
        //-1 de vida a todo el equipo
        GameController.Instancia.modifyPartyHealthPoints(-1f);
        //+50 monedas
        GameController.Instancia.modifyGoldCoins(50f);
        EncounterManager.ShowResults("Donáis la sangre y el doctor morbius te paga por tu ayuda");
    }
    public void functionButton4()
    {
        EncounterManager.ShowResults("os vais por caminos separados");
    }
}
