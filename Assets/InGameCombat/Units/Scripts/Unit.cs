using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name = "";
    private int life;
    private int mana;
    //private int damage;
    //private int range;
    private string stateEffect;
    private string boostType;
    private double boost;
    private ArrayList specialAttacks = new ArrayList();
    private GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            if (gameObject.CompareTag("NPC"))
            {
                GameController.Instancia.SetStateByType(typeof(WinState));
            }
            else if (gameObject.CompareTag("Player"))
            {
                GameController.Instancia.SetStateByType(typeof(LoseState));
            }
            DestroyImmediate(gameObject);
        }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    public string StateEffect
    {
        get { return stateEffect; }
        set { stateEffect = value; }
    }

    public string BoostType
    {
        get { return boostType; }
        set { boostType = value; }
    }

    public double Boost
    {
        get { return boost; }
        set { boost = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void AddSpecialAttack(SpecialAttack specialAttack)
    {
        specialAttacks.Add(specialAttack);
    }
}
