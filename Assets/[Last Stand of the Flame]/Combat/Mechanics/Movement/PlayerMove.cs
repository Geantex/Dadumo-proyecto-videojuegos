using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : TacticsMove 
{
    public Button buttonBasicAttack;
    public Button buttonSpecialAttack1;
    public Button buttonSpecialAttack2;
    public Button buttonSpecialAttack3;
    public Button buttonSpecialAttack4;
    public Button buttonFinishTurn;

    List<GameObject> targets = new List<GameObject>();

    public BattleHUD battleHUD;

    public bool basicAttack = false;
    public bool specialAttack = false;

    // Use this for initialization
    void Start () 
	{
        battleHUD = FindObjectOfType<BattleHUD>();
        //Prueba Special Attack
        battleHUD.buttonSpecialAttack1.onClick.AddListener(SpecialAttackButton);

        battleHUD.buttonBasicAttack.onClick.AddListener(AttackButton);
        battleHUD.buttonFinishTurn.onClick.AddListener(endMyTurn);
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (gameObject.GetComponent<PlayerSpecialAttack>().canIDo(0))
        {
            battleHUD.buttonSpecialAttack1.interactable = true;
        }
        else
        {
            battleHUD.buttonSpecialAttack1.interactable = false;
        }

        if (!moving)
        {
            if (basicAttack && targets.Count > 0)
            {
                DoBasicAttack();
            }
            if (specialAttack && targets.Count > 0)
            {
                DoSpecialAttack();
            }
            if (!calculateZone)
            {
                GetCurrentTile();
                FindSelectableTiles();
                calculateZone = true;
            }
            else
            {
                GetCurrentTile();
            }
            CheckMouse();
        }
        else
        {
            Move();
        }
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }

    void AttackButton()
    {
        if (!turn && !moving)
        {
            return;
        }

        targets = gameObject.GetComponent<PlayerAttack>().AttackMouse();
        basicAttack = true;
    }

    void DoBasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit sobreUnidad;
            if (Physics.Raycast(trackearCursor, out sobreUnidad))
            {
                if (sobreUnidad.collider.tag == "NPC")
                {
                    foreach (GameObject target in targets)
                    {
                        if (target == sobreUnidad.collider.gameObject)
                        {
                            gameObject.GetComponent<PlayerAttack>().AttackOfPlayer(target);
                        }
                    }
                }
            }
        }
    }

    void SpecialAttackButton()
    {
        if (!turn && !moving)
        {
            return;
        }

       targets = gameObject.GetComponent<PlayerSpecialAttack>().AttackMouse(0);
        specialAttack = true;
    }

    void DoSpecialAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit sobreUnidad;
            if (Physics.Raycast(trackearCursor, out sobreUnidad))
            {
                if (sobreUnidad.collider.tag == "NPC" || sobreUnidad.collider.tag == "Player")
                {
                    foreach (GameObject target in targets)
                    {
                        if (target == sobreUnidad.collider.gameObject)
                        {
                            gameObject.GetComponent<PlayerSpecialAttack>().AttackOfPlayer(0, target, targets);
                        }
                    }
                }
            }
        }
    }

    void endMyTurn()
    {
        if (!turn || moving)
        {
            return;
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
        basicAttack = false;
        specialAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
    }
}
