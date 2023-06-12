using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volver : MonoBehaviour
{
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FadeToBlack.QuickFade();
        Invoke("LoadMenuFade", 0.26f);

    }

    private void LoadMenuFade()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading menu...");
    }
}
