using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    // Usamos una variable para determinar si es nuestro turno o no
    public bool turn = false;
    public bool calculateZone = false;
    /*public bool HUDturn = false;
    public int numTurn = 0;*/

    // Creamos una lista para guardar las casillas seleccionables
    List<Tile> selectableTiles = new List<Tile>();
    // Creamos una variable para guardar las casillas que se pueden alcanzar
    GameObject[] tiles;
    // La principal diferencia es que la primera lista es para guardar los scripts de las casillas y la segunda es para guardar los objetos de las casillas

    // Creamos una pila para guardar el camino que se va a seguir
    public Stack<Tile> path = new Stack<Tile>();
    // Creamos una variable para guardar la casilla actual
    Tile currentTile;

    // Variables para el movimiento
    public bool moving = false;
    public int move = 5;
    public float moveSpeed = 2;

    // Variables para la rotación
    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    // Casilla donde esta el objetivo (seleccionado) actual
    public Tile actualTargetTile;

    protected void Init()
    {
        // Busca todas las casillas del tablero
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        // Calcula la mitad de la altura del objeto
        halfHeight = GetComponent<Collider>().bounds.extents.y;

        // Añade la unidad a la lista de unidades
        //TurnManager.AddUnit(this);
    }

    // Buscamos la casilla actual
    // Recive: Nada
    // Devuelve: Nada
    public void GetCurrentTile()
    {
        // Busca la casilla actual llamando a la función GetTargetTile
        currentTile = GetTargetTile(gameObject);
        // Cuando la encontramos marcamos la casilla como actual dentro de su propio script
        currentTile.current = true;
    }

    // Función que busca la casilla en la que esta el objetivo (probablemente busca la casilla en la que esta el personaje que tenga el script)
    // Recive: Un objeto de un personaje
    // Devuelve: Una casilla
    public Tile GetTargetTile(GameObject target)
    {
        // Creamos un raycast para buscar la casilla
        RaycastHit hit;
        // Creamos una variable para guardar la casilla
        Tile tile = null;
        // Si el rayo encuentra un objeto sacamos el componente Tile de el, dicho de otra manera, obtenemos los datos de la casilla y los guardamos
        // Nota: El rayo se lanza desde la posición del objetivo en dirección hacia abajo
        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    // Función que busca las casillas que se pueden alcanzar (adjacentes) a la casilla actual 
    // Recive: La casilla sobre la cual queremos ver las casillas alcanzables (adjacentes) (si es null se buscan todas las casillas)
    // Devuelve: Nada
    public void ComputeAdjacencyLists(Tile target)
    {
        //tiles = GameObject.FindGameObjectsWithTag("Tile");

        // Recorremos todas las casillas del tablero y comprobamos cuales estan cerca de la casilla actual
        foreach (GameObject tile in tiles)
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(target);
        }
    }

    // Función que busca las casillas que se pueden seleccionar
    // Recive: Nada
    // Devuelve: Nada
    public void FindSelectableTiles()
    {
        // Llamamos a la función ComputeAdjacencyLists para buscar las casillas alcanzables del tablero
        ComputeAdjacencyLists(null);
        // Buscamos la casilla actual
        GetCurrentTile();

        // Creamos una cola para guardar las casillas que se van a procesar
        Queue<Tile> process = new Queue<Tile>();

        // Añadimos la casilla actual a la cola
        process.Enqueue(currentTile);
        // Marcamos la casilla actual como visitada
        currentTile.visited = true;
        //currentTile.parent = ??  leave as null 

        // Mientras la cola tenga casillas por procesar seguimos buscando casillas
        while (process.Count > 0)
        {
            // Sacamos la primera casilla de la cola y la guardamos en una variable
            Tile t = process.Dequeue();

            // Añadimos la casilla a la lista de casillas seleccionables
            selectableTiles.Add(t);
            // Marcamos la casilla como seleccionable
            t.selectable = true;

            // Si la distancia de la casilla es menor que el movimiento de la unidad
            if (t.distance < move)
            {
                // Recorremos todas las casillas adyacentes a la casilla actual
                foreach (Tile tile in t.adjacencyList)
                {
                    // Y en el caso de que no hayan sido visitadas
                    if (!tile.visited)
                    {
                        tile.parent = t; // Guardamos la casilla actual como padre de la casilla adyacente
                        tile.visited = true; // Marcamos la casilla como visitada (Visitada en este caso significa que ya se ha procesado, no que sea la casilla en la que estamos, ya que recordemos que es una de las variables de la busqueda BFS)
                        tile.distance = 1 + t.distance; // Vamos aumentando la distancia de la casilla adyacente para así saber la distancia que hay desde la casilla actual hasta la casilla adyacente, y que cuando llegue a la máxima no continue el proceso
                        process.Enqueue(tile); // Añadimos la casilla a la cola para que se procese
                    }
                }
            }
        }
    }

    // Función que habilita el movimiento de la unidad
    // Recive: La casilla a la cual nos queremos mover
    // Devuelve: Nada
    public void MoveToTile(Tile tile)
    {
        // Limpiamos el camino
        path.Clear();
        // Marcamos la casilla a la cual queremos ir como objetivo
        tile.target = true;
        // Activamos el movimiento de la unidad
        moving = true;

        // Guardamos la casilla a la cual queremos ir
        Tile next = tile;
        // Mientras la casilla tenga padre (es decir, mientras no sea la casilla actual)
        while (next != null)
        {
            // Añadimos la casilla al camino
            path.Push(next);
            // Y establecemos la casilla a analizar como la casilla padre de la actual que analizamos
            next = next.parent;
        }
    }

    // Función que realiza el movimiento
    // Recive: Nada
    // Devuelve: Nada
    public void Move()
    {
        // Si existe un camino
        if (path != null)
        {
            if (path.Count > 0)
            {
                // Obtenemos la casilla más cercana a la que nos queremos mover
                Tile t = path.Peek();
                // Y guardamos la posición en un vector
                Vector3 target = t.transform.position;

                //Calculate the unit's position on top of the target tile
                // Calcula la posición para que el personaje se mueva encima de la casilla
                target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

                // Si la distancia entre la posición del personaje y la posición de la casilla es mayor que 0.05
                if (Vector3.Distance(transform.position, target) >= 0.05f)
                {
                    // Calculamos la dirección entre la casilla en la que estamos y a la que nos queremos mover
                    CalculateHeading(target);
                    // Calculamos la velocidad a la que nos queremos mover
                    SetHorizotalVelocity();
                    //Locomotion
                    // Se establece la rotación (dirección en la que mira) del personaje y se mueve
                    transform.forward = heading;
                    // Se mueve el personaje en función de la velocidad y el tiempo
                    // Establece el movimiento que se debe aplicar en cada fotograma
                    transform.position += velocity * Time.deltaTime;
                }
                else
                {
                    //Tile center reached
                    // Si la distancia entre la posición del personaje y la posición de la casilla es menor que 0.05
                    // Centramos al personaje en la casilla
                    transform.position = target;
                    // Quitamos la casilla del camino
                    path.Pop();
                }
            }
            else
            {
                //RemoveSelectableTiles();
                //Cuando acabamos de recorrer el camino paramos el movimiento
                moving = false;

                // Si el personaje es un NPC, terminamos su turno
                if (gameObject.tag == "NPC")
                {
                    TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
                }

            }
        }
        else
        {
            // Borra las casillas seleccionables
            RemoveSelectableTiles();
            //Cuando acabamos de recorrer el camino paramos el movimiento
            moving = false;

            // Si el personaje es un NPC, terminamos su turno
            if (gameObject.tag == "NPC")
            {
                TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>());
            }
        }

    }

    // Función que borra las casillas seleccionables
    // Recive: Nada
    // Devuelve: Nada
    protected void RemoveSelectableTiles()
    {
        // Si existe una casilla actual
        if (currentTile != null)
        {
            // La marcamos como no actual
            currentTile.current = false;
            // Y establecemos que no hay casilla actual
            currentTile = null;
        }

        // Recorremos todas las casillas seleccionables
        foreach (Tile tile in selectableTiles)
        {
            // Reseteamos los valores de las casillas
            tile.Reset();
        }

        // Limpiamos la lista de casillas seleccionables
        selectableTiles.Clear();
    }

    // Función que calcula la dirección entre la casilla en la que estamos y a la que nos queremos mover
    void CalculateHeading(Vector3 target)
    {
        // Calculamos la dirección entre la casilla en la que estamos y a la que nos queremos mover
        heading = target - transform.position;
        // Normalizamos el vector (lo hacemos de magnitud 1, por lo que se convierte en vector unitario, para efectuar los movimientos en la dirección del vector unitario)
        heading.Normalize();
    }

    // Función que calcula la velocidad a la que nos queremos mover
    // Recive: Nada
    // Devuelve: Nada
    void SetHorizotalVelocity()
    {
        // Calculamos la velocidad a la que nos queremos mover
        velocity = heading * moveSpeed;
    }

    // Función que compara el coste del nodo actual al nodo final (coste total de movimiento) de las distintas casillas de una lista
    // Recive: La lista de casillas
    // Devuelve: La casilla con menor coste
    protected Tile FindLowestF(List<Tile> list)
    {
        // Establecemos la primera casilla de la lista como la de menor coste
        Tile lowest = list[0];

        // Recorremos la lista de casillas
        foreach (Tile t in list)
        {
            // Si el coste de la casilla actual es menor que el de la casilla de menor coste
            if (t.f < lowest.f)
            {
                // Establecemos la casilla actual como la de menor coste
                lowest = t;
            }
        }

        // Eliminamos la casilla de menor coste de la lista
        list.Remove(lowest);

        return lowest;
    }

    // Función que calcula el hasta que casilla podemos movernos
    // Recive: Casilla objetivo
    // Devuelve: Nada
    protected Tile FindEndTile(Tile t)
    {
        // Creamos una pila de casillas temporal para guardar el camino
        Stack<Tile> tempPath = new Stack<Tile>();

        // Guardamos la casilla padre de la casilla objetivo a la que queremos ir
        Tile next = t.parent;
        // Mientras la casilla padre no sea nula (mientras no lleguemos a la casilla inicial)
        while (next != null)
        {
            // Vamos añadiendo las casillas a la pila para guardar el camino
            tempPath.Push(next);
            // Y vamos guardando la casilla padre de la casilla actual
            next = next.parent;
        }

        // Si el movimiento es mayor (o igual) que el tamaño de la pila, devolvemos la casilla padre de la casilla objetivo
        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        // Creamos una casilla para guardar la casilla final
        Tile endTile = null;
        // Recorremos el camino hasta el movimiento, pues será el máximo que podremos movernos
        for (int i = 0; i <= move; i++)
        {
            // Guardamos la casilla final hasta la que podemos llegar
            endTile = tempPath.Pop();
        }

        return endTile;
    }

    // Función que calcula el camino a seguir
    // Recive: La casilla a la que nos queremos mover
    // Devuelve: Nada
    protected void FindPath(Tile target)
    {
        // Buscamos las casillas adjacentes a la casilla objetivo
        ComputeAdjacencyLists(target);
        // Calculamos la casilla actual
        GetCurrentTile();

        // Creamos dos listas, una para los nodos (casillas) a procesar y otra con los nodos (casillas) ya procesados
        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        // Añadimos la casilla actual a la lista de casillas a procesar
        openList.Add(currentTile);
        //currentTile.parent = ??
        // Establecemos la distancia entre la casilla actual y la casilla objetivo
        currentTile.h = Vector3.Distance(currentTile.transform.position, target.transform.position);
        // Establecemos la distancia total entre la casilla actual y la casilla objetivo
        currentTile.f = currentTile.h;

        // Mientras haya casillas a procesar
        while (openList.Count > 0)
        {
            // Buscamos la casilla con menor distancia total
            Tile t = FindLowestF(openList);

            // Añadimos la casilla a la lista de casillas ya procesadas
            closedList.Add(t);

            // Si la casilla es la casilla objetivo
            if (t == target)
            {
                // Establecemos la casilla objetivo como la casilla final a la que podemos llegar (si es posible la casilla del objetivo)
                actualTargetTile = FindEndTile(t);
                // Y nos movemos a la casilla objetivo
                MoveToTile(actualTargetTile);
                return;
            }

            // Recorremos las casillas adyacentes a la casilla actual
            foreach (Tile tile in t.adjacencyList)
            {
                // Si la casilla ya ha sido procesada
                if (closedList.Contains(tile))
                {
                    //Do nothing, already processed
                }
                // Si la casilla esta pendiente de procesar
                else if (openList.Contains(tile))
                {
                    // Calculamos el costo de movimiento de la casilla adyacente, en funcion del costo de movimiento de la casilla actual a la inicial más la distancia entre la casilla adyacente y la casilla actual
                    float tempG = t.g + Vector3.Distance(tile.transform.position, t.transform.position);

                    // Si el costo de movimiento de la casilla adyacente es menor que el que ya teniamos
                    // Nota: El que ya teniamos es el que se calculo en la iteración anterior, siendo el de la casilla adyacente, pero que en la iteración anterior no era el adyacente, si no el actual
                    if (tempG < tile.g)
                    {
                        // Establecemos la casilla actual como padre de la casilla adyacente
                        // Con esto cambiamos la ruta estableciendo este camino como más corto
                        tile.parent = t;

                        // Establecemos el costo de movimiento de la casilla adyacente desde el nodo inicial al actual
                        tile.g = tempG;
                        // Establecemos el costo de movimiento de la casilla adyacente desde el nodo inicial al final
                        tile.f = tile.g + tile.h;
                    }
                }
                // Si la casilla no esta en ninguna de las dos listas
                else
                {
                    // Establecemos la casilla actual como padre de la casilla adyacente
                    tile.parent = t;

                    // Establecemos el costo de movimiento de la casilla adyacente desde el nodo inicial al actual
                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    // Establecemos el costo de movimiento de la casilla adyacente desde el nodo final al actual
                    tile.h = Vector3.Distance(tile.transform.position, target.transform.position);
                    // Establecemos el costo de movimiento de la casilla adyacente desde el nodo inicial al final
                    tile.f = tile.g + tile.h;

                    // Añadimos la casilla a la lista de casillas a procesar
                    openList.Add(tile);
                }
            }
        }
        //todo - what do you do if there is no path to the target tile?
        Debug.Log("Path not found");
    }

    // Función que empieza el turno del personaje
    // Recive: Nada
    // Devuelve: Nada
    public void BeginTurn()
    {
        //BattleHUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<BattleHUD>();
        //hud.SetHUD("Juan", 3, 30, 30);
        // Activamos el turno del personaje
        turn = true;
    }

    // Función que termina el turno del personaje
    // Recive: Nada
    // Devuelve: Nada
    public void EndTurn()
    {
        // Desactivamos el turno del personaje
        turn = false;
        //HUDturn = false;
        calculateZone = false;
    }
}
