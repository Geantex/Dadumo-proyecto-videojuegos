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

    GameObject actualTarget = null;
    GameObject lastTarget = null;
    bool clicked = false;
    bool firstClick = false;
    bool clickedMarked = false;

    public BattleHUD battleHUD;

    public Material enemyColor;

    // Use this for initialization
    void Start () 
	{
        battleHUD = new BattleHUD();

        //Prueba Special Attack
        buttonSpecialAttack1.onClick.AddListener(SpecialAttackButton);
        //buttonh3.onClick.AddListener();
        //Prueba Special Attack

        buttonBasicAttack.onClick.AddListener(AttackButton);
        buttonFinishTurn.onClick.AddListener(endMyTurn);
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

        battleHUD = new BattleHUD();

        if (GameObject.FindWithTag("Tablero").GetComponent<Spawner>().TableroCreado)
        {
            if (!moving)
            {
                if (!clicked)
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
                }

                if (!calculateZone)
                {
                    FindSelectableTiles();
                    calculateZone = true;
                }
                //FindSelectableTiles();
                CheckMouse();
            }
            else
            {

                Move();
            }
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

    void AddButton()
    {
        GameObject gameObjectButton = GameObject.FindWithTag("HUD");

        GameObject gameObjectButtonH1 = gameObjectButton.transform.Find("H1").gameObject;
        buttonBasicAttack = gameObjectButtonH1.AddComponent<Button>();
        buttonBasicAttack.onClick.AddListener(AttackButton);

        GameObject gameObjectButtonH2 = gameObjectButton.transform.Find("H2").gameObject;
        buttonSpecialAttack1 = gameObjectButtonH2.AddComponent<Button>();

        GameObject gameObjectButtonH3 = gameObjectButton.transform.Find("H3").gameObject;
        buttonSpecialAttack2 = gameObjectButtonH3.AddComponent<Button>();

        GameObject gameObjectButtonH4 = gameObjectButton.transform.Find("H4").gameObject;
        buttonFinishTurn = gameObjectButtonH4.AddComponent<Button>();
    }

    void AttackButton()
    {
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
            TurnManager.EndTurn();
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
            TurnManager.EndTurn();
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
        TurnManager.EndTurn();
    }

    IEnumerator EsperarCincoSegundos()
    {
        yield return new WaitForSeconds(1);
        //Aquí es donde colocas la acción que quieres realizar después de cinco segundos
        clicked = false;
    }
}
