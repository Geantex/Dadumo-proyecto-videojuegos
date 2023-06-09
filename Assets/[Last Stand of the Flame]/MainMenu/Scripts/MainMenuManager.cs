using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void NewGameFade()
    {
        FadeToBlack.QuickFade();
        Invoke("NewGame",0.25f);
    }
    public void NewGame()
    {
        
        GameController.Instancia.NewGame = true;
        GameController.Instancia.SetStateByType(typeof(Randomizer));
    }
    public void StartGameFade()
    {
        FadeToBlack.QuickFade();
        Invoke("StartGame", 0.25f);
    }
    public void StartGame()
    {
        GameController.Instancia.SetStateByType(typeof(MapState));
        SceneManager.LoadScene("Map");
        //SceneManager.CreateScene("Map");
    }

    public void TutorialFade()
    {
        FadeToBlack.QuickFade();
        Invoke("Tutorial", 0.25f);
    }

    public void Tutorial()
    {
        GameController.Instancia.SetStateByType(typeof(GameState));
        SceneManager.LoadScene("TutorialCombate");
    }

    public void ExitGameFade()
    {
        FadeToBlack.QuickFade();
        Invoke("ExitGame", 0.28f);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }

}