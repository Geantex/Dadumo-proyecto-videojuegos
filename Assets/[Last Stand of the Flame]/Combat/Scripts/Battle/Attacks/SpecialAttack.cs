using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int range;
    [SerializeField] string stateEffect;
    [SerializeField] double stateEffectProbability;
    [SerializeField] string boostType;
    [SerializeField] double boostValue;

    public SpecialAttack(int damage, int range, string stateEffect, double stateEffectProbability, string boostType, double boostValue)
    {
        this.damage = damage;
        this.range = range;
        this.stateEffect = stateEffect;
        this.stateEffectProbability = stateEffectProbability;
        this.boostType = boostType;
        this.boostValue = boostValue;
    }
    // Start is called before the first frame update
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
            Debug.Log("La distancia entre los dos objetos es: " + distance);
            if (stateEffect != null && stateEffectProbability != null)
            {
                if (Random.Range(0, 100) < stateEffectProbability)
                {
                    enemy.GetComponent<Unit>().StateEffect = stateEffect;
                }
            }
            if (boostType != null && boostValue != null)
            {
                enemy.GetComponent<Unit>().BoostType = boostType;
                enemy.GetComponent<Unit>().Boost = boostValue;
            }
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

    public string StateEffect
    {
        get { return stateEffect; }
        set { stateEffect = value; }
    }

    public double StateEffectProbability
    {
        get { return stateEffectProbability; }
        set { stateEffectProbability = value; }
    }

    public string BoostType
    {
        get { return boostType; }
        set { boostType = value; }
    }

    public double BoostValue
    {
        get { return boostValue; }
        set { boostValue = value; }
    }
}
