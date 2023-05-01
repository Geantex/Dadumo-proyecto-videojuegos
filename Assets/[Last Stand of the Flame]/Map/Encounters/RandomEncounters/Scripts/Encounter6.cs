using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter6 : MonoBehaviour
{
    public GameObject encounterManager;
    public void functionButton1()
    {
        //-5 de vida a todo el equipo
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
    public void functionButton2()
    {
        //+ 20 monedas
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("cruzáis con total seguridad y de camino os encontráis con un pequeño cofre");
    }
    public void functionButton3()
    {
        //+50 monedas
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
    public void functionButton4()
    {
        //-5 de vida a todo el equipo
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("cruzais, pero caeis en algunas trampar por haber resuelto mal el poema");
    }
}
