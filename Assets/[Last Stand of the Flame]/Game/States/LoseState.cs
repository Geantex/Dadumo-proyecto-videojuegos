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
        StartCoroutine(EndState());
    }

    IEnumerator EndState()
    {
        yield return new WaitForSeconds(1.74f);
        FadeToBlack.QuickFade();
        yield return new WaitForSeconds(0.26f);
        // AQUI MARIO - Tenemos que hacer que te resetee la run (porque has perdido y muerto y te manda al menu principal)
        // Esto es si estas en el tutorial (te manda al menu principal)
        SceneManager.LoadScene("MainMenu");
        machine.SetStateByType(typeof(MainMenuState));

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
