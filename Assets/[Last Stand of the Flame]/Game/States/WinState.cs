using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : FSMState
{
    protected override void EnterState()
    {

        (machine as GameController).modifyGoldCoins(100f);
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map");
        machine.SetStateByType(typeof(MapState));
        
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
