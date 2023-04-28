using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;
using UnityEngine.SceneManagement;

public class GameState : FSMState
{
    protected override void EnterState()
    {
        Time.timeScale = 1f;
    }

    protected override void ExitState()
    {

    }
    
    void Start()
    {

    }
   
    void Update()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Player");
        bool allAlliesDead = false;
        int numAlliesDead = 0;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        bool allEnemiesDead = false;
        int numEnemiesDead = 0;

        foreach (GameObject objeto in allies)
        {
            if (!objeto.activeSelf)
            {
                numAlliesDead++;
            }
        }

        foreach (GameObject objeto in enemies) 
        {
            if (!objeto.activeSelf)
            {
                numEnemiesDead++;
            } 
        }

        if (numAlliesDead == allies.Length)
        {
            allAlliesDead = true;
        }

        if (numEnemiesDead == enemies.Length)
        {
            allEnemiesDead = true;
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameController.Instancia.SetStateByType(typeof(PauseState));
        }
        else if (allAlliesDead)
        {
            GameController.Instancia.SetStateByType(typeof(LoseState));
        }
        else if (allEnemiesDead)
        {
            GameController.Instancia.SetStateByType(typeof(WinState));
        }
    }
}