using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : BasicAttack
{
    // -----------------------------------------------------------------------------
    // En esta clase vamos a controlar el ataque del NPC
    // -----------------------------------------------------------------------------

    // Tenemos una variable que nos indica si el ataque ha sido exitoso o no
    public bool AoD = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Función que maneja en ataque de los NPC
    // Recive: Nada
    // Devuelve: Nada
    public void AttackNPC()
    {
        // Buscamos el objetivo más cercano al NPC y lo guardamos
        GameObject gameObjectObjective = gameObject.GetComponent<NPCMove>().FindNearestTarget();
        // Intentamos atacar al objetivo, y recogemos el resultado de si el ataque ha sido exitoso o no
        AoD = Attack(gameObjectObjective, gameObject);
        // Si el ataque ha sido exitoso, terminamos el turno del NPC
        if (AoD)
        {
            TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
        }
        // Si no, movemos al NPC
        else
        {
            gameObject.GetComponent<NPCMove>().Move();
        }

    }
}