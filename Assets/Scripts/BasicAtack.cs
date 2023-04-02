using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtack : MonoBehaviour
{
    private int damage;
    private int range;
    // Start is called before the first frame update
    public BasicAtack(int damage, int range)
    {
        this.damage = damage;
        this.range = range;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Atack(GameObject enemy, GameObject allie)
    {
        float distance = Vector3.Distance(enemy.transform.position, allie.transform.position);
        if (distance <= range)
        {
            enemy.GetComponent<Unit>().Life = enemy.GetComponent<Unit>().Life - damage;
        }
        
        Debug.Log("La distancia entre los dos objetos es: " + distance);
    }
}
