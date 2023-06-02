using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;
using UnityEngine.UI;

public class GoldCoinsGeneral : MonoBehaviour
{
    [SerializeField] public Text GeneralCoins;

    // Start is called before the first frame update
    void Start()
    {
        GeneralCoins.text = (GameController.Instancia.GoldCoins).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GeneralCoins.text = (GameController.Instancia.GoldCoins).ToString();
    }
}
