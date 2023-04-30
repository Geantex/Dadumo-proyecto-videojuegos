using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    public string name;
    protected int life;
    protected int mana;
    protected int damage;
    protected int range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SetDataOfLibrary(string name)
    {
        if(name == "Wizard")
        {
            name = "Wizard";
            life = 20;
            mana = 100;
            damage = 50;
            range = 6;
        }
        else if(name == "clerigo")
        {
            name = "clerigo";
            life = 100;
            mana = 100;
            damage = 10;
            range = 4;
        }
        else if (name == "ladron")
        {
            name = "ladron";
            life = 100;
            mana = 0;
            damage = 30;
            range = 1;
        }
    }
}
