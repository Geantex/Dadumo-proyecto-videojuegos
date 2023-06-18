using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;
using UnityEngine.UI;

public class LoseText : MonoBehaviour
{
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        //display = GetComponent<Text>();
    }

    public void FSMStateChangeHandler(FSMState nuevo, FSMState anterior)
    {
        //if (nuevo is LoseState) gameObject.SetActive(true);
        //else gameObject.SetActive(false);
    }
}
