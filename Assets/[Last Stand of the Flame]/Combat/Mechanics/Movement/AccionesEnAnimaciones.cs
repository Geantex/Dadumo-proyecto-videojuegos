using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesEnAnimaciones : MonoBehaviour
{
    public GameObject unit;
    public CombatSounds combatSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PasarTurno()
    {
        TurnManager.EndTurn(unit.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
    }
    
    /*public void SonidoAtaque()
    {
        combatSounds.ataque(gameObject.GetComponent<Unit>().Name);
    }*/
}
