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
        Time.timeScale = 1f;
        FadeToBlack.QuickFade();
        Invoke("LoadMenuFade", 0.26f);
        
    }

    public void LoadMenuFade()
    {
        GameController.Instancia.SetStateByType(typeof(MainMenuState));
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        FadeToBlack.QuickFade();
        Invoke("QuitGameFade", 0.28f);        
    }

    public void QuitGameFade()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
    public void FSMStateChangeHandler(FSMState nuevo, FSMState anterior)
    {
        if (anterior is GameState) StateName = "GameState";
        else if (anterior is MapState) StateName = "MapState";
        //Debug.Log(stateName);
    }


    public void StateChanger()
    {
        if (StateName == "MapState")
        {
            Debug.Log("Cambio a mapa");
            //SceneManager.UnloadSceneAsync("Map");
            GameController.Instancia.SetStateByType(typeof(MapState));
        }
        else if (StateName == "GameState")
        {
            GameController.Instancia.SetStateByType(typeof(GameState));
        }   
    }

    protected override void EnterState()
    {
        string sceneName;
        // Obtén el nombre de la escena actual
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != "VictoriaScene")
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        

    }

    protected override void ExitState()
    {
        string sceneName;
        // Obtén el nombre de la escena actual
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName != "VictoriaScene")
        {
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;


    }
}