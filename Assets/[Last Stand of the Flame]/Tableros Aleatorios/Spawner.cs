using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


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
    public float aliado1x = 0;
    public float aliado1z = 0;

    //Aliado 2
    public float aliado2x = 0;
    public float aliado2z = 0;

    //Aliado 3
    public float aliado3x = 0;
    public float aliado3z = 0;

    //Aliado 4
    public float aliado4x = 0;
    public float aliado4z = 0;

    //-------------------------------------------------------
    //---------------------ENEMIGOS--------------------------
    //-------------------------------------------------------

    public GameObject enemigoPrueba;

    public int numEnemigos = 0;

    //Enemigo 1
    public float enemigo1x = 0;
    public float enemigo1z = 0;

    //Enemigo 2
    public float enemigo2x = 0;
    public float enemigo2z = 0;

    //Enemigo 3
    public float enemigo3x = 0;
    public float enemigo3z = 0;

    //Enemigo 4
    public float enemigo4x = 0;
    public float enemigo4z = 0;

    //Enemigo 5
    public float enemigo5x = 0;
    public float enemigo5z = 0;

    //-------------------------------------------------------
    //---------------------OBSTACULOS------------------------
    //-------------------------------------------------------
    public GameObject obstaculoBase;
    public int numObstaculos = 0;

    //Enemigo 1
    public float obstaculo1x = 0;
    public float obstaculo1z = 0;

    //Enemigo 2
    public float obstaculo2x = 0;
    public float obstaculo2z = 0;

    private void Awake()
    {
        myPlayers = new List<GameObject>();
        myPartyPlayers = GameController.Instancia.CharactersParty;
        SetCharacters();
        numEnemigos = Random.Range(2, 5);
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
        switch (numAliados)
        {
            case 1:
                aliado1x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado1z = (float)((double)Random.Range(-3, -7) - 2.5);
                Instantiate(myPlayers[0].gameObject, new Vector3(aliado1x, 1.2f, aliado1z), Quaternion.identity);
                break;
            case 2:
                aliado1x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado1z = (float)((double)Random.Range(-3, -7) - 2.5);
                Instantiate(myPlayers[0].gameObject, new Vector3(aliado1x, 1.2f, aliado1z), Quaternion.identity);

                aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado2x == aliado1x && aliado2z == aliado1z)
                {
                    aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[1].gameObject, new Vector3(aliado2x, 1.2f, aliado2z), Quaternion.identity);

                break;
            case 3:
                aliado1x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado1z = (float)((double)Random.Range(-3, -7) - 2.5);
                Instantiate(myPlayers[0].gameObject, new Vector3(aliado1x, 1.2f, aliado1z), Quaternion.identity);

                aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado2x == aliado1x && aliado2z == aliado1z)
                {
                    aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[1].gameObject, new Vector3(aliado2x, 1.2f, aliado2z), Quaternion.identity);

                aliado3x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado3z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado3x == aliado1x && aliado3z == aliado1z || aliado3x == aliado2x && aliado3z == aliado2z)
                {
                    aliado3x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado3z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[2].gameObject, new Vector3(aliado3x, 1.2f, aliado3z), Quaternion.identity);

                break;
            case 4:
                aliado1x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado1z = (float)((double)Random.Range(-3, -7) - 2.5);
                Instantiate(myPlayers[0].gameObject, new Vector3(aliado1x, 1.2f, aliado1z), Quaternion.identity);

                aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado2x == aliado1x && aliado2z == aliado1z)
                {
                    aliado2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado2z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[1].gameObject, new Vector3(aliado2x, 1.2f, aliado2z), Quaternion.identity);

                aliado3x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado3z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado3x == aliado1x && aliado3z == aliado1z || aliado3x == aliado2x && aliado3z == aliado2z)
                {
                    aliado3x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado3z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[2].gameObject, new Vector3(aliado3x, 1.2f, aliado3z), Quaternion.identity);

                aliado4x = (float)((double)Random.Range(-4, 15) - 4.5);
                aliado4z = (float)((double)Random.Range(-3, -7) - 2.5);

                while (aliado4x == aliado1x && aliado4z == aliado1z || aliado4x == aliado2x && aliado4z == aliado2z || aliado4x == aliado3x && aliado4z == aliado3z)
                {
                    aliado4x = (float)((double)Random.Range(-4, 15) - 4.5);
                    aliado4z = (float)((double)Random.Range(-3, -7) - 2.5);
                }

                Instantiate(myPlayers[3].gameObject, new Vector3(aliado4x, 1.2f, aliado4z), Quaternion.identity);

                break;
        }

        //-------------------------------------------------------
        //---------------------ENEMIGOS--------------------------
        //-------------------------------------------------------
        switch (numEnemigos)
        {
            case 2:
                enemigo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo1z = (float)((double)Random.Range(8, 13) - 2.5);
                Instantiate(enemigoPrueba, new Vector3(enemigo1x, 1.2f, enemigo1z), Quaternion.identity);

                enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo2x == enemigo1x && enemigo2z == enemigo1z)
                {
                    enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo2x, 1.2f, enemigo2z), Quaternion.identity);

                break;
            case 3:
                enemigo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo1z = (float)((double)Random.Range(8, 13) - 2.5);
                Instantiate(enemigoPrueba, new Vector3(enemigo1x, 1.2f, enemigo1z), Quaternion.identity);

                enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo2x == enemigo1x && enemigo2z == enemigo1z)
                {
                    enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo2x, 1.2f, enemigo2z), Quaternion.identity);

                enemigo3x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo3z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo3x == enemigo1x && enemigo3z == enemigo1z || enemigo3x == enemigo2x && enemigo3z == enemigo2z)
                {
                    enemigo3x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo3z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo3x, 1.2f, enemigo3z), Quaternion.identity);

                break;
            case 4:
                enemigo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo1z = (float)((double)Random.Range(8, 13) - 2.5);
                Instantiate(enemigoPrueba, new Vector3(enemigo1x, 1.2f, enemigo1z), Quaternion.identity);

                enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo2x == enemigo1x && enemigo2z == enemigo1z)
                {
                    enemigo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo2z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo2x, 1.2f, enemigo2z), Quaternion.identity);

                enemigo3x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo3z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo3x == enemigo1x && enemigo3z == enemigo1z || enemigo3x == enemigo2x && enemigo3z == enemigo2z)
                {
                    enemigo3x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo3z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo3x, 1.2f, enemigo3z), Quaternion.identity);

                enemigo4x = (float)((double)Random.Range(-4, 15) - 4.5);
                enemigo4z = (float)((double)Random.Range(8, 13) - 2.5);

                while (enemigo4x == enemigo1x && enemigo4z == enemigo1z || enemigo4x == enemigo2x && enemigo4z == enemigo2z || enemigo4x == enemigo3x && enemigo4z == enemigo3z)
                {
                    enemigo4x = (float)((double)Random.Range(-4, 15) - 4.5);
                    enemigo4z = (float)((double)Random.Range(8, 13) - 2.5);
                }

                Instantiate(enemigoPrueba, new Vector3(enemigo4x, 1.2f, enemigo4z), Quaternion.identity);

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
                Instantiate(obstaculoBase, new Vector3(obstaculo1x, 1.2f, obstaculo1z), Quaternion.identity);

                break;

            case 2:
                obstaculo1x = (float)((double)Random.Range(-4, 15) - 4.5);
                obstaculo1z = (float)((double)Random.Range(5, 8) - 2.5);
                Instantiate(obstaculoBase, new Vector3(obstaculo1x, 1.2f, obstaculo1z), Quaternion.identity);

                obstaculo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                obstaculo2z = (float)((double)Random.Range(5, 8) - 2.5);

                while (obstaculo2x == obstaculo1x && obstaculo2z == obstaculo1z)
                {
                    obstaculo2x = (float)((double)Random.Range(-4, 15) - 4.5);
                    obstaculo2z = (float)((double)Random.Range(5, 8) - 2.5);
                }

                Instantiate(obstaculoBase, new Vector3(obstaculo2x, 1.2f, obstaculo2z), Quaternion.identity);

                break;
        }
    }

    public void SetCharacters()
    {
        foreach (CharacterCreator ch in myPartyPlayers)
        {
            GameObject gameObjectPlayer = ch.CharacterPrefab;

            //PlayerCharacterCLass player = new PlayerCharacterCLass();


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
            gameObjectPlayer.GetComponent<PlayerCharacterCLass>().UpdateValues();

            myPlayers.Add(gameObjectPlayer);
        }
    }
}