using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void NewGame()
    {
        GameController.Instancia.NewGame = true;
        GameController.Instancia.SetStateByType(typeof(Randomizer));
    }
    public void StartGame()
    {
        GameController.Instancia.SetStateByType(typeof(MapState));
        SceneManager.LoadScene("Map");
        //SceneManager.CreateScene("Map");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }

}