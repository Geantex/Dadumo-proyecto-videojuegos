using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int range;
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

    public bool Attack(GameObject enemy, GameObject allie)
    {
        Debug.Log("Mi turno" + gameObject.name);
        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        if (distance <= range)
        {
            
            Debug.Log("La distancia entre los dos objetos es: " + distance);
            Debug.Log(enemy);
            Debug.Log(enemy.GetComponent<Unit>().Life);
            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
            //Debug.Log(enemy.GetComponent<Unit>().Life);
            return true;
        }
        else
        {
            Debug.Log("La distancia entre los dos objetos es: " + distance);
            Debug.Log("No hay rango");
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
