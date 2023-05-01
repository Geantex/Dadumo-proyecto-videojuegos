using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class Encounter : ScriptableObject
{
    // Estas propiedades serán las que, cuando carguemos un evento al azar, rellenen el canvas de eventos
    // Necesita un nombre y una descripción, obviamente
    // eventOptions será para las opciones que tienes para solucionar el evento (máximo 4 por evento)
    // eventImage será para mostrar una imagen acorde al evento
    // he cambiado el nombre de evento a encuentro
    public string encounterName;
    public string encounterDescription;
    public Sprite encounterImage;
    public string encounterButton1Text;
    public string encounterButton2Text;
    public string encounterButton3Text;
    public string encounterButton4Text;

    // Cojo un GameObject vacío que no esta en escena (un prefab...) y este GameObject tiene scripts!!! es una gran idea!
    public GameObject buttonScripts;

    // cada nuevo Encuentro será un nuevo script que heredará de este script

    // Cuando el Encuentro cargue, tiene que llamar a una función que aplique el texto, la descripción y la imagen
    // a los elementos del panel correspondientes



    public void FillEncounterCanvas()
    {
        // El panel que contiene todo
        GameObject panelEncounter = GameObject.FindGameObjectWithTag("EncounterCanvas").gameObject.transform.Find("Panel").gameObject;

        // texto, descripcion e imagen
        GameObject imageSlot = panelEncounter.transform.Find("EncounterImage").gameObject;
        GameObject nameSlot = panelEncounter.transform.Find("EncounterTitle").gameObject;
        GameObject descriptionSlot = panelEncounter.transform.Find("EncounterDescription").gameObject;

        // botones
        GameObject button1 = panelEncounter.transform.Find("EncounterButton1").gameObject;
        GameObject button2 = panelEncounter.transform.Find("EncounterButton2").gameObject;
        GameObject button3 = panelEncounter.transform.Find("EncounterButton3").gameObject;
        GameObject button4 = panelEncounter.transform.Find("EncounterButton4").gameObject;
        GameObject button1TextSlot = button1.transform.Find("EncounterButton1Text").gameObject;
        GameObject button2TextSlot = button2.transform.Find("EncounterButton2Text").gameObject;
        GameObject button3TextSlot = button3.transform.Find("EncounterButton3Text").gameObject;
        GameObject button4TextSlot = button4.transform.Find("EncounterButton4Text").gameObject;
        

        nameSlot.GetComponent<Text>().text = encounterName;
        descriptionSlot.GetComponent<Text>().text = encounterDescription;
        imageSlot.GetComponent<Image>().sprite = encounterImage;

        // Puede que no hayan 4 opciones en todos los encuentros, así que vamos a hacer ifs para ver si hay texto que agregar al boton
        //myScriptReference = go.GetComponent<MyScript>();
        Debug.Log("Es hora de asignar!");
        if (encounterButton1Text != null || encounterButton1Text != "")
        {
            button1TextSlot.GetComponent<Text>().text = encounterButton1Text;
            try
            {
                // veamos si funciona????
                button1.GetComponent<Button>().onClick.AddListener(() => buttonScripts.GetComponent<MonoBehaviour>().GetType().GetMethod("functionButton1").Invoke(buttonScripts.GetComponent<MonoBehaviour>(), null));
            }
            catch
            {
                Debug.LogError("Button 1 no tiene función asignada!");
            }
        }
        else
        {
            button1.SetActive(false);
        }
        
        if (encounterButton2Text != null || encounterButton2Text != "")
        {
            button2TextSlot.GetComponent<Text>().text = encounterButton2Text;
            try
            {
                // poner funcion aqui
            }
            catch
            {
                Debug.LogError("Button 2 no tiene función asignada!");
            }
        }
        else
        {
            button2.SetActive(false);
        }

        if (encounterButton3Text != null || encounterButton3Text != "")
        {
            button3TextSlot.GetComponent<Text>().text = encounterButton3Text;
        }
        else
        {
            button3.SetActive(false);
        }

        if (encounterButton4Text != null || encounterButton4Text != "")
        {
            button4TextSlot.GetComponent<Text>().text = encounterButton4Text;
        }
        else
        {
            button4.SetActive(false);
        }



    }
}
