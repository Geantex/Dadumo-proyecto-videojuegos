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
        
    }

    protected override void EnterState()
    {
        SceneManager.LoadScene("Shop");
    }
    protected override void ExitState()
    {
    }
}
