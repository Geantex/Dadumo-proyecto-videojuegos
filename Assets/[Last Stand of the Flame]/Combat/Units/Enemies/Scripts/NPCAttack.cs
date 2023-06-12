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
            gameObject.GetComponent<TacticsMove>().animandose = true;
            gameObject.GetComponent<TacticsMove>().moving = false;
            centralo();
            //gameObject.GetComponent<NPCMove>().Move();
            //TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
        }
        // Si no, movemos al NPC
        else
        {
            gameObject.GetComponent<NPCMove>().Move();
        }

    }

    public void centralo()
    {
        float halfHeight = 0;
        gameObject.GetComponent<NPCMove>().GetCurrentTile();
        // Obtenemos la casilla más cercana a la que nos queremos mover
        Tile t = gameObject.GetComponent<NPCMove>().CurrentTile;
        // Y guardamos la posición en un vector
        Vector3 target = t.transform.position;

        //Calculate the unit's position on top of the target tile
        // Calcula la posición para que el personaje se mueva encima de la casilla
        target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

        // Si la distancia entre la posición del personaje y la posición de la casilla es mayor que 0.05
        if (Vector3.Distance(transform.position, target) >= 0.05f)
        {
            
        }
        else
        {
            //Tile center reached
            // Si la distancia entre la posición del personaje y la posición de la casilla es menor que 0.05
            // Centramos al personaje en la casilla
            transform.position = target;
        }
    }
}