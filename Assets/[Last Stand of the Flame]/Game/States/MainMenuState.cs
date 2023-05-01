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
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void EnterState()
    {
        
    }

    protected override void ExitState()
    {

    }
}
