using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TacticsMove : MonoBehaviour
{
    //public bool turn = false;

    List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

    public bool moving = false;
    public int move = 5;
    public float jumpHeight = 2;
    public float moveSpeed = 2;
    public float jumpVelocity = 4.5f;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    bool fallingDown = false;
    bool jumpingUp = false;
    bool movingEdge = false;
    Vector3 jumpTarget;

    public Tile actualTargetTile;
    public void Init(GameObject gameObject, Unit unit) 
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        halfHeight = gameObject.GetComponent<Collider>().bounds.extents.y;

        //GetCurrentTile(gameObject);
        TurnManager.AddUnit(unit, this);
    }

    public void GetCurrentTile(GameObject gameObject)
    {
        currentTile = GetTargetTile(gameObject);
        currentTile.current = true;
    }

    public Tile GetTargetTile(GameObject target)
    {
        RaycastHit hit;
        Tile tile = null;
        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1)) 
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        Debug.Log(tile);
        return tile;
    }

    public void ComputeAdjacencyLists(float jumpHeight, Tile target)
    {
        //tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(jumpHeight, target);
        }
    }

    public void FindSelectableTiles(GameObject gameObject)
    {
        ComputeAdjacencyLists(jumpHeight, null);
        GetCurrentTile(gameObject);

        Queue<Tile> process = new Queue<Tile>();

        process.Enqueue(currentTile);
        currentTile.visited = true;
        //currentTile.parent = ??  leave as null 

        while (process.Count > 0)
        {
            Tile t = process.Dequeue();

            selectableTiles.Add(t);
            t.selectable = true;

            if (t.distance < move)
            {
                foreach (Tile tile in t.adjacencyList)
                {
                    if (!tile.visited)
                    {
                        tile.parent = t;
                        tile.visited = true;
                        tile.distance = 1 + t.distance;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }
    public void MoveToTile(Tile tile)
    {
        path.Clear();
        tile.target = true;
        moving = true;

        Tile next = tile;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Move(GameObject gameObject)
    {
        if (path.Count > 0)
        {
            //Tile t = path.Peek();
            Tile t = path.Peek();
            if (t != null) // Agrega esta verificación condicional para evitar acceder a una referencia nula
            {
                Vector3 target = t.transform.position;

                // Calculate the unit's position on top of the target tile (we are going to move it there!)
                target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

                if (Vector3.Distance(gameObject.transform.position, target) >= 0.05f)
                {
                    bool jump = gameObject.transform.position.y != target.y;

                    if (jump)
                    {
                        Jump(target, gameObject);
                    }
                    else
                    {
                        CalculateHeading(target, gameObject);
                        SetHorizontalVelocity();
                    }

                    gameObject.transform.forward = heading;
                    gameObject.transform.position += velocity * Time.deltaTime;
                }
                else
                {
                    // Tile center reached
                    gameObject.transform.position = target;
                    path.Pop();

                    
                }
            }
        }
        else
        {
            RemoveSelectableTiles();
            moving = false;

            TurnManager.EndTurn();
        }
    }
    
    protected void RemoveSelectableTiles()
    {
        if (currentTile != null)
        {
            currentTile.current = false;
            currentTile= null;
        }
        foreach (Tile tile in selectableTiles)
        {
            tile.Reset();
        }

        selectableTiles.Clear();
    }
    void CalculateHeading(Vector3 target, GameObject gameObject)
    {
        heading = target - gameObject.transform.position;
        heading.Normalize();

    }
    void SetHorizontalVelocity()
    {
        velocity = heading * moveSpeed;
    }

    void Jump(Vector3 target, GameObject gameObject)
    {
        if (fallingDown)
        {
            FallDownward(target, gameObject);
        }
        else if (jumpingUp)
        {
            JumpUpward(target, gameObject);
        }
        else if (movingEdge)
        {
            MoveToEdge(gameObject);
        }
        else
        {
            PrepareJump(target, gameObject);
        }
    }

    void PrepareJump(Vector3 target, GameObject gameObject)
    {
        float targetY = target.y;
        target.y = transform.position.y;

        CalculateHeading(target, gameObject);

        if (transform.position.y > targetY)
        {
            fallingDown = false;
            jumpingUp = false;
            movingEdge = true;

            jumpTarget = gameObject.transform.position + (target - gameObject.transform.position) / 2.0f;
        }
        else
        {
            fallingDown = false;
            jumpingUp = true;
            movingEdge = false;

            velocity = heading * moveSpeed / 3.0f;

            float difference = targetY - gameObject.transform.position.y;

            velocity.y = jumpVelocity * (0.5f + difference / 2.0f);
        }
    }

    void FallDownward(Vector3 target, GameObject gameObject)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (gameObject.transform.position.y <= target.y)
        {
            fallingDown = false;
            jumpingUp = false;
            movingEdge = false;

            Vector3 p = gameObject.transform.position;
            p.y = target.y;
            gameObject.transform.position = p;

            velocity = new Vector3();
        }
    }

    void JumpUpward(Vector3 target, GameObject gameObject)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (gameObject.transform.position.y > target.y)
        {
            jumpingUp = false;
            fallingDown = true;
        }
    }

    void MoveToEdge(GameObject gameObject)
    {
        if (Vector3.Distance(gameObject.transform.position, jumpTarget) >= 0.05f)
        {
            SetHorizontalVelocity();
        }
        else
        {
            movingEdge = false;
            fallingDown = true;

            velocity /= 5.0f;
            velocity.y = 1.5f;
        }
    }

    protected Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0];

        foreach (Tile t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);

        return lowest;
    }

    protected Tile FindEndTile(Tile t)
    {
        Stack<Tile> tempPath = new Stack<Tile>();

        Tile next = t.parent;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        Tile endTile = null;
        for (int i = 0; i <= move; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }

    protected void FindPath(Tile target, GameObject gameObject)
    {
        ComputeAdjacencyLists(jumpHeight, target);
        GetCurrentTile(gameObject);

        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        openList.Add(currentTile);
        //currentTile.parent = ??
        Debug.Log(target.transform.position);
        Debug.Log(currentTile.transform.position);
        currentTile.h = Vector3.Distance(currentTile.transform.position, target.transform.position);
        currentTile.f = currentTile.h;

        while (openList.Count > 0)
        {
            Tile t = FindLowestF(openList);

            closedList.Add(t);

            if (t == target)
            {
                actualTargetTile = FindEndTile(t);
                MoveToTile(actualTargetTile);
                return;
            }

            foreach (Tile tile in t.adjacencyList)
            {
                if (closedList.Contains(tile))
                {
                    //Do nothing, already processed
                }
                else if (openList.Contains(tile))
                {
                    float tempG = t.g + Vector3.Distance(tile.transform.position, t.transform.position);

                    if (tempG < tile.g)
                    {
                        tile.parent = t;

                        tile.g = tempG;
                        tile.f = tile.g + tile.h;
                    }
                }
                else
                {
                    tile.parent = t;

                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector3.Distance(tile.transform.position, target.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }
            }
        }

        //todo - what do you do if there is no path to the target tile?
        Debug.Log("Path not found");
    }

    
}



    