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
            // el dragon os quema por 40% de daño
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que daña a todo el grupo por un 40% de su salud)
            encounterManager.GetComponent<EncounterManager>().ShowResults("Mientras saqueáis, una pila de tesoros particularmente ruidosos colapsa, ¡y el dragón instintivamente lanza una llamarada!" +
                " Conseguís escapar vivos y parcialmente chamuscados, sin nada de tesoro entre manos");
        }
        else
        {
            // robais 50 de oro
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins - 50f;
            encounterManager.GetComponent<EncounterManager>().ShowResults("El dragón duerme profundamente, y ahora es 50 monedas de oro más pobre que antes. El dragón empieza a despertarse un poco," +
                " así que el grupo huye de la cueva antes de que tengan un dracónido enemigo reclamándoles dinero");
        }
    }

    public void functionButton2()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        if (Random.Range(0, 2) == 0)
        {
            // el dragon os quema por 40% de daño
            // DamageAllPercentage(0.4); (esta funcion no existe, se supone que daña a todo el grupo por un 40% de su salud)
            encounterManager.GetComponent<EncounterManager>().ShowResults("El tesoro parece que tenía un encantamiento de alarma, ¡porque empieza a hacer un poderoso pitido que despierta al dragón, quien lanza una llamarada!" +
                " Huís con las ropas chamuscadas y heridos, jurando jamás robar otra vez al dragón (lo haréis otra vez seguro)");
        }
        else
        {
            // robais una pieza de equipamiento
            // Economia.anyadirOro(50); (esta funcion no existe) y el oro deberia ser poco
            GameController.Instancia.goldCoins = GameController.Instancia.goldCoins + 50f;
            encounterManager.GetComponent<EncounterManager>().ShowResults("El dragón duerme profundamente, y os apropiáis un equipamiento con marcas de quemadura; su penúltimo propietario seguramente no lo echará de menos. El dragón empieza a despertarse un poco," +
                " así que el grupo huye de la cueva antes de que tengan que probar su equipamiento contra su último propietario");
        }
    }

    public void functionButton3()
    {
        encounterManager = GameObject.FindGameObjectWithTag("EncounterManager").gameObject;
        encounterManager.GetComponent<EncounterManager>().ShowResults("La discreción es el mejor amigo de los aventureros, el cementario está lleno de ladrones de dragones.");
    }

}
