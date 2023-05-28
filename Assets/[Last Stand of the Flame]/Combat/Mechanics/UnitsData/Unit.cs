using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    // Estadísticas básicas de la unidad
    public string name = "";
    private int maxLife = 100;
    private int life = 100;
    private int mana;
    private int speed;
    private int initDamage;
    private int initRange;

    public int party;
    public bool myteam;

    public Image imagen;

    // Estadísticas de combate
    private int lifeInCombat = 100;
    private int manaInCombat;
    private int speedInCombats;

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

    }

    IEnumerator EsperarCincoSegundo()
    {
        yield return new WaitForSeconds(3);
        //Aquí es donde colocas la acción que quieres realizar después de cinco segundos
        gameObject.SetActive(false);

        //TurnManager.RemoveUnit(gameObject.GetComponent<TacticsMove>());

        DestroyImmediate(gameObject);
    }

    public void desaparecer()
    {
        Animaciones.morir(gameObject.GetComponentInChildren<Animator>(), gameObject.GetComponent<Unit>().Name);
        StartCoroutine(EsperarCincoSegundo());
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
