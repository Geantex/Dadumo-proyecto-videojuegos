using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PartSelector(string stringMenu)
    {
        SceneManager.LoadScene(stringMenu);
    }

    public void finishGame()
    {
        Application.Quit();
    }
}
