using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereRich : MonoBehaviour
{
    private GameObject encounterManager;

    public void functionButton1()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        // Te equipas un item
        // item itemEncontrado = itemManager.GiveRandomItem();
        // character.EquipItem() lol :)))

        encounterManager.GetComponent<EncounterManager>().ShowResults("Te equipas con un nuevo equipamiento para tus héroes. ¿Será suficiente para derrotar al Señor de la Ceniza?");
    }
}
