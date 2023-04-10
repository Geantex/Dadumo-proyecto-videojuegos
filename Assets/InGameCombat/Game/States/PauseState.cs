using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : FSMState
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StateChanger();
        }
    }

    public void LoadMenu()
    {
       
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void StateChanger()
    {
        GameController.Instancia.SetStateByType(typeof(GameState));
    }

    protected override void EnterState()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    protected override void ExitState()
    {
        pauseMenuUI.SetActive(false);
        
    }
}