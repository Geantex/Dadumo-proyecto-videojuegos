using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public GameObject tablero1;
    public GameObject tablero2;
    public Transform coordSpawnerTablero;

    //-------------------------------------------------------
    //---------------------ALIADOS---------------------------
    //-------------------------------------------------------
    public List<CharacterCreator> myPartyPlayers;

    public List<GameObject> myPlayers;

    public GameObject aliadoPrueba;

    public int numAliados = 0;

    //Aliado 1
    Vector3 aliado1 = new Vector3(-2.5f, 1.2f, -6.5f);

    //Aliado 2
    Vector3 aliado2 = new Vector3(2.5f, 1.2f, -6.5f);

    //Aliado 3
    Vector3 aliado3 = new Vector3(-4.5f, 1.2f, -6.5f);

    //Aliado 4
    Vector3 aliado4 = new Vector3(4.5f, 1.2f, -6.5f);

    //-------------------------------------------------------
    //---------------------ENEMIGOS--------------------------
    //-------------------------------------------------------
    public List<CharacterCreator> allPlayableEnemies;
    public List<CharacterCreator> myPartyEnemies;

    public List<GameObject> myEnemies;

    public GameObject enemigoPrueba;

    public int numEnemigos = 0;

    //Enemigo 1
    Vector3 enemigo1 = new Vector3(-2.5f, 1.2f, 6.5f);

    //Enemigo 2
    Vector3 enemigo2 = new Vector3(2.5f, 1.2f, 6.5f);

    //Enemigo 3
    Vector3 enemigo3 = new Vector3(-4.5f, 1.2f, 6.5f);

    //Enemigo 4
    Vector3 enemigo4 = new Vector3(4.5f, 1.2f, 6.5f);

    //-------------------------------------------------------
    //---------------------OBSTACULOS------------------------
    //-------------------------------------------------------
    public GameObject obstaculoBase;
    public int numObstaculos = 0;

    //Obstaculo 1
    public float obstaculo1x = 0;
    public float obstaculo1z = 0;

    //Obstaculo 2
    public float obstaculo2x = 0;
    public float obstaculo2z = 0;

    string sceneName;

    private void Awake()
    {
        // Obtén el nombre de la escena actual
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("El nombre de la escena actual es: " + sceneName);

        allPlayableEnemies = GameController.Instancia.AllPlayableEnemies;
        myEnemies = new List<GameObject>();
        myPartyEnemies = new List<CharacterCreator>();
        AlgoritmoEnemigos();

        myPlayers = new List<GameObject>();
        myPartyPlayers = GameController.Instancia.CharactersParty;
        SetCharacters();
        SetEnemies();
        numObstaculos = Random.Range(1, 3);
        numAliados = myPartyPlayers.Count;
        creacionGeneral();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void creacionGeneral()
    {
        //-------------------------------------------------------
        //---------------------ALIADOS---------------------------
        //-------------------------------------------------------
        GameObject unitObject;
        switch (numAliados)
        {
            case 1:
                unitObject = myPlayers[0].gameObject;
                unitObject.GetComponent<Unit>().party = 1;
                unitObject.GetComponent<Unit>().myteam = true;

                Instantiate(unitObject, aliado1, Quaternion.identity);
                break;
            case 2:
                unitObject = myPlayers[0].gameObject;
                unitObject.GetComponent<Unit>().party = 1;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado1, Quaternion.identity);

                unitObject = myPlayers[1].gameObject;
                unitObject.GetComponent<Unit>().party = 2;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado2, Quaternion.identity);

                break;
            case 3:
                unitObject = myPlayers[0].gameObject;
                unitObject.GetComponent<Unit>().party = 1;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado1, Quaternion.identity);

                unitObject = myPlayers[1].gameObject;
                unitObject.GetComponent<Unit>().party = 2;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado2, Quaternion.identity);

                unitObject = myPlayers[2].gameObject;
                unitObject.GetComponent<Unit>().party = 3;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado3, Quaternion.identity);

                break;
            case 4:
                unitObject = myPlayers[0].gameObject;
                unitObject.GetComponent<Unit>().party = 1;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado1, Quaternion.identity);

                unitObject = myPlayers[1].gameObject;
                unitObject.GetComponent<Unit>().party = 2;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado2, Quaternion.identity);

                unitObject = myPlayers[2].gameObject;
                unitObject.GetComponent<Unit>().party = 3;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado3, Quaternion.identity);

                unitObject = myPlayers[3].gameObject;
                unitObject.GetComponent<Unit>().party = 4;
                unitObject.GetComponent<Unit>().myteam = true;
                Instantiate(unitObject, aliado4, Quaternion.identity);

                break;
        }

        //-------------------------------------------------------
        //---------------------ENEMIGOS--------------------------
        //-------------------------------------------------------
        GameObject enemyUnitObject;
        switch (numEnemigos)
        {
            case 1:
                enemyUnitObject = myEnemies[0].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 1;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo1, Quaternion.identity);

                break;
            case 2:
                enemyUnitObject = myEnemies[0].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 1;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo1, Quaternion.identity);

                enemyUnitObject = myEnemies[1].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 2;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo2, Quaternion.identity);

                break;
            case 3:
                enemyUnitObject = myEnemies[0].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 1;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo1, Quaternion.identity);

                enemyUnitObject = myEnemies[1].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 2;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo2, Quaternion.identity);

                enemyUnitObject = myEnemies[2].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 3;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo3, Quaternion.identity);

                break;
            case 4:
                enemyUnitObject = myEnemies[0].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 1;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo1, Quaternion.identity);

                enemyUnitObject = myEnemies[1].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 2;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo2, Quaternion.identity);

                enemyUnitObject = myEnemies[2].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 3;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo3, Quaternion.identity);

                enemyUnitObject = myEnemies[3].gameObject;
                enemyUnitObject.GetComponent<Unit>().party = 4;
                enemyUnitObject.GetComponent<Unit>().myteam = false;
                Instantiate(enemyUnitObject, enemigo4, Quaternion.identity);

                break;
        }

        //-------------------------------------------------------
        //---------------------OBSTACULOS------------------------
        //-------------------------------------------------------
        switch (numObstaculos)
        {
            case 1:
                obstaculo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                obstaculo1z = (float)((double)Random.Range(5, 8) - 2.5);
                Instantiate(obstaculoBase, new Vector3(obstaculo1x, 0.5f, obstaculo1z), Quaternion.identity);

                break;

            case 2:
                obstaculo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                obstaculo1z = (float)((double)Random.Range(5, 8) - 2.5);
                Instantiate(obstaculoBase, new Vector3(obstaculo1x, 0.5f, obstaculo1z), Quaternion.identity);

                obstaculo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                obstaculo2z = (float)((double)Random.Range(5, 8) - 2.5);

                while (obstaculo2x == obstaculo1x && obstaculo2z == obstaculo1z)
                {
                    obstaculo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    obstaculo2z = (float)((double)Random.Range(5, 8) - 2.5);
                }

                Instantiate(obstaculoBase, new Vector3(obstaculo2x, 0.5f, obstaculo2z), Quaternion.identity);

                break;
        }
    }

    public void SetCharacters()
    {
        foreach (CharacterCreator ch in myPartyPlayers)
        {
            /*GameObject gameObjectPlayer = ch.CharacterPrefab;

            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().CharacterName = ch.CharacterName;
            Debug.Log(gameObjectPlayer.GetComponent<PlayerCharacterCLass>().CharacterName);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().CharacterClassName = ch.CharacterClass;
            Debug.Log(ch.CharacterClass);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().CharacterImage = ch.CharacterImage;
            Debug.Log(ch.CharacterImage);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().CharacterMaterial = ch.CharacterMaterial;
            Debug.Log(ch.CharacterMaterial);
            //player.CharacterPrefab = ch.CharacterPrefab;
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().HealthPoints = ch.HealthPoints;
            Debug.Log(ch.HealthPoints);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().MaxHealthPoints = ch.MaxHealthPoints;
            Debug.Log(ch.MaxHealthPoints);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().ManaPoints = ch.ManaPoints;
            Debug.Log(ch.ManaPoints);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().DamagePoints = ch.DamagePoints;
            Debug.Log(ch.DamagePoints);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().RangeTiles = ch.RangeTiles;
            Debug.Log(ch.RangeTiles);
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().SpecialAttacks = ch.SpecialAttacks;
            Debug.Log(ch.SpecialAttacks);
            //player.CharacterWeapon = ch.CharacterWeapon;
            //player.CharacterArmor = ch.CharacterArmor;

            //gameObjectPlayer.GetComponent<PlayerCharacterCLass>() = player
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().UpdateValues();*/
            ch.SetUpCharacters();
            myPlayers.Add(ch.CharacterPrefab);
        }
    }

    public void SetEnemies()
    {
        foreach (CharacterCreator ch in myPartyEnemies)
        {
            /*GameObject gameObjectEnemy = ch.CharacterPrefab;

            gameObjectEnemy.GetComponent<EnemyCharacterClass>().CharacterName = ch.CharacterName;
            Debug.Log(gameObjectEnemy.GetComponent<EnemyCharacterClass>().CharacterName);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().CharacterClassName = ch.CharacterClass;
            Debug.Log(ch.CharacterClass);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().CharacterImage = ch.CharacterImage;
            Debug.Log(ch.CharacterImage);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().CharacterMaterial = ch.CharacterMaterial;
            Debug.Log(ch.CharacterMaterial);
            //player.CharacterPrefab = ch.CharacterPrefab;
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().HealthPoints = ch.HealthPoints;
            Debug.Log(ch.HealthPoints);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().MaxHealthPoints = ch.MaxHealthPoints;
            Debug.Log(ch.MaxHealthPoints);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().ManaPoints = ch.ManaPoints;
            Debug.Log(ch.ManaPoints);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().DamagePoints = ch.DamagePoints;
            Debug.Log(ch.DamagePoints);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().RangeTiles = ch.RangeTiles;
            Debug.Log(ch.RangeTiles);
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().SpecialAttacks = ch.SpecialAttacks;
            Debug.Log(ch.SpecialAttacks);
            //player.CharacterWeapon = ch.CharacterWeapon;
            //player.CharacterArmor = ch.CharacterArmor;

            //gameObjectPlayer.GetComponent<PlayerCharacterCLass>() = player
            gameObjectEnemy.GetComponent<EnemyCharacterClass>().UpdateValues();*/
            ch.SetUpEnemies();
            myEnemies.Add(ch.CharacterPrefab);
        }
    }

    public void AlgoritmoEnemigos()
    {
        switch (sceneName)
        {
            case "BosqueCombate":
                numEnemigos = Random.Range(2, 5);
                for (int i = 0; i < numEnemigos; i++)
                {
                    myPartyEnemies.Add(allPlayableEnemies.Find(character => character.CharacterClass == "rata rapida"));
                }
                break;
            case "PuebloCombate":
                int numEnemigosBrujo = Random.Range(1, 3);
                for (int i = 0; i < numEnemigosBrujo; i++)
                {
                    myPartyEnemies.Add(allPlayableEnemies.Find(character => character.CharacterClass == "brujo"));
                }

                int numEnemigosLadron = Random.Range(1, 3);
                for (int i = 0; i < numEnemigosLadron; i++)
                {
                    myPartyEnemies.Add(allPlayableEnemies.Find(character => character.CharacterClass == "ladron"));
                }

                numEnemigos = numEnemigosBrujo + numEnemigosLadron;
                break;
            case "MontanaCombate":
                numEnemigos = Random.Range(2, 5);
                for (int i = 0; i < numEnemigos; i++)
                {
                    myPartyEnemies.Add(allPlayableEnemies.Find(character => character.CharacterClass == "troll"));
                }
                break;
            case "VolcanCombate":
                numEnemigos = 1;
                myPartyEnemies.Add(allPlayableEnemies.Find(character => character.CharacterClass == "boss"));
                break;
        }
    }
}