using Dapasa.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Text>();
    }

    public void FSMStateChangeHandler(FSMState nuevo, FSMState anterior)
    {
        if (nuevo is WinState) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
