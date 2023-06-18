using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;
using UnityEngine.SceneManagement;

public class ToReRoll : MonoBehaviour
{
    private void OnEnable()
    {
        //Esto hace que cuando acabe la cinematica al estar linkeado a un objeto invisible al final
        // al activarlo suceda lo siguiente
        GameController.Instancia.SetStateByType(typeof(Randomizer));
    }
}
