using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove 
{
    GameObject target;

	// Use this for initialization
	void Start () 
	{
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
            calculateZone = false;
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
        }
        else
        {
            gameObject.GetComponent<NPCAttack>().AttackNPC();
            //Move();
        }

        /*if(actualTurn < gameObject.GetComponent<TacticsMove>().numTurn)
        {
            gameObject.GetComponent<Unit>().Attack.Attack(target, gameObject);
        }*/
    }

    void CalculatePath()
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile);
    }

    public GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
        return nearest;
    }

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
