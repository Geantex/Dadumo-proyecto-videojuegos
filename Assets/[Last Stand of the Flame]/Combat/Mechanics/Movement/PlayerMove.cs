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
    GameObject actualTarget = null;
    GameObject lastTarget = null;
    bool clicked = false;
    bool firstClick = false;
    bool clickedMarked = false;

    public BattleHUD battleHUD;

    public Material enemyColor;

    public bool basicAttack = false;
    public bool specialAttack = false;

    // Use this for initialization
    void Start () 
	{
        battleHUD = FindObjectOfType<BattleHUD>();
        //Prueba Special Attack
        //battleHUD.buttonSpecialAttack1.onClick.AddListener(SpecialAttackButton);
        //buttonh3.onClick.AddListener();
        //Prueba Special Attack

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

        if (!moving)
        {
            if (basicAttack && targets.Count > 0)
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

                            Renderer renderer = sobreUnidad.collider.gameObject.GetComponentInChildren<Renderer>();
                            //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
                            renderer.material = enemyColor;
                            //AoD = Attack(sobreUnidad.collider.gameObject, gameObject);
                            //TurnManager.EndTurn();
                        }
                    }
                }
            }
        
                /*if (!clicked)
                {
                    if(gameObject.GetComponent<PlayerAttack>().AttackMouse() != null && firstClick)
                    {
                        actualTarget = gameObject.GetComponent<PlayerAttack>().AttackMouse();
                        if (actualTarget != null)
                        {
                            clicked = true;
                            StartCoroutine(EsperarCincoSegundos());
                        }
                        clickedMarked = false;
                    }
                    if (!firstClick)
                    {
                        actualTarget = gameObject.GetComponent<PlayerAttack>().AttackMouse();
                        if (actualTarget != null)
                        {
                            clicked = true;
                            firstClick = true;
                            StartCoroutine(EsperarCincoSegundos());
                        }
                        clickedMarked = false;
                    }

                }
                if (!clickedMarked && lastTarget != actualTarget)
                {
                    if (lastTarget != null)
                    {
                        Renderer renderer = lastTarget.GetComponentInChildren<Renderer>();
                        //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
                        renderer.material = enemyColor;
                    }
                    lastTarget = actualTarget;
                    clickedMarked = true;
                }*/

            if (!calculateZone)
            {
                FindSelectableTiles();
                calculateZone = true;
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
        targets = gameObject.GetComponent<PlayerAttack>().AttackMouse();
        basicAttack = true;

        if (actualTarget != null)
        {
            gameObject.GetComponent<PlayerAttack>().AoD = gameObject.GetComponent<PlayerAttack>().Attack(actualTarget, gameObject);
            clicked = false;
            firstClick = false;
            Renderer renderer = lastTarget.GetComponentInChildren<Renderer>();
            //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
            renderer.material = enemyColor;
            lastTarget = null;
            actualTarget = null;
            TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>()); //AQUI
        }
    }

    void SpecialAttackButton()
    {
        if (actualTarget != null)
        {
            gameObject.GetComponent<PlayerSpecialAttack>().AoD = gameObject.GetComponent<PlayerSpecialAttack>().AllSpecialAttacks[0].Attack(actualTarget, gameObject);
            clicked = false;
            firstClick = false;
            Renderer renderer = lastTarget.GetComponentInChildren<Renderer>();
            //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
            renderer.material = enemyColor;
            lastTarget = null;
            actualTarget = null;
            TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>()); //AQUI
        }
    }

    void endMyTurn()
    {
        Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHH");
        clicked = false;
        firstClick = false;
        if(actualTarget != null)
        {
            Renderer renderer = lastTarget.GetComponentInChildren<Renderer>();
            //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
            renderer.material = enemyColor;
        }
        lastTarget = null;
        actualTarget = null;

        basicAttack = false;
        specialAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>()); //AQUI
    }

    IEnumerator EsperarCincoSegundos()
    {
        yield return new WaitForSeconds(1);
        //Aquí es donde colocas la acción que quieres realizar después de cinco segundos
        clicked = false;
    }
}
