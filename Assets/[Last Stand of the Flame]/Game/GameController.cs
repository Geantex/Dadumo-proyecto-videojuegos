using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dapasa.FSM;
using Unity.VisualScripting;
using Map;

public class GameController : FSMMachine
{
    static GameController _instancia;

    [SerializeField] private float goldCoins = 0f;

    [SerializeField] private List<CharacterCreator> charactersParty;

    [SerializeField] private List<CharacterCreator> allPlayableCharacters;

    [SerializeField] private List<CharacterCreator> allPlayableEnemies;

    [SerializeField] public bool NewGame = false;

    

    public float GoldCoins
    {
        get
        {
            return goldCoins;
        }
        set
        {
            goldCoins = value;
            if (goldCoins < 0)
            {
                goldCoins = 0;
            }
        }
    }

    public List<CharacterCreator> CharactersParty
    {
        get
        {
            return charactersParty;
        }
        set
        {
            charactersParty = value;
        }
    }

    public List<CharacterCreator> AllPlayableCharacters
    {
        get
        {
            return allPlayableCharacters;
        }
    }

    public List<CharacterCreator> AllPlayableEnemies
    {
        get
        {
            return allPlayableEnemies;
        }
    }

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
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Update()
    {

    }

    public void modifyGoldCoins(float x)
    {
        GoldCoins += x;
    }

    public void modifyPartyHealthPoints(float HP)
    {
        foreach (CharacterCreator character in charactersParty)
        {
            character.HealthPoints += HP;
        }
    }

    public void GenerateMap()
    {
        MapPlayerTracker.Instance.GetComponent<MapManager>().GenerateNewMap();
    }
}