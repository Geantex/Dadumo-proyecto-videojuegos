using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : BasicAttack
{
    public bool AoD = true;



    // Start is called before the first frame update
    void Start()
    {
        /*Damage = gameObject.GetComponent<Unit>().Damage;
        Range = gameObject.GetComponent<Unit>().Range;*/
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    public void AttackNPC()
    {
        GameObject gameObjectObjective = gameObject.GetComponent<NPCMove>().FindNearestTarget();
        //Debug.Log("Unidad encontrada! Se llama " + gameObjectObjective.name);
        AoD = Attack(gameObjectObjective, gameObject);
        if (AoD)
        {
            TurnManager.EndTurn();
        }
        else
        {
            gameObject.GetComponent<NPCMove>().Move();
        }

    }
}
