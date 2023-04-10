using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : FSMState
{
    protected override void EnterState()
    {
        Time.timeScale = 0f; 
    }

    protected override void ExitState()
    {
Time.timeScale = 1f;
    }

    void Start()
    {

    }

    void Update()
    {

    }

}
