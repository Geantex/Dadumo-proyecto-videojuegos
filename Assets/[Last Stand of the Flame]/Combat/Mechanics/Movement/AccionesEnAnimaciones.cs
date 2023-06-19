using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SeguirCorriendo()
    {
        if (unit.GetComponent<PlayerMove>().moving)
        {
            Animaciones.correr(gameObject.GetComponent<Animator>(), unit.GetComponent<Unit>().Name);
        }
    }

    public void SeguirCorriendoEnemigo()
    {
        if (unit.GetComponent<NPCMove>().moving)
        {
            Animaciones.correr(gameObject.GetComponent<Animator>(), unit.GetComponent<Unit>().Name);
        }
    }

    public void MorirDestruccion()
    {
        if(SceneManager.GetActiveScene().name == "VictoriaScene")
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.enabled = false;
        }
        else
        {
            unit.SetActive(false);

            Destroy(unit);
            TurnManager.palMuerto = true;
        }
    }

    public void AcabarAnimacionCorrer()
    {
        if (!unit.GetComponent<PlayerMove>().moving)
        {
            //Animaciones.idle(gameObject.GetComponent<Animator>(), unit.GetComponent<Unit>().Name);
        }
    }

    public void AcabarAnimacionCorrerEnemigo()
    {
        if (!unit.GetComponent<NPCMove>().moving)
        {
            //Animaciones.idle(gameObject.GetComponent<Animator>(), unit.GetComponent<Unit>().Name);
        }
    }

    public void RecibirDano()
    {
        Animaciones.recibirDano(unit.GetComponent<PlayerMove>().UniqueTarget.GetComponentInChildren<Animator>(), unit.GetComponent<PlayerMove>().UniqueTarget.GetComponent<Unit>().Name, unit.GetComponent<PlayerMove>().UniqueTarget, FindObjectOfType<Animaciones>());
    }

    public void RecibirDanoArea()
    {
        foreach (GameObject target in unit.GetComponent<PlayerMove>().Targets)
        {
            Animaciones.recibirDano(unit.GetComponent<PlayerMove>().UniqueTarget.GetComponentInChildren<Animator>(), target.GetComponent<Unit>().Name, target, FindObjectOfType<Animaciones>());
        }
    }

    public void RecibirDanoEnemigo()
    {
        Animaciones.recibirDano(unit.GetComponent<NPCMove>().Target.GetComponentInChildren<Animator>(), unit.GetComponent<NPCMove>().Target.GetComponent<Unit>().Name, unit.GetComponent<NPCMove>().Target, FindObjectOfType<Animaciones>());
    }
}
