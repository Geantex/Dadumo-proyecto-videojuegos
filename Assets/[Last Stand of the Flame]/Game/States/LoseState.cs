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
        (machine as GameController).replacePartyHealthAndManaPoints();
        (machine as GameController).modifyGoldCoins(-50);
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        yield return new WaitForSeconds(1.74f);
        FadeToBlack.QuickFade();
        yield return new WaitForSeconds(0.26f);
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
