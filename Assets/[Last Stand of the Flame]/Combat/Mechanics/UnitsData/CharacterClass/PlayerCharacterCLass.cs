using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterCLass : CharacterClass
{
    // Start is called before the first frame update
    void Start()
    {
        //UpdateValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateValues()
    {
        gameObject.GetComponent<Unit>().Name = CharacterName;
        gameObject.GetComponent<Unit>().Life = (int)HealthPoints;
        gameObject.GetComponent<Unit>().MaxLife = (int)MaxHealthPoints;
        gameObject.GetComponent<Unit>().Mana = (int)ManaPoints;
        gameObject.GetComponent<PlayerAttack>().Damage = (int)DamagePoints;
        gameObject.GetComponent<PlayerAttack>().Range = (int)RangeTiles;
        gameObject.GetComponent<PlayerSpecialAttack>().AllSpecialAttacks = SpecialAttacks;
    }
}
