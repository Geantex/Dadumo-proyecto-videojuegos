using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;

public class GameController : FSMMachine
{
    static GameController _instancia;

    public static GameController Instancia
    {
        get
        {
            return _instancia;
        }
    }

    void Start()
    {
        if (_instancia == null)
        {
            _instancia = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Update()
    {

    }
}