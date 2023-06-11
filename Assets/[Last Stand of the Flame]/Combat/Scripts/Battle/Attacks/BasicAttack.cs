using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    // -----------------------------------------------------------------------------
    // En esta clase vamos a realizar el ataque básico de todos los personajes
    // -----------------------------------------------------------------------------

    // Creamos dos variables que nos indican el dano y el rango del ataque
    [SerializeField] int damage;
    [SerializeField] int range;
    // Creamos una variable para guardar la dirección del ataque
    public Vector3 heading;
    // Creamos una variable para guardar la mitad de la altura del personaje
    float halfHeight = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Calculamos la dirección del ataque
    // Recive: El objetivo al que queremos enfocar y el aliado que va a realizar el ataque
    // Devuelve: Nada
    void CalculateHeading(Vector3 target, GameObject allie)
    {
        // Calculamos la dirección entre la casilla en la que estamos y a la que nos queremos mover
        heading = target - allie.transform.position;
        // Normalizamos el vector (lo hacemos de magnitud 1, por lo que se convierte en vector unitario, para efectuar los movimientos en la dirección del vector unitario)
        heading.Normalize();
    }

    // Calculamos el camino más optimo hacia el objetivo
    // Recive: El aliado y el enemigo
    // Devuelve: Si el ataque ha sido exitoso o no
    public bool Attack(GameObject enemy, GameObject allie)
    {
        //allie.transform.forward = heading;

        // Calculamos la mitad de la altura del personaje
        halfHeight = allie.GetComponent<Collider>().bounds.extents.y;
        // Guardamos la posición del enemigo
        Vector3 target = enemy.transform.position;

        // Mantenemos la misma altura del aliado
        target.y = allie.transform.position.y;

        // Calculamos la dirección del ataque
        CalculateHeading(target, allie);

        // Rotamos al aliado para que mire hacia el enemigo
        allie.transform.forward = heading;

        // Calculamos la distancia entre el enemigo y el aliado
        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        // Si la distancia es menor o igual que el rango del ataque
        if (distance <= (range + 0.5f))
        {
            // Reducimos la vida del enemigo
            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
            // Actualizamos la vida del enemigo en la interfaz
            FindObjectOfType<BattleHUD>().SetHP(enemy.GetComponent<Unit>().party, enemy.GetComponent<Unit>().myteam, enemy.GetComponent<Unit>().Life);
            // Efectuamos la animación de ataque
            Animaciones.ataque(allie.GetComponentInChildren<Animator>(), allie.GetComponent<Unit>().Name, FindObjectOfType<Animaciones>(), enemy, allie);
            // Devolvemos que el ataque ha sido un éxito
            return true;
        }
        else
        {
            //Debug.Log("No hay rango" + distance);
            // Devolvemos que el ataque ha sido un fracaso
            return false;
        }
    }

    // Getter y setter del dano
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    // Getter y setter del rango
    public int Range
    {
        get { return range; }
        set { range = value; }
    }
}
