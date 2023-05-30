using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class NPCMove : TacticsMove 
{
    GameObject target;
    public Vector3 heading2;
    float halfHeight2 = 0;

    // Use this for initialization
    void Start () 
	{
        halfHeight2 = gameObject.GetComponent<Collider>().bounds.extents.y;
        //Vector3 target = gameObject.transform.position.y;

        Vector3 heading2 = gameObject.transform.position;
        heading2.Normalize();

        // Invertir el vector de dirección para que el personaje dé media vuelta
        heading2 = -heading2;

        gameObject.transform.forward = heading2;

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
