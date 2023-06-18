using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TutorialConsejos : MonoBehaviour
{
    public TextMeshProUGUI textoConsejo;
    public Image panelConsejo;
    private int posicionConsejo = 1000; // este int marca adonde se tiene que mover el consejo creo xd hehe
    private bool hayConsejo = false; // esto es para saber si esta el consejo en pantalla o no
    public float tiempoConsejo = 0.5f;
    public int contadorConsejo = 0; // cuando llegue a 3, el siguiente consejo no saldr� (es decir, saldr�n solamente 3 consejos)
    public List<string> listaConsejos = new List<string>();
    public GameObject ataqueBasicoBoton;
    public GameObject ataqueEspecialBoton;



    private void Start()
    {
        ataqueBasicoBoton.SetActive(false);
        ataqueEspecialBoton.SetActive(false);

        // Consejo 1: Como moverte
        string textaco1 = "�Bienvenido, aventurero! Para superar este tutorial, has de enfrentarte a las ratas. " +
            "Muevete hacia ellas haciendo click en una casilla roja o con las teclas WASD, y despu�s, pasa tu turno haciendo click en \"Pasar Turno\" o pulsando la tecla \"c\"";
        listaConsejos.Add(textaco1);

        // Consejo 2: Como atacar + consejo de atacar a distancia con Galentin
        string textaco2 = "Cuando est�s al lado de una rata, haz click en \"Ataque b�sico\" o pulsa la tecla \"Z\". Se marcar�n los enemigos a los " +
            "que puedes atacar. Haz click o usa las flechas en un enemigo para marcarle y atacarle.  El mago azul, Galent�n, puede atacar a distancia";
        listaConsejos.Add(textaco2);

        // Consejo 3: Como usar ataques especiales
        string textaco3 = "Cada personaje tiene una habilidad especial. Haz click en \"Habilidad especial\" o pulsa la tecla \"X\" Algunos curan, como Jose Mar�a, el cl�rigo. Otros " +
            "pueden causar da�o de �rea; otros pueden hacer much�simo da�o. Mira el grimorio para m�s informaci�n";
        listaConsejos.Add(textaco3);

        // Consejo 3: Como usar ataques especiales
        string textaco4 = "Puedes controlar la c�mara haciendo click en los botones de los lados, o pulsando \"q\" � \"e\"";
        listaConsejos.Add(textaco4);

        DeslizarPanel(); // esto desliza el PRIMER consejo. el ultimo consejo hay que colocarlo en el script de ataque normal
    }
    public void DeslizarPanel()
    {
        if (contadorConsejo >= 4)
        {
            Debug.Log("No m�s consejos");
            CerrarConsejo();
            return;
        }
        if (hayConsejo)
        {
            hayConsejo = false;
            // hacia la derecha (esconder)
            LeanTween.moveX(panelConsejo.rectTransform, Screen.width, tiempoConsejo)
                .setOnComplete(() =>
                {
                    panelConsejo.gameObject.SetActive(false);
                    // aqui que hacer cuando ya se ha escondido el cacharro
                    DeslizarPanel();
                });
        }
        else
        {
            HabilitarHUDCombate();
            textoConsejo.text = listaConsejos.ElementAt(contadorConsejo);
            contadorConsejo++;
            // hacia la izquierda (mostrar)
            panelConsejo.gameObject.SetActive(true);
            LeanTween.moveX(panelConsejo.rectTransform, Screen.width*(-1)/4, tiempoConsejo)
                .setOnComplete(() =>
                {
                    hayConsejo = true;
                    // aqui que hacer cuando se ha mostrado el cacharro
                });
        }
        Debug.Log("Hay consejo? = " + hayConsejo);
        Debug.Log("Contador consejo = " + contadorConsejo);
    }

    // Esta funcion solamente cierra el consejo
    public void CerrarConsejo()
    {
        if (hayConsejo)
        {
            hayConsejo = false;
            // hacia la derecha (esconder)
            LeanTween.moveX(panelConsejo.rectTransform, Screen.width, tiempoConsejo)
                .setOnComplete(() =>
                {
                    panelConsejo.gameObject.SetActive(false);
                    // aqui que hacer cuando ya se ha escondido el cacharro
                });
        }
        
    }

    private void HabilitarHUDCombate()
    {
        switch (contadorConsejo)
        {
            case 1: // habilitamos el atacar
                ataqueBasicoBoton.SetActive(true);
                break;

            case 2: // habilitamos el ataque especial y desactivamos el basico
                ataqueBasicoBoton.SetActive(false);
                ataqueEspecialBoton.SetActive(true);
                break;
            case 3: // rehabilitamos todo
                ataqueBasicoBoton.SetActive(true);
                break;
        }
    }
}
