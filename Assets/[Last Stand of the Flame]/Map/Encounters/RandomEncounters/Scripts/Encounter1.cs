using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter1 : MonoBehaviour
{
    public GameObject encounterManager;

    public void functionButton1()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        Debug.Log("Funciona functionButton1!!!");   
        encounterManager.GetComponent<EncounterManager>().ShowResults("Penis!!!!");
    }
    
}
