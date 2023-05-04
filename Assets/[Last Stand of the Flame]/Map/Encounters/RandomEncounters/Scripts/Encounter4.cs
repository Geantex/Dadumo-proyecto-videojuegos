using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter4 : MonoBehaviour
{
    private GameObject encounterManager;

    public void functionButton1()
    {
        //+ 20 monedas
        GameController.Instancia.goldCoins += 20f;
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("el slime parece muy contento y os da 20 monedas");
    }
    public void functionButton2()
    {
        // -10 de vida a toda 
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("es muy poderoso y os quita 7 de vida a todo el equipo");
    }
    public void functionButton3()
    {
        // -50 de dinero
        GameController.Instancia.goldCoins -= 50f;
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("su mirada es más intensa que la vuestra, os sentis mareados y a los pocos segundos" +
            " os desmayáis todos, cuando os despertáis el slime ha desaparecido y con el parte de vustro dinero");
    }
    public void functionButton4()
    {
        //+10 de vida a toda la party
        // + 50 de oro
        GameController.Instancia.goldCoins += 50f;
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("El slime parece muy contento, ves como se hace más grande hasta el punto que os absorbe a todos. " +
            "Este os enseña el planeta del que proviene, sus costumbres, tradiciones y creencias. Al final del día os sentis como si hubieráis estado bebiendo de fiesta" +
            " todo el día, hasta el punto en el que os desmayáis todos. Cuando os levantáis os sentís como nuevo y veis que el slime os ha dejado un regalo.");
    }
}
