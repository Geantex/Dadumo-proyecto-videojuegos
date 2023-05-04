using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter1 : MonoBehaviour
{
    private GameObject encounterManager;


    public void functionButton1()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        // 0, 1, 2, 3
        if (Random.Range(0, 4) == 0)
        {
            // el dragon os quema por 40% de da�o
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que da�a a todo el grupo por un 40% de su salud)
            encounterManager.GetComponent<EncounterManager>().ShowResults("Mientras saque�is, una pila de tesoros particularmente ruidosos colapsa, �y el drag�n instintivamente lanza una llamarada!" +
                " Consegu�s escapar vivos y parcialmente chamuscados, sin nada de tesoro entre manos");
        }
        else
        {
            // robais 50 de oro
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins - 50f;
            encounterManager.GetComponent<EncounterManager>().ShowResults("El drag�n duerme profundamente, y ahora es 50 monedas de oro m�s pobre que antes. El drag�n empieza a despertarse un poco," +
                " as� que el grupo huye de la cueva antes de que tengan un drac�nido enemigo reclam�ndoles dinero");
        }
    }

    public void functionButton2()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        if (Random.Range(0, 2) == 0)
        {
            // el dragon os quema por 40% de da�o
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que da�a a todo el grupo por un 40% de su salud)
            encounterManager.GetComponent<EncounterManager>().ShowResults("El tesoro parece que ten�a un encantamiento de alarma, �porque empieza a hacer un poderoso pitido que despierta al drag�n, quien lanza una llamarada!" +
                " Hu�s con las ropas chamuscadas y heridos, jurando jam�s robar otra vez al drag�n (lo har�is otra vez seguro)");
        }
        else
        {
            // robais una pieza de equipamiento
            // Economia.anyadirOro(50); (esta funcion no existe) y el oro deberia ser poco
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins + 50f;
            encounterManager.GetComponent<EncounterManager>().ShowResults("El drag�n duerme profundamente, y os apropi�is un equipamiento con marcas de quemadura; su pen�ltimo propietario seguramente no lo echar� de menos. El drag�n empieza a despertarse un poco," +
                " as� que el grupo huye de la cueva antes de que tengan que probar su equipamiento contra su �ltimo propietario");
        }
    }

    public void functionButton3()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("La discreci�n es el mejor amigo de los aventureros, el cementario est� lleno de ladrones de dragones.");
    }

}
