using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int life = 150;
    private int mana = 100;
    private int movement;
    private PlayerMove move = new PlayerMove();
    private NPCMove npc = new NPCMove();
    private string stateEffect;
    private string boostType;
    private double boost;
    private BasicAtack atack = new BasicAtack(9, 20);
    private ArrayList specialAtacks = new ArrayList();
    private GameObject selectedObject;
    public bool turn = false;

    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player")
        {
            move.Init(gameObject, this);
        }
        else if (gameObject.tag == "NPC")
        {
            npc.Init(gameObject, this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            move.UpdateMove(gameObject, turn);
        }
        else if (gameObject.tag == "NPC")
        {
            npc.UpdateNPCMove(gameObject, turn);
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "NPC")
                {
                    selectedObject = hit.transform.gameObject;
                }
                
            }
        }
        if(selectedObject != null && selectedObject.GetComponent<Unit>() != null)
        {
            atack.Atack(selectedObject, GameObject.FindGameObjectWithTag("Player"));
            Debug.Log("Clicked: " + selectedObject.GetComponent<Unit>().Life);
        }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    public string StateEffect
    {
        get { return stateEffect; }
        set { stateEffect = value; }
    }

    public string BoostType
    {
        get { return boostType; }
        set { boostType = value; }
    }

    public double Boost
    {
        get { return boost; }
        set { boost = value; }
    }

    public void AddSpecialAtack(SpecialAtack specialAtack)
    {
        specialAtacks.Add(specialAtack);
    }
}
