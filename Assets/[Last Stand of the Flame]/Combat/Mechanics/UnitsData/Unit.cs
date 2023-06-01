using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dapasa.FSM;

public class Unit : MonoBehaviour
{
    // Estadísticas básicas de la unidad
    public string name;
    [SerializeField] private int maxLife;
    [SerializeField] private int life;
    [SerializeField] private int maxMana;
    [SerializeField] private int mana;
    [SerializeField] private int speed;
    private int initDamage;
    private int initRange;

    public int party;
    public bool myteam;

    public Image imagen;
    public GameObject circulo;

    // Estadísticas de combate
    private int lifeInCombat;
    private int manaInCombat;
    private int speedInCombats;

    private string stateEffect;

    public bool combatStart = false;
    // Start is called before the first frame update
    void Start()
    {
        circulo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EsperarCincoSegundo()
    {
        yield return new WaitForSeconds(2.8f);
        //Aquí es donde colocas la acción que quieres realizar después de cinco segundos
        gameObject.SetActive(false);
        string name = gameObject.GetComponent<Unit>().Name;
        foreach (CharacterCreator ch in GameController.Instancia.CharactersParty)
        {
            if (ch.CharacterName == gameObject.GetComponent<Unit>().Name)
            {
                GameController.Instancia.CharactersParty.Remove(ch);
            }
        }
        DestroyImmediate(gameObject);
    }

    public void desaparecer()
    {
        Animaciones.morir(gameObject.GetComponentInChildren<Animator>(), gameObject.GetComponent<Unit>().Name);
        StartCoroutine(EsperarCincoSegundo());
    }

    public int MaxLife
    {
        get { return maxLife; }
        set { maxLife = value; }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
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

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void setStats()
    {
        gameObject.GetComponent<PlayerAttack>().Damage = initDamage;
        gameObject.GetComponent<PlayerAttack>().Range = initRange;
        lifeInCombat = Life;
        manaInCombat = Mana;
        speedInCombats = Speed;
    }
}
