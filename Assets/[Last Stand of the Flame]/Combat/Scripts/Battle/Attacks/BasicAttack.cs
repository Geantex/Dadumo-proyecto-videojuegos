using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int range;
    public Vector3 heading;
    float halfHeight = 0;
    // Start is called before the first frame update
    /*public BasicAttack(int damage, int range)
    {
        this.damage = damage;
        this.range = range;
    }*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalculateHeading(Vector3 target, GameObject allie)
    {
        // Calculamos la dirección entre la casilla en la que estamos y a la que nos queremos mover
        heading = target - allie.transform.position;
        // Normalizamos el vector (lo hacemos de magnitud 1, por lo que se convierte en vector unitario, para efectuar los movimientos en la dirección del vector unitario)
        heading.Normalize();
    }

    public bool Attack(GameObject enemy, GameObject allie)
    {
        allie.transform.forward = heading;

        halfHeight = allie.GetComponent<Collider>().bounds.extents.y;
        Vector3 target = enemy.transform.position;

        // Mantenemos la misma altura del aliado
        target.y = allie.transform.position.y;

        CalculateHeading(target, allie);

        allie.transform.forward = heading;

        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        if (distance <= range)
        {
            Animaciones.ataque(allie.GetComponentInChildren<Animator>(), allie.GetComponent<Unit>().Name, FindObjectOfType<Animaciones>(), enemy, allie);
            //Animaciones.recibirDano(enemy.GetComponentInChildren<Animator>(), enemy.GetComponent<Unit>().Name, enemy, FindObjectOfType<Animaciones>());
            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
            FindObjectOfType<BattleHUD>().SetHP(enemy.GetComponent<Unit>().party, enemy.GetComponent<Unit>().myteam, enemy.GetComponent<Unit>().Life);
            return true;
        }
        else
        {
            //Debug.Log("No hay rango");
            return false;
        }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Range
    {
        get { return range; }
        set { range = value; }
    }
}
