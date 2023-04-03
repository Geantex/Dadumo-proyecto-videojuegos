using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static Dictionary<string, List<Unit>> units = new Dictionary<string, List<Unit>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<Unit> turnTeam = new Queue<Unit>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (turnTeam.Count == 0)
        {
            InitTeamTurnQueue();
        }
    }

    static void InitTeamTurnQueue()
    {
        if (turnKey.Count == 0)
        {
            foreach (string key in units.Keys)
            {
                turnKey.Enqueue(key);
            }
        }

        Debug.Log("turnKey contents: " + string.Join(", ", turnKey));

        List<Unit> teamList = units[turnKey.Peek()];
        
        foreach (Unit unit in teamList)
        {
            turnTeam.Enqueue(unit);
        }

        StartTurn();
    }

    public static void StartTurn()
    {
        if (turnTeam.Count > 0)
        {
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        Unit unit = turnTeam.Dequeue();
        unit.EndTurn();

        if (turnTeam.Count > 0)
        {
            StartTurn();
        }
        else
        {
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }
    }

    public static void AddUnit(Unit unit, TacticsMove tactic)
    {
        List<Unit> list;

        if (!units.ContainsKey(unit.tag))
        {
            list = new List<Unit>();
            units[unit.tag] = list;

            if (!turnKey.Contains(unit.tag))
            {
                turnKey.Enqueue(unit.tag);
            }
        }
        else
        {
            list = units[unit.tag];
        }

        list.Add(unit);
    }
}
