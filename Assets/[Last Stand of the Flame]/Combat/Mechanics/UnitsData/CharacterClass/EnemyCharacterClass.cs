using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterClass : CharacterClass
{ 
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateValues()
    {
        gameObject.GetComponent<Unit>().Name = "ladron";
        gameObject.GetComponent<Unit>().Life = 80;
        gameObject.GetComponent<Unit>().Mana = 0;
        gameObject.GetComponent<NPCAttack>().Damage = 30;
        gameObject.GetComponent<NPCAttack>().Range = 1;
    }
}
