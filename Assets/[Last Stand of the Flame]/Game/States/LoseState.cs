using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : FSMState
{
    protected override void EnterState()
    {
        if (GameController.Instancia.goldCoins >= 50f)
        {
            (machine as GameController).goldCoins = GameController.Instancia.goldCoins - 50f;
        }
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync("CombatScene");
        SceneManager.LoadScene("Map");
        machine.SetStateByType(typeof(MapState));
        
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
