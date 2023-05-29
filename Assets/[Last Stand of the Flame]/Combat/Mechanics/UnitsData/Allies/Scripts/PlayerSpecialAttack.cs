using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public bool AoD = true;
    public List<SpecialAttack> AllSpecialAttacks = new List<SpecialAttack>();
    public Material enemySelectedColor;
    public Material enemyBasicColor;

    //public Material enemyColor;
    // Start is called before the first frame update
    void Start()
    {
        //AddSpecialAttack(new SpecialAttack(20, 1, 8, "Area", "Paralyze", 80, "Attack", 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> AttackMouse(int attackIndex)
    {
        List<GameObject> targets = new List<GameObject>();
        switch (AllSpecialAttacks[attackIndex].TargetType)
        {
            case "Aliados":
                GameObject[] allies = GameObject.FindGameObjectsWithTag("Player");
                

                foreach (GameObject ally in allies)
                {
                    float distance = Vector3.Distance(ally.transform.position, gameObject.transform.position);
                    if (distance <= AllSpecialAttacks[attackIndex].Range)
                    {
                        targets.Add(ally);
                        Renderer renderer = ally.GetComponentInChildren<Renderer>();
                        renderer.material = enemySelectedColor;
                    }
                }
                break;
            case "Enemigos":
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
                    if (distance <= AllSpecialAttacks[attackIndex].Range)
                    {
                        targets.Add(enemy);
                        Renderer renderer = enemy.GetComponentInChildren<Renderer>();
                        renderer.material = enemySelectedColor;
                    }
                }
                break;
            case "Todos":
                GameObject[] alliesAll = GameObject.FindGameObjectsWithTag("Player");


                foreach (GameObject ally in alliesAll)
                {
                    float distance = Vector3.Distance(ally.transform.position, gameObject.transform.position);
                    if (distance <= AllSpecialAttacks[attackIndex].Range)
                    {
                        targets.Add(ally);
                        Renderer renderer = ally.GetComponentInChildren<Renderer>();
                        renderer.material = enemySelectedColor;
                    }
                }

                GameObject[] enemiesAll = GameObject.FindGameObjectsWithTag("NPC");

                foreach (GameObject enemy in enemiesAll)
                {
                    float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
                    if (distance <= AllSpecialAttacks[attackIndex].Range)
                    {
                        targets.Add(enemy);
                        Renderer renderer = enemy.GetComponentInChildren<Renderer>();
                        renderer.material = enemySelectedColor;
                    }
                }
                break;
        }
        return targets;
    }

    public void AttackOfPlayer(int attackIndex, GameObject target, List<GameObject> allTargets)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject enemy in enemies)
        {
            Renderer renderer = enemy.GetComponentInChildren<Renderer>();
            renderer.material = enemyBasicColor;
        }

        switch (AllSpecialAttacks[attackIndex].RangeType)
        {
            case "Normal":
                for(int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                {
                    AllSpecialAttacks[attackIndex].Attack(target, gameObject);
                }
                break;
            case "Area":
                foreach (GameObject oneTaregt in allTargets)
                {
                    for (int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                    {
                        AllSpecialAttacks[attackIndex].Attack(target, gameObject);
                    }
                }
                break;
            case "Curacion":
                for (int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                {
                    AllSpecialAttacks[attackIndex].Attack(target, gameObject);
                }
                break;
        }
        gameObject.GetComponent<PlayerMove>().basicAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
    }

    public void AddSpecialAttack(SpecialAttack SpecialAttack)
    {
        if (!AllSpecialAttacks.Contains(SpecialAttack))
        {
            if (AllSpecialAttacks.Count < 4)
            {
                AllSpecialAttacks.Add(SpecialAttack);
            }
        }
    }
}
