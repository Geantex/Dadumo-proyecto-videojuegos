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

    public void StartGame()
    {
        SceneManager.LoadScene("CombatScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }
}