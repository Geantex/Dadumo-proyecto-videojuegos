using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : FSMState
{
    protected override void EnterState()
    {
        (machine as GameController).replacePartyHealthAndManaPoints();
        (machine as GameController).modifyGoldCoins(100f);
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        string sceneName;
        // Obtén el nombre de la escena actual
        sceneName = SceneManager.GetActiveScene().name;
        
        yield return new WaitForSeconds(1.74f);
        FadeToBlack.QuickFade();
        yield return new WaitForSeconds(0.26f);
        if (sceneName == "TutorialCombate")
        {
            // Esto es si estas en el tutorial (te manda al menu principal)
            SceneManager.LoadScene("MainMenu");
            machine.SetStateByType(typeof(MainMenuState));
        }
        else
        {
            // Esto es si estas jugando de normal
            SceneManager.LoadScene("Map");
            machine.SetStateByType(typeof(MapState));
        }
        
        
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
