using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpecialAttack : MonoBehaviour
{
    public bool AoD = true;
    public List<SpecialAttack> AllSpecialAttacks = new List<SpecialAttack>();
    // Start is called before the first frame update
    void Start()
    {
        
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
                    if (distance <= (AllSpecialAttacks[attackIndex].Range + 0.5f))
                    {
                        targets.Add(ally);
                        ally.GetComponent<Unit>().circulo.SetActive(true);
                    }
                }
                break;
            case "Enemigos":
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                foreach (GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
                    if (distance <= (AllSpecialAttacks[attackIndex].Range + 0.5f))
                    {
                        targets.Add(enemy);
                        enemy.GetComponent<Unit>().circulo.SetActive(true);
                    }
                }
                break;
            case "Todos":
                GameObject[] alliesAll = GameObject.FindGameObjectsWithTag("Player");


                foreach (GameObject ally in alliesAll)
                {
                    float distance = Vector3.Distance(ally.transform.position, gameObject.transform.position);
                    if (distance <= (AllSpecialAttacks[attackIndex].Range + 0.5f))
                    {
                        targets.Add(ally);
                        ally.GetComponent<Unit>().circulo.SetActive(true);
                    }
                }

                GameObject[] enemiesAll = GameObject.FindGameObjectsWithTag("NPC");

                foreach (GameObject enemy in enemiesAll)
                {
                    float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
                    if (distance <= (AllSpecialAttacks[attackIndex].Range + 0.5f))
                    {
                        targets.Add(enemy);
                        enemy.GetComponent<Unit>().circulo.SetActive(true);
                    }
                }
                break;
        }
        return targets;
    }

    public void AttackOfPlayer(int attackIndex, GameObject target, List<GameObject> allTargets)
    {

        if (SceneManager.GetActiveScene().name == "TutorialCombate")
        {
            // ESTO OCURRE SOLO EN LA ESCENA DE TUTORIAL
            // Sé que esto está horriblemente optimizado, quien lo arregle se lleva un beso y una hora de trello.
            TutorialConsejos _tutorialConsejos = GameObject.Find("TutorialConsejos").GetComponent<TutorialConsejos>();
            if (_tutorialConsejos.contadorConsejo == 3)
            {
                _tutorialConsejos.CerrarConsejo();
            }

        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Unit>().circulo.SetActive(false);
        }

        GameObject[] allies = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject ally in allies)
        {
            ally.GetComponent<Unit>().circulo.SetActive(false);
        }

        switch (AllSpecialAttacks[attackIndex].RangeType)
        {
            case "Normal":
                for(int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                {
                    AllSpecialAttacks[attackIndex].Attack(target, gameObject);
                }
                gameObject.GetComponent<Unit>().Mana = gameObject.GetComponent<Unit>().Mana - AllSpecialAttacks[attackIndex].ManaCost;
                FindObjectOfType<BattleHUD>().SetMana(gameObject.GetComponent<Unit>().party, gameObject.GetComponent<Unit>().myteam, gameObject.GetComponent<Unit>().Mana);
                break;
            case "Area":
                foreach (GameObject oneTarget in allTargets)
                {
                    for (int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                    {
                        AllSpecialAttacks[attackIndex].Attack(oneTarget, gameObject);
                    }
                }
                gameObject.GetComponent<Unit>().Mana = gameObject.GetComponent<Unit>().Mana - AllSpecialAttacks[attackIndex].ManaCost;
                FindObjectOfType<BattleHUD>().SetMana(gameObject.GetComponent<Unit>().party, gameObject.GetComponent<Unit>().myteam, gameObject.GetComponent<Unit>().Mana);
                break;
            case "Curacion":
                for (int i = 0; i < AllSpecialAttacks[attackIndex].DamageTimes; i++)
                {
                    AllSpecialAttacks[attackIndex].Attack(target, gameObject);
                }
                gameObject.GetComponent<Unit>().Mana = gameObject.GetComponent<Unit>().Mana - AllSpecialAttacks[attackIndex].ManaCost;
                FindObjectOfType<BattleHUD>().SetMana(gameObject.GetComponent<Unit>().party, gameObject.GetComponent<Unit>().myteam, gameObject.GetComponent<Unit>().Mana);
                break;
        }
        gameObject.GetComponent<PlayerMove>().basicAttack = false;
        gameObject.GetComponent<PlayerMove>().specialAttack = false;

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

    public bool canIDo(int attackIndex)
    {
        if (AllSpecialAttacks[attackIndex].ManaCost <= gameObject.GetComponent<Unit>().Mana)
        {
            return true;
        }
        return false;
    }
}
