using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterCLass : CharacterClass
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
        gameObject.GetComponent<PlayerAttack>().Damage = damage;
        gameObject.GetComponent<PlayerAttack>().Range = range;
        gameObject.GetComponent<PlayerSpecialAttack>().AllSpecialAttacks = AllSpecialAttacks;
    }
}
