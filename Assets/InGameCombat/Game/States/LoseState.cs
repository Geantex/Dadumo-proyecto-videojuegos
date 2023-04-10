using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : FSMState
{
    protected override void EnterState()
    {
        Time.timeScale = 0f;
    }

    protected override void ExitState()
    {
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
