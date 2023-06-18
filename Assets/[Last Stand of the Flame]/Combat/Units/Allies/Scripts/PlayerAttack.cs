using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttack : BasicAttack
{
    public bool AoD = true;



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
            if (distance <= (Range + 0.5f))
            {
                targets.Add(enemy);
                enemy.GetComponent<Unit>().circulo.SetActive(true);
            }
        }
        return targets;
    }

    public List<GameObject> AttackKey()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        List<GameObject> targets = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distance <= (Range + 0.5f))
            {
                targets.Add(enemy);
                //enemy.GetComponent<Unit>().circulo.SetActive(true);
            }
        }
        return targets;
    }

    public void AttackOfPlayer(GameObject target)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Unit>().circulo.SetActive(false);
        }

        gameObject.GetComponent<PlayerMove>().Targets.Clear();

        if (SceneManager.GetActiveScene().name == "TutorialCombate")
        {
            // ESTO OCURRE SOLO EN LA ESCENA DE TUTORIAL
            // Sé que esto está horriblemente optimizado, quien lo arregle se lleva un beso y una hora de trello.
            TutorialConsejos _tutorialConsejos = GameObject.Find("TutorialConsejos").GetComponent<TutorialConsejos>();
            if (_tutorialConsejos.contadorConsejo == 2)
            {
                // esta funcion solo se llamara si el contador es 2, es decir, mostrará solamente el TERCER consejo
                _tutorialConsejos.DeslizarPanel();
            }

        }
        gameObject.GetComponent<PlayerMove>().basicAttack = false;
        gameObject.GetComponent<PlayerMove>().specialAttack = false;

        Attack(target, gameObject);
        //TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
    }
}