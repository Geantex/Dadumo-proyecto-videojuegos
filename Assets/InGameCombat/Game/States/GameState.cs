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
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameController.Instancia.SetStateByType(typeof(PauseState));
        }
    }
}