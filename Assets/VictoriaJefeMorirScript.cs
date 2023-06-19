using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoriaJefeMorirScript : MonoBehaviour
{
    public Text victoriaTexto;
    private float opacity = 0f;
    private float fadeSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayDeathAnimationJefeFinal", 0.25f);
        Invoke("MostrarVictoriaTexto", 1.2f);
        StartCoroutine(VolverAlMenu());
    }

    private void PlayDeathAnimationJefeFinal()
    {
        // tambien quiero que se reproduzca más despacio la animación
        Animator jefeFinalAnimator = GetComponentInChildren<Animator>();
        jefeFinalAnimator.Play("Boss morir");
    }

    public void MostrarVictoriaTexto()
    {
        StartCoroutine(MostrarTextoGradualmente());
    }

    private IEnumerator MostrarTextoGradualmente()
    {
        while (opacity < 1f)
        {
            opacity += fadeSpeed * Time.deltaTime;
            Color textColor = victoriaTexto.color;
            textColor.a = opacity;
            victoriaTexto.color = textColor;
            yield return null;
        }
    }

    IEnumerator VolverAlMenu()
    {
        yield return new WaitForSeconds(5f);
        FadeToBlack.QuickFade();
        yield return new WaitForSeconds(0.26f);
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("StartButton").GetComponent<Button>().interactable = false;
    }
}
