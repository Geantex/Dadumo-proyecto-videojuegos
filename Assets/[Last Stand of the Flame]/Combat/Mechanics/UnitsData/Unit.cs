using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    // Estadísticas básicas de la unidad
    public string name = "";
    private int life = 100;
    private int mana;
    private int speed;

    public int party;
    public bool myteam;

    public Image imagen;

    // Estadísticas de combate
    private string stateEffect;
    private string boostType;
    private double boost;

    public bool combatStart = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0 && combatStart)
        {
            if (gameObject.CompareTag("NPC"))
            {
                //GameController.Instancia.SetStateByType(typeof(WinState));
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("Player"))
            {
                //GameController.Instancia.SetStateByType(typeof(LoseState));
                gameObject.SetActive(false);
            }
            TurnManager.RemoveUnit(gameObject.GetComponent<TacticsMove>());
            DestroyImmediate(gameObject);
        }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string StateEffect
    {
        get { return stateEffect; }
        set { stateEffect = value; }
    }

    public string BoostType
    {
        get { return boostType; }
        set { boostType = value; }
    }

    public double Boost
    {
        get { return boost; }
        set { boost = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
