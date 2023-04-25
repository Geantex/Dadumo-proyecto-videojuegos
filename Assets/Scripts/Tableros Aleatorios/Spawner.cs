using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Spawner : MonoBehaviour
{
    public GameObject tablero1;
    public GameObject tablero2;
    public Transform coordSpawnerTablero;
    


   // Start is called before the first frame update
   void Start()
    {
        crear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void crear()
    {
        // de 1 a 2
        int random = Random.Range(1, 3);
        switch (random)
        {
            case 1:
                Instantiate(tablero1, coordSpawnerTablero);
                Debug.Log("He hecho aparecer el tablero1");
                break;
            case 2:
                Instantiate(tablero2, coordSpawnerTablero);
                Debug.Log("He hecho aparecer el tablero2");
                break;
        }
    }
}
