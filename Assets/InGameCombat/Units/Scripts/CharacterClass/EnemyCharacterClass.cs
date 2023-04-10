using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterClass : CharacterClass
{ 
    
    // Start is called before the first frame update
    void Start()
    {
        SetDataOfLibrary(name);
        UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateValues()
    {
        gameObject.GetComponent<Unit>().Name = name;
        gameObject.GetComponent<Unit>().Life = life;
        gameObject.GetComponent<Unit>().Mana = mana;
        gameObject.GetComponent<NPCAttack>().Damage = damage;
        gameObject.GetComponent<NPCAttack>().Range = range;
    }
}
