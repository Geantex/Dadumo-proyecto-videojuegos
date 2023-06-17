using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopState : FSMState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameController.Instancia.SetStateByType(typeof(PauseState));
        }
    }

    protected override void EnterState()
    {
        
    }
    protected override void ExitState()
    {
    }
}
