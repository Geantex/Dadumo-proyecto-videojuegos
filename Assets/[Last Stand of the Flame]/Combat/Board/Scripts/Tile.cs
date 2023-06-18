using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Variables para determinar el estado de la casilla
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    // Crea una lista que guarde las casillas adyacentes
    public List<Tile> adjacencyList = new List<Tile>();

    // Needed BFS (breadth first search)
    // Utilizamos las variables para determinar el camino más corto
    // Estas variables se utilizan de modo que va buscando las casillas y las va marcando como visitadas
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    // For A*
    // Algoritmo de busqueda para determinar el camino más corto
    // Las variables se utilizan para calcular el costo de movimiento
    public float f = 0; // f = g + h
    public float g = 0; // Coste desde el nodo inicial al nodo actual
    public float h = 0; // Coste desde el nodo final al nodo actual

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Cambia el color de la casilla dependiendo de su estado
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
            GetComponent<Renderer>().enabled = true;  // Enable it again to make it visible!
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
            GetComponent<Renderer>().enabled = true;  // Enable it again to make it visible!
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Renderer>().enabled = true;  // Enable it again to make it visible!

        }
        else
        {
            // Instead of turning white, I want it to become invisible
            Color invisibleColor = new Color(0, 0, 0, 0);  // Set the alpha channel to 0 (fully transparent)
            GetComponent<Renderer>().material.color = invisibleColor;
            GetComponent<Renderer>().enabled = false;  // Disable the renderer to make the object invisible
        }
    }

    public void Reset()
    {
        adjacencyList.Clear();

        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;

        f = g = h = 0;
    }

    // Función para determinar las casillas adyacentes
    // Recive: la casilla objetivo a la que se quiere llegar
    // Devuelve: nada
    public void FindNeighbors(Tile target)
    {
        Reset();

        CheckTile(Vector3.forward, target);
        CheckTile(-Vector3.forward, target);
        CheckTile(Vector3.right, target);
        CheckTile(-Vector3.right, target);
    }

    // Función para determinar si la casilla es adyacente
    // Recive: la dirección en la que se quiere buscar y la casilla objetivo
    // Devuelve: nada
    public void CheckTile(Vector3 direction, Tile target)
    {
        // Se crea un vector para determinar el tamaño de la casilla
        Vector3 halfExtents = new Vector3(0.25f, 1 / 2.0f, 0.25f);
        // Se crea un array de colliders para guardar los colliders que se encuentren en la casilla
        // La función Physics.OverlapBox() se utiliza para determinar los colliders que se encuentran en la dirección especificada
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            // Se crea una variable para guardar el componente Tile del collider y comprobar cada Tile que se encuentre
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;

                // Se comprueba si hay un collider en la casilla de arriba (básicamente comprobar si hay algo encima de la casilla) o si la casilla es la casilla objetivo
                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }
}