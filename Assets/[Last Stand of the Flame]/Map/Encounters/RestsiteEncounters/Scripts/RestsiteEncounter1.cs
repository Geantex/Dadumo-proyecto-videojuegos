using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestsiteEncounter1 : MonoBehaviour
{
    private GameObject encounterManager;

    public void functionButton1()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        // recuperar salud 50% de salud al grupo

        encounterManager.GetComponent<EncounterManager>().ShowResults("El grupo entero descansa y recupera vida");
    }
}
