using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : FSMState
{
    public GameObject pauseMenuUI;
    private string stateName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StateChanger();
        }
    }

    public void LoadMenu()
    {
        GameController.Instancia.SetStateByType(typeof(MainMenuState));
        Debug.Log("Loading menu...");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void FSMStateChangeHandler(FSMState nuevo, FSMState anterior)
    {
        if (anterior is GameState) stateName = "GameState";
        else if (anterior is MapState) stateName = "MapState";
        Debug.Log(stateName);
    }


    public void StateChanger()
    {
        if (stateName == "MapState")
        {
            Debug.Log("Cambio a mapa");
            //SceneManager.UnloadSceneAsync("Map");
            GameController.Instancia.SetStateByType(typeof(MapState));
        }
        else if (stateName == "GameState")
        {
            GameController.Instancia.SetStateByType(typeof(GameState));
        }   
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