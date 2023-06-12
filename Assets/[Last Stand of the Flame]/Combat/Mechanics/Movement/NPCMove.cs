using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class NPCMove : TacticsMove
{
    // -----------------------------------------------------------------------------
    // En esta clase vamos a controlar el movimiento del NPC
    // -----------------------------------------------------------------------------

    // Target es un GameObject que representa al objetivo al que se quiere mover el NPC
    GameObject target;
    // heading es un vector que representa la dirección en la que se quiere mover el NPC
    // Esto se usa para aparezca en la dirección correcta
    public Vector3 heading2;
    // halfHeight es un float que representa la mitad de la altura del NPC
    float halfHeight2 = 0;

    // Use this for initialization
    void Start()
    {
        // Establecemos la mitad de la altura del NPC
        halfHeight2 = gameObject.GetComponent<Collider>().bounds.extents.y;
        //Vector3 target = gameObject.transform.position.y;

        // Mantenemos la misma altura del aliado
        Vector3 heading2 = gameObject.transform.position;
        // Calculamos el vector en la dirección a la que queremos girar el personaje
        heading2.Normalize();

        // Invertimos el vector de dirección para que el personaje dé media vuelta
        heading2 = -heading2;

        // Establecemos la dirección del personaje
        gameObject.transform.forward = heading2;

        // Inicializamos el movimiento
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Si no es su turno, no hace nada
        if (!turn)
        {
            return;
        }

        if (animandose)
        {
            return;
        }

        // Si no se está moviendo, calculamos la zona de movimiento y el camino
        if (!moving)
        {
            // Si no se ha calculado la zona de movimiento, la calculamos
            calculateZone = false;
            // Buscamos el objetivo más cercano
            FindNearestTarget();
            // Calculamos el camino hacia el objetivo
            CalculatePath();
            // Calculamos la zona de movimiento
            FindSelectableTiles();
            // Establecemos la casilla donde está el objetivo como casilla destino
            actualTargetTile.target = true;
        }
        else
        {
            // Una vez que hemos establecido la zona de movimiento y el camino, movemos al NPC hacia el objetivo más cercano
            // Lo movemos mediante su función de ataque, para que se mueva y ataque cuando entre en rango
            gameObject.GetComponent<NPCAttack>().AttackNPC();
        }
    }

    // Calculamos el camino más optimo hacia el objetivo
    // Recive: Nada
    // Devuelve: Nada
    void CalculatePath()
    {
        // Buscamos cual es la casilla donde esta el objetivo y la guardamos
        Tile targetTile = GetTargetTile(target);
        // Calculamos el camino hacia la casilla objetivo
        FindPath(targetTile);
    }

    // Calculamos el camino más optimo hacia el objetivo
    // Recive: Nada
    // Devuelve: El objetivo más cercano
    public GameObject FindNearestTarget()
    {
        // Buscamos todos los posibles objetivos en la escena
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        // Creamos una variable que guardará el objetivo más cercano
        // Mientras no se encuentre ninguno, se establece como null
        GameObject nearest = null;
        // Creamos una variable que guardará la distancia al objetivo más cercano
        // La inicializamos a infinito para que la primera distancia sea menor que ella
        float distance = Mathf.Infinity;

        // Recorremos todos los objetivos
        foreach (GameObject obj in targets)
        {
            // Calculamos la distancia al objetivo
            float d = Vector3.Distance(transform.position, obj.transform.position);

            // Si la distancia es menor que la distancia al objetivo más cercano, lo establecemos como objetivo más cercano
            if (d < distance)
            {
                // Establecemos la distancia al objetivo más cercano y el objetivo
                distance = d;
                nearest = obj;
            }
        }

        // Guardamos el objetivo más cercano en la variable global
        target = nearest;
        return nearest;
    }

    // Getter y setter de la variable target (objetivo)
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
