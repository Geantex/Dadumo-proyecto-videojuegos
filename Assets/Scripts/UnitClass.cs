using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClass : MonoBehaviour
{
    private int life;
    private int mana;
    private BasicAtack atack;
    private ArrayList specialAtacks = new ArrayList();
    // Start is called before the first frame update
    public UnitClass(string tipo)
    {
        if(tipo == "Monje")
        {
            this.life = 100;
            this.mana = 100;
            this.atack = new BasicAtack(100, 100);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
