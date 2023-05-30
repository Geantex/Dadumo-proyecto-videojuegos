using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpecialAttack", menuName = "Special Attack")]
public class SpecialAttack : ScriptableObject
{
    [SerializeField] int manaCost;
    [SerializeField] int damage;
    [SerializeField] int damageTimes;
    [SerializeField] int range;
    [SerializeField] string rangeType;
    [SerializeField] string targetType;
    [SerializeField] string stateEffect;
    [SerializeField] double stateEffectProbability;
    [SerializeField] string boostType;
    [SerializeField] double boostValue;

    public SpecialAttack(int damage, int damageTimes, int range, string rangeType, string stateEffect, double stateEffectProbability, string boostType, double boostValue)
    {
        this.damage = damage;
        this.damageTimes = damageTimes;
        this.range = range;
        this.rangeType = rangeType;
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
            if(rangeType == "Curacion")
            {
                enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life + damage;

                if(enemy.GetComponent<Unit>().Life > enemy.GetComponent<Unit>().MaxLife)
                {
                    enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().MaxLife;
                }

                FindObjectOfType<BattleHUD>().SetHP(enemy.GetComponent<Unit>().party, enemy.GetComponent<Unit>().myteam, enemy.GetComponent<Unit>().Life);
            }
            else
            {
                Animaciones.ataqueEspecial(allie.GetComponentInChildren<Animator>(), allie.GetComponent<Unit>().Name);
                Animaciones.recibirDaño(enemy.GetComponentInChildren<Animator>(), enemy.GetComponent<Unit>().Name, enemy, FindObjectOfType<Animaciones>());
                enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
                FindObjectOfType<BattleHUD>().SetHP(enemy.GetComponent<Unit>().party, enemy.GetComponent<Unit>().myteam, enemy.GetComponent<Unit>().Life);
            }
           
            applyBoost(enemy);
            applyState(enemy);

            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Mana - manaCost;
            FindObjectOfType<BattleHUD>().SetMana(allie.GetComponent<Unit>().party, allie.GetComponent<Unit>().myteam, allie.GetComponent<Unit>().Mana);

            return true;
        }
        else
        {
            Debug.Log("No hay rango");
            return false;
        }
    }

    public void applyBoost(GameObject enemy)
    {
        switch (boostType)
        {
            case "Attack":
                enemy.GetComponent<PlayerAttack>().Damage = enemy.GetComponent<PlayerAttack>().Damage + (int)boostValue;
                break;
            case "Range":
                enemy.GetComponent<PlayerAttack>().Range = enemy.GetComponent<PlayerAttack>().Range + (int)boostValue;
                break;
            case "Speed":
                enemy.GetComponent<Unit>().Speed = enemy.GetComponent<Unit>().Speed + (int)boostValue;
                break;
            case "Life":
                enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life + (int)boostValue;
                break;
        }
    }

    public void applyState(GameObject enemy)
    {
        if (stateEffect != null)
        {
            if (Random.Range(0, 100) < stateEffectProbability)
            {
                enemy.GetComponent<Unit>().StateEffect = stateEffect;
            }
        }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int DamageTimes
    {
        get { return damageTimes; }
        set { damageTimes = value; }
    }

    public int Range
    {
        get { return range; }
        set { range = value; }
    }

    public string RangeType
    {
        get { return rangeType; }
        set { rangeType = value; }
    }

    public string TargetType
    {
        get { return targetType; }
        set { targetType = value; }
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
