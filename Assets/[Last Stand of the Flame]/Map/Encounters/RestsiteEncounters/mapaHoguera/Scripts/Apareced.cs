using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apareced : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PIENSO LUEGO EXISTO");
        GameObject[] PersonajesHoguera = GameObject.FindGameObjectsWithTag("PersonajeHoguera");
        Debug.Log(PersonajesHoguera[0].name);
        foreach (GameObject PH in PersonajesHoguera)
        {
            PH.SetActive(false);
            Debug.Log("Miro si " + PH.name + " está en la party");
            foreach (CharacterCreator Char in GameController.Instancia.CharactersParty)
            {
                if (PH.name == Char.CharacterName)
                {
                    Debug.Log("Activo a " + PH.name);
                    PH.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
