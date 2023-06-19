using Map;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizerManager : MonoBehaviour
{
    private float rotate1 = 90f;
    private float rotate2 = 180f;
    private float rotate3 = -90f;

    private Vector3 Spawn1 = new Vector3(-1.502f, 0.283f, -8.126f);
    private Vector3 Spawn2 = new Vector3(0.321f, 0.283f, -6.681f);
    private Vector3 Spawn3 = new Vector3(2.08f, 0.283f, -8.227f);

    private GameObject prefab1;
    private GameObject prefab2;
    private GameObject prefab3;

    [SerializeField] private List<Button> rerollButtons;

    public bool rollUsed = false;



    // Start is called before the first frame update
    void Start()
    {
        spawnPlayersOnScene();
    }

    // Update is called once per frame
    void Update()
    {

        if (rollUsed == true)
        {
            foreach (Button b in rerollButtons)
            {
                b.interactable = false;
            }
        }
    }

    public void Reroll1()
    {
        Debug.Log("Rerol1");
        GameController.Instancia.GetComponent<Randomizer>().RerollFirst();

        deleteAllPlayersOnScene();
        spawnPlayersOnScene();

        rollUsed = true;
    }

    public void Reroll2()
    {
        Debug.Log("Rerol2");
        GameController.Instancia.GetComponent<Randomizer>().RerollSecond();

        deleteAllPlayersOnScene();
        spawnPlayersOnScene();

        rollUsed = true;
    }

    public void Reroll3()
    {
        Debug.Log("Rerol3");
        GameController.Instancia.GetComponent<Randomizer>().RerollThird();

        deleteAllPlayersOnScene();
        spawnPlayersOnScene();

        rollUsed = true;
    }

    public void exit()
    {
        GetComponent<Randomizer>().instantiateCharacters();
        GameController.Instancia.SetStateByType(typeof(MapState));
    }

    public void instantiateAndClean(GameObject Personaje, Vector3 Spawn, float rotate)
    {
        Debug.Log(Personaje);
        // Instanciar el objeto
        GameObject objeto = Instantiate(Personaje, Spawn, Quaternion.identity);

        // Obtener una referencia al script "PlayerMove"
        PlayerMove playerMoveScript = objeto.GetComponent<PlayerMove>();

        // Comprobar si se encontr� el script
        if (playerMoveScript != null)
        {
            // Quitar el script del objeto
            Destroy(playerMoveScript);
        }

        objeto.transform.Rotate(0f, rotate, 0f);
    }

    public void deleteAllPlayersOnScene()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Destroy(player);
        }
    }

    public void spawnPlayersOnScene()
    {
        prefab1 = GameController.Instancia.GetComponent<Randomizer>().prefabCharacter1;
        prefab2 = GameController.Instancia.GetComponent<Randomizer>().prefabCharacter2;
        prefab3 = GameController.Instancia.GetComponent<Randomizer>().prefabCharacter3;

        instantiateAndClean(prefab1, Spawn1, rotate1);
        Animaciones.sentado(prefab1.GetComponentInChildren<Animator>(), prefab1.GetComponent<Unit>().Name);

        instantiateAndClean(prefab2, Spawn2, rotate2);
        Animaciones.sentado(prefab2.GetComponentInChildren<Animator>(), prefab2.GetComponent<Unit>().Name);

        instantiateAndClean(prefab3, Spawn3, rotate3);
        Animaciones.sentado(prefab2.GetComponentInChildren<Animator>(), prefab2.GetComponent<Unit>().Name);

    }


}
