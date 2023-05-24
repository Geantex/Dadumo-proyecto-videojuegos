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
        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        if (distance <= range)
        {
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
