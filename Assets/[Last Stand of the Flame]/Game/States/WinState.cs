using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : FSMState
{
    protected override void EnterState()
    {
        Time.timeScale = 0f;
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        yield return new WaitForSeconds(2f);
        machine.SetStateByType(typeof(MapState));
        SceneManager.UnloadSceneAsync("CombatScene");
        SceneManager.LoadScene("Map");
        
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
