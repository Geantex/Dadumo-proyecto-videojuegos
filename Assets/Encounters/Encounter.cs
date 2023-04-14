using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Encounter : MonoBehaviour
{
    // tienes el movil en la mochila

    // Estas propiedades serán las que, cuando carguemos un evento al azar, rellenen el canvas de eventos
    // Necesita un nombre y una descripción, obviamente
    // eventOptions será para las opciones que tienes para solucionar el evento (máximo 4 por evento)
    // eventImage será para mostrar una imagen acorde al evento
    // he cambiado el nombre de evento a encuentro
    public string encounterName;
    public string encounterDescription;
    // public List<EncounterOption> encounterOptions;
    public Material encounterImage;

    public string encounterButton1Text = null;
    public string encounterButton2Text = null;
    public string encounterButton3Text = null;
    public string encounterButton4Text = null;

    // cada nuevo Encuentro será un nuevo script que heredará de este script

    // Cuando el Encuentro cargue, tiene que llamar a una función que aplique el texto, la descripción y la imagen
    // a los elementos del panel correspondientes



    public void FillEncounterCanvas()
    {
        GameObject imageSlot = GameObject.Find("EncounterImage");
        GameObject nameSlot = GameObject.Find("EncounterTitle");
        GameObject descriptionSlot = GameObject.Find("EncounterDescription");
        GameObject button1TextSlot = GameObject.Find("EncounterButton1Text");
        GameObject button2TextSlot = GameObject.Find("EncounterButton2Text");
        GameObject button3TextSlot = GameObject.Find("EncounterButton3Text");
        GameObject button4TextSlot = GameObject.Find("EncounterButton4Text");
        GameObject button1 = GameObject.Find("EncounterButton1");
        GameObject button2 = GameObject.Find("EncounterButton2");
        GameObject button3 = GameObject.Find("EncounterButton3");
        GameObject button4 = GameObject.Find("EncounterButton4");

        nameSlot.GetComponent<Text>().text = encounterName;
        descriptionSlot.GetComponent<Text>().text = encounterDescription;
        imageSlot.GetComponent<Image>().material = encounterImage;

        // Puede que no hayan 4 opciones en todos los encuentros, así que vamos a hacer ifs para ver si hay texto que agregar al boton

        if (encounterButton1Text != null)
        {
            button1TextSlot.GetComponent<Text>().text = encounterButton1Text;
        }
        else
        {
            button1.SetActive(false);
        }
        // TODO: Hacer que si no hay texto en un boton, que desaparezca (esto para los 4 botones)
        // HECHO!!!1! <3 mmm Gabi haces muy buen código!!! Gracias Gabi!!!
        // Hola soy yo Mario, me gusta mucho tu codigo Gabi, el mio lo voy a hacer LA NOCHE ANTERIOR GILIPOLLAS!!!!!!

        if (encounterButton2Text != null)
        {
            button2TextSlot.GetComponent<Text>().text = encounterButton2Text;
        }
        else
        {
            button2.SetActive(false);
        }

        if (encounterButton3Text != null)
        {
            button3TextSlot.GetComponent<Text>().text = encounterButton3Text;
        }
        else
        {
            button3.SetActive(false);
        }

        if (encounterButton4Text != null)
        {
            button4TextSlot.GetComponent<Text>().text = encounterButton4Text;
        }
        else
        {
            button4.SetActive(false);
        }



    }
}
