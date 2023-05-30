using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : BasicAttack
{
    public bool AoD = true;
    public Material enemySelectedColor;
    public Material enemyBasicColor;



    // Start is called before the first frame update
    void Start()
    {
        //Damage = gameObject.GetComponent<Unit>().Damage;
        //Range = gameObject.GetComponent<Unit>().Range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> AttackMouse()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        List<GameObject> targets = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distance <= Range)
            {
                targets.Add(enemy);
                Renderer renderer = enemy.GetComponentInChildren<Renderer>();
                renderer.material = enemySelectedColor;
            }
        }
        return targets;
    }

    public void AttackOfPlayer(GameObject target)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject enemy in enemies)
        {
            Renderer renderer = enemy.GetComponentInChildren<Renderer>();
            renderer.material = enemyBasicColor;
        }
        Attack(target, gameObject);

        gameObject.GetComponent<PlayerMove>().basicAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
    }
}
