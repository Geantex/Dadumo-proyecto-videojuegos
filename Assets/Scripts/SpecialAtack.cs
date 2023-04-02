using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAtack : MonoBehaviour
{
    private int damage;
    private int range;
    private string stateEffect;
    private double stateEffectProbability;
    private string boostType;
    private double boostValue;

    public SpecialAtack(int damage, int range, string stateEffect, double stateEffectProbability, string boostType, double boostValue)
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

    public void Atack(GameObject enemy, GameObject allie)
    {
        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        if (distance <= range)
        {
            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
            if(stateEffect != null && stateEffectProbability != null)
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
        }

        Debug.Log("La distancia entre los dos objetos es: " + distance);
    }
}
