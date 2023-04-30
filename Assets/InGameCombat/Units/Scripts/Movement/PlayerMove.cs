using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : TacticsMove 
{
    public Button buttonh1;
    public Button buttonh2;
    public Button buttonh3;
    public Button buttonh4;

    GameObject actualTarget = null;
    GameObject lastTarget = null;
    bool clicked = false;
    bool clickedMarked = false;
	// Use this for initialization
	void Start () 
	{
        //AddButton();
        buttonh1.onClick.AddListener(AttackButton);
        buttonh4.onClick.AddListener(endMyTurn);
        while (!GameObject.FindWithTag("Tablero").GetComponent<Spawner>().TableroCreado)
        {

        }
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Debug.Log("Entro en UPDATE PLAYERMOVE");
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (GameObject.FindWithTag("Tablero").GetComponent<Spawner>().TableroCreado)
        {
            if (!moving)
            {
                if (!clicked)
                {
                    actualTarget = gameObject.GetComponent<PlayerAttack>().AttackMouse();
                    if (actualTarget != null)
                    {
                        clicked = true;
                    }
                    clickedMarked = false;

                }
                if (!clickedMarked)
                {
                    if (lastTarget != null)
                    {
                        Renderer renderer = lastTarget.GetComponentInChildren<Renderer>();
                        renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
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
        buttonh1 = gameObjectButtonH1.AddComponent<Button>();
        buttonh1.onClick.AddListener(AttackButton);

        GameObject gameObjectButtonH2 = gameObjectButton.transform.Find("H2").gameObject;
        buttonh2 = gameObjectButtonH2.AddComponent<Button>();

        GameObject gameObjectButtonH3 = gameObjectButton.transform.Find("H3").gameObject;
        buttonh3 = gameObjectButtonH3.AddComponent<Button>();

        GameObject gameObjectButtonH4 = gameObjectButton.transform.Find("H4").gameObject;
        buttonh4 = gameObjectButtonH4.AddComponent<Button>();
    }

    void AttackButton()
    {
        if (actualTarget != null)
        {
            gameObject.GetComponent<PlayerAttack>().AoD = gameObject.GetComponent<PlayerAttack>().Attack(actualTarget, gameObject);
            clicked = false;
            Renderer renderer = actualTarget.GetComponentInChildren<Renderer>();
            renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Seleccionado.mat");
            TurnManager.EndTurn();
        }
    }

    void endMyTurn()
    {
        TurnManager.EndTurn();
    }
}
