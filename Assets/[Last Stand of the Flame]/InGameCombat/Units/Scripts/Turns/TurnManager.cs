using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour 
{
    static int contador;
    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();

	// Use this for initialization
	void Start () 
	{
        Debug.Log("Entro en los turnos");
        
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (turnTeam.Count == 0)
        {
            InitTeamTurnQueue();
        }
	}

    static void InitTeamTurnQueue()
    {
        List<TacticsMove> teamList = units[turnKey.Peek()];
        List<TacticsMove> teamListCopy = new List<TacticsMove>(teamList);

        foreach (TacticsMove unit in teamListCopy)
        {
            Debug.Log(unit);
            GameObject gameObject = GameObject.Find(unit.name);
            if(gameObject.GetComponent<Unit>().Life > 0)
            {
                turnTeam.Enqueue(unit);
                
                Debug.Log("Unidad buena");
            }
            else
            {
                Debug.Log("Unidad eliminada");
                units[turnKey.Peek()].Remove(unit);
                //teamList.Remove(unit);
            }
            
        }

        StartTurn();
    }

    public static void StartTurn()
    {
        Debug.Log("----------------------------------------------------");
        List<TacticsMove> teamList = units[turnKey.Peek()];

        foreach (TacticsMove unit in teamList)
        {
            GameObject gameObjectPlayer = unit.gameObject;
            Debug.Log(gameObjectPlayer);
            //Aquí me da el error
            FindObjectOfType<BattleHUD>().SetHUD(gameObjectPlayer.GetComponent<Unit>().Name, 8, 100, 50);
            
        }
        Debug.Log("----------------------------------------------------");
        if (turnTeam.Count > 0)
        {
            contador++;
            Debug.Log(contador);
            turnTeam.Peek().BeginTurn();
        }
    }

    public static void EndTurn()
    {
        TacticsMove unit = turnTeam.Dequeue();
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

    public static void AddUnit(TacticsMove unit)
    {
        List<TacticsMove> list;

        if (!units.ContainsKey(unit.tag))
        {
            list = new List<TacticsMove>();
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
