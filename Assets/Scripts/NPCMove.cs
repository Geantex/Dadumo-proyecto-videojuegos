using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TacticsMove
{
    GameObject target;

    // Use this for initialization
    void Start()
    {
        //Init(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNPCMove(GameObject gameObject, bool turn)
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindNearestTarget(gameObject);
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
        Tile targetTile;
        Debug.Log("SuperTarget" + target + "SuperOtro" + target.transform.position);
        /*if(target.transform.position == null)
        {
            targetTile = GetTargetTile(target);
        }
        else
        {
            targetTile = GetTargetTile(gameObject);
        }*/
        targetTile = GetTargetTile(target);

        FindPath(targetTile, gameObject);
    }

    void FindNearestTarget(GameObject gameObject)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(gameObject.transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
    }
}
