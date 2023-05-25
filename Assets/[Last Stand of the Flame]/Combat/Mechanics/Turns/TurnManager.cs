using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static List<TacticsMove> units = new List<TacticsMove>();

    // Use this for initialization
    void Start()
    {
        units.Clear();

        Debug.Log("-------------------INICIO DE TURNO-------------------");
        foreach (TacticsMove move in units)
        {
            Debug.Log(move);
            Debug.Log(move.name);
            Debug.Log(move.turn);
            Debug.Log("----------------------------------------------------");
        }
        Debug.Log("----------------------FIN DE TURNO-------------------");

        // Find all units with "Player" tag and add them to the list
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            TacticsMove player = playerObject.GetComponent<TacticsMove>();
            if (player != null)
            {
                units.Add(player);
                playerObject.GetComponent<Unit>().combatStart = true;
            }
        }

        // Find all units with "NPC" tag and add them to the list
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npcObject in npcObjects)
        {
            TacticsMove npc = npcObject.GetComponent<TacticsMove>();
            if (npc != null)
            {
                units.Add(npc);
                npcObject.GetComponent<Unit>().combatStart = true;
            }
        }

        Debug.Log("-------------------INICIO DE TURNO FIN-------------------");
        foreach (TacticsMove move in units)
        {
            Debug.Log(move);
            Debug.Log(move.name);
            Debug.Log(move.turn);
            Debug.Log("----------------------------------------------------");
        }
        Debug.Log("----------------------FIN DE TURNO FIN-------------------");

        foreach (TacticsMove move in units)
        {
            FindObjectOfType<BattleHUD>().SetHUD(move.GetComponent<Unit>().party, move.GetComponent<Unit>().myteam, move.GetComponent<Unit>().name, move.GetComponent<Unit>().Life, move.GetComponent<Unit>().Life, 100, 100);
        }

        // Sort the units by speed
        units.Sort((x, y) => y.GetComponent<Unit>().Speed.CompareTo(x.GetComponent<Unit>().Speed));

        // Start the first turn
        StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void StartTurn()
    {
        if (units.Count > 0)
        {
            TacticsMove unit = units[0];
            units.RemoveAt(0);

            unit.BeginTurn();
        }
        else
        {
            // All units have had their turn, so start again with the first unit
            units.Sort((x, y) => y.GetComponent<Unit>().Speed.CompareTo(x.GetComponent<Unit>().Speed));
            StartTurn();
        }
    }

    public static void EndTurn(TacticsMove unit, TurnManager turnManager)
    {
        unit.EndTurn();

        foreach (TacticsMove move in units)
        {
            Debug.Log(move);
        }
        // Add the unit back to the list and sort the list by speed
        units.Add(unit);
        units.Sort((x, y) => y.GetComponent<Unit>().Speed.CompareTo(x.GetComponent<Unit>().Speed));
        Debug.Log("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");

        foreach (TacticsMove move in units)
        {
            Debug.Log(move);
        }
        // Start the next turn
        //StartTurn();
        turnManager.StartCoroutine(turnManager.EsperarUnSegundo());
    }

    public static void RemoveUnit(TacticsMove unit)
    {
        units.Remove(unit);
        units.Sort((x, y) => y.GetComponent<Unit>().Speed.CompareTo(x.GetComponent<Unit>().Speed));
        StartTurn();
    }

    IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(1);
        //Aquí es donde colocas la acción que quieres realizar después de cinco segundos
        StartTurn();
    }
}
