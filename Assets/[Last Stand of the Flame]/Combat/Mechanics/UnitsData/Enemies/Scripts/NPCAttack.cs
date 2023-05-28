using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : BasicAttack
{
    public bool AoD = true;



    // Start is called before the first frame update
    void Start()
    {
        
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
            TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
        }
        else
        {
            gameObject.GetComponent<NPCMove>().Move();
            Animaciones.correr(GetComponentInChildren<Animator>(), GetComponent<Unit>().Name);
        }

    }
}
