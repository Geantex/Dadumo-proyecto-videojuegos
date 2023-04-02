using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{
    GameObject target;

    // Use this for initialization
    void Start()
    {
        Init(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNPCMove(GameObject gameObject)
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindNearestTarget();
            CalculatePath(gameObject);
            FindSelectableTiles(gameObject);
            actualTargetTile.target = true;
        }
        else
        {
            Move(gameObject);
        }
    }

    void CalculatePath(GameObject gameObject)
    {
        Tile targetTile = GetTargetTile(target);
        FindPath(targetTile, gameObject);
    }

    void FindNearestTarget()
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
    }
}
