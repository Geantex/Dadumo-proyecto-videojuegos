using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : FSMState
{
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void EnterState()
    {
        //SceneManager.LoadScene("MainMenu");
    }

    protected override void ExitState()
    {

    }
}
