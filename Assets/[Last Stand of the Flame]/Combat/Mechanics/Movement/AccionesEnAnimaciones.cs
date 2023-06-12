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
    
    public void RecibirDano()
    {
        Animaciones.recibirDano(gameObject.GetComponent<Animator>(), unit.GetComponent<PlayerMove>().UniqueTarget.GetComponent<Unit>().Name, unit.GetComponent<PlayerMove>().UniqueTarget, FindObjectOfType<Animaciones>());
    }

    public void RecibirDanoArea()
    {
        foreach (GameObject target in unit.GetComponent<PlayerMove>().Targets)
        {
            Animaciones.recibirDano(gameObject.GetComponent<Animator>(), target.GetComponent<Unit>().Name, target, FindObjectOfType<Animaciones>());
        }
    }

    public void RecibirDanoEnemigo()
    {
        Animaciones.recibirDano(gameObject.GetComponent<Animator>(), unit.GetComponent<NPCMove>().Target.GetComponent<Unit>().Name, unit.GetComponent<NPCMove>().Target, FindObjectOfType<Animaciones>());
    }
}
