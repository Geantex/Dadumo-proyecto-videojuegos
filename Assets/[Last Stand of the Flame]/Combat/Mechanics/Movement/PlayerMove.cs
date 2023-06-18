using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : TacticsMove
{
    // -----------------------------------------------------------------------------
    // En esta clase vamos a controlar el movimiento del jugador
    // -----------------------------------------------------------------------------

    // Creamos una lista donde guardaremos los objetivos de los ataques
    List<GameObject> targets = new List<GameObject>();
    GameObject uniqueTarget;

    // Creamos dos variables que nos indican si el jugador ha seleccionado un ataque básico o especial
    // Con esto conseguimos que, una vez seleccionado el ataque que queremos realizar, podamos seleccionar el objetivo y concluir el ataque
    public bool basicAttack = false;
    public bool specialAttack = false;

    // Use this for initialization
    void Start()
    {
        // Establecemos las funciones que se ejecutarán al pulsar los botones de la interfaz
        FindObjectOfType<BattleHUD>().buttonSpecialAttack1.onClick.AddListener(SpecialAttackButton);
        FindObjectOfType<BattleHUD>().buttonBasicAttack.onClick.AddListener(AttackButton);
        FindObjectOfType<BattleHUD>().buttonFinishTurn.onClick.AddListener(endMyTurn);

        // Inicializamos el movimiento
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Si no es su turno, no hace nada
        if (!turn)
        {
            return;
        }

        teclas();

        // En función de si tenemos suficiente maná o no para realizar el ataque especial, activamos o desactivamos el botón
        if (gameObject.GetComponent<PlayerSpecialAttack>().canIDo(0))
        {
            FindObjectOfType<BattleHUD>().buttonSpecialAttack1.interactable = true;
        }
        else
        {
            FindObjectOfType<BattleHUD>().buttonSpecialAttack1.interactable = false;
        }

        // Si no se está moviendo, calculamos la zona de movimiento y el camino
        if (!moving)
        {
            // Si hemos activado el ataque básido y hay objetivos, podemos realizamos el ataque
            if (basicAttack && targets.Count > 0)
            {
                DoBasicAttack();
            }
            // Si hemos activado el ataque especial y hay objetivos, podemos realizamos el ataque
            if (specialAttack && targets.Count > 0)
            {
                DoSpecialAttack();
            }
            // Si no se ha calculado la zona de movimiento, la calculamos
            if (!calculateZone)
            {
                // Obtenemos la casilla en la que está el jugador
                GetCurrentTile();
                // Calculamos la zona de movimiento
                FindSelectableTiles();
                // Indicamos que se ha calculado la zona de movimiento
                calculateZone = true;
            }
            else
            {
                // Si se ha calculado la zona de movimiento, recalculamos la casilla en la que está el jugador
                GetCurrentTile();
                FindParentTiles();
            }
            // Con esta función estaremos en constante comprobación para poder movernos a la casilla que queramos de las que están en la zona de movimiento
            CheckMouse();
        }
        else
        {
            // Si se está moviendo, nos movemos
            Move();
        }
    }

    // Comprobamos si hemos pulsado en una casilla de la zona de movimiento y nos movemos a ella
    // Recive: Nada
    // Devuelve: Nada
    void CheckMouse()
    {
        // Si no se ha pulsado el botón izquierdo del ratón, no hace nada, en caso contrario hace lo siguiente
        if (Input.GetMouseButtonUp(0))
        {
            // Creamos un rayo que va desde la cámara hasta la posición del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Creamos un RaycastHit que nos indica si el rayo ha chocado con algo
            RaycastHit hit;
            // Si el rayo ha chocado con algo, hacemos lo siguiente
            if (Physics.Raycast(ray, out hit))
            {
                // Si el rayo ha chocado con una casilla, hacemos lo siguiente
                if (hit.collider.tag == "Tile")
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<Unit>().circulo.SetActive(false);
                    }

                    gameObject.GetComponent<PlayerMove>().Targets.Clear();
                    // Obtenemos la casilla con la que ha chocado el rayo
                    Tile t = hit.collider.GetComponent<Tile>();

                    // Si la casilla es seleccionable, nos movemos a ella
                    if (t.selectable)
                    {
                        // Indicamos que nos movemos a la casilla seleccionada
                        MoveToTile(t);
                    }
                }
            }
        }
    }

    void AttackButton()
    {
        if (!turn && !moving)
        {
            return;
        }

        targets = gameObject.GetComponent<PlayerAttack>().AttackMouse();
        specialAttack = false;
        basicAttack = true;
    }

    void AttackKey()
    {
        if (!turn && !moving)
        {
            return;
        }

        targets = gameObject.GetComponent<PlayerAttack>().AttackKey();
        if(targets.Count > 0)
        {
            targets[0].GetComponent<Unit>().circulo.SetActive(true);
            uniqueTarget = targets[0];
        }
        specialAttack = false;
        basicAttack = true;
    }

    void DoBasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit sobreUnidad;
            if (Physics.Raycast(trackearCursor, out sobreUnidad))
            {
                if (sobreUnidad.collider.tag == "NPC")
                {
                    foreach (GameObject target in targets)
                    {
                        if (target == sobreUnidad.collider.gameObject)
                        {
                            uniqueTarget = target;
                            gameObject.GetComponent<PlayerAttack>().AttackOfPlayer(target);
                        }
                    }
                }
            }
        }
    }

    void SpecialAttackButton()
    {
        if (!turn && !moving)
        {
            return;
        }

        targets = gameObject.GetComponent<PlayerSpecialAttack>().AttackMouse(0);
        basicAttack = false;
        specialAttack = true;
    }

    void SpecialAttackKey()
    {
        if (!turn && !moving)
        {
            return;
        }

        targets = gameObject.GetComponent<PlayerSpecialAttack>().AttackKey(0);
        if (targets.Count > 0)
        {
            targets[0].GetComponent<Unit>().circulo.SetActive(true);
        }
        basicAttack = false;
        specialAttack = true;
    }

    void DoSpecialAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit sobreUnidad;
            if (Physics.Raycast(trackearCursor, out sobreUnidad))
            {
                if (sobreUnidad.collider.tag == "NPC" || sobreUnidad.collider.tag == "Player")
                {
                    foreach (GameObject target in targets)
                    {
                        if (target == sobreUnidad.collider.gameObject)
                        {
                            uniqueTarget = target;
                            gameObject.GetComponent<PlayerSpecialAttack>().AttackOfPlayer(0, target, targets);
                        }
                    }
                }
            }
        }
    }

    void endMyTurn()
    {
        if (!turn || moving)
        {
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Unit>().circulo.SetActive(false);
        }

        GameObject[] allies = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject ally in allies)
        {
            ally.GetComponent<Unit>().circulo.SetActive(false);
        }

        Targets.Clear();

        basicAttack = false;
        specialAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
    }

    void teclas()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackKey();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SpecialAttackKey();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            endMyTurn();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int index = targets.IndexOf(uniqueTarget);
            uniqueTarget.GetComponent<Unit>().circulo.SetActive(false);
            Debug.Log("Arriba");
            if ((index -1) < 0)
            {
                uniqueTarget = targets[index - 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
            else
            {
                uniqueTarget = targets[index - 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Izq");
            int index = targets.IndexOf(uniqueTarget);
            uniqueTarget.GetComponent<Unit>().circulo.SetActive(false);
            if ((index - 1) < 0)
            {
                uniqueTarget = targets[index - 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
            else
            {
                uniqueTarget = targets[index - 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Der");
            int index = targets.IndexOf(uniqueTarget);
            uniqueTarget.GetComponent<Unit>().circulo.SetActive(false);
            if ((index + 1) == targets.Count)
            {
                uniqueTarget = targets[index + 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
            else
            {
                uniqueTarget = targets[index + 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Abajo");
            int index = targets.IndexOf(uniqueTarget);
            uniqueTarget.GetComponent<Unit>().circulo.SetActive(false);
            if ((index + 1) == targets.Count)
            {
                uniqueTarget = targets[index + 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
            else
            {
                uniqueTarget = targets[index + 1];
                uniqueTarget.GetComponent<Unit>().circulo.SetActive(true);
            }
        }

        // Si no se está moviendo, calculamos la zona de movimiento y el camino
        if (!moving)
        {
            // Si hemos activado el ataque básido y hay objetivos, podemos realizamos el ataque
            if (basicAttack && targets.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    gameObject.GetComponent<PlayerAttack>().AttackOfPlayer(uniqueTarget);
                }
            }
            // Si hemos activado el ataque especial y hay objetivos, podemos realizamos el ataque
            if (specialAttack && targets.Count > 0)
            {
                // En función de si tenemos suficiente maná o no para realizar el ataque especial, activamos o desactivamos el botón
                if (gameObject.GetComponent<PlayerSpecialAttack>().canIDo(0))
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        gameObject.GetComponent<PlayerSpecialAttack>().AttackOfPlayer(0, uniqueTarget, targets);
                    }
                }
            }
            // Si no se ha calculado la zona de movimiento, la calculamos
            if (!calculateZone)
            {
                // Obtenemos la casilla en la que está el jugador
                GetCurrentTile();
                // Calculamos la zona de movimiento
                FindSelectableTiles();
                // Indicamos que se ha calculado la zona de movimiento
                calculateZone = true;
            }
            else
            {
                // Si se ha calculado la zona de movimiento, recalculamos la casilla en la que está el jugador
                GetCurrentTile();
                FindParentTiles();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (CurrentTile.adjacencyList[1] != null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<Unit>().circulo.SetActive(false);
                    }

                    gameObject.GetComponent<PlayerMove>().Targets.Clear();

                    MoveToTile(CurrentTile.adjacencyList[1]);
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (CurrentTile.adjacencyList[3] != null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<Unit>().circulo.SetActive(false);
                    }

                    gameObject.GetComponent<PlayerMove>().Targets.Clear();

                    MoveToTile(CurrentTile.adjacencyList[3]);
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (CurrentTile.adjacencyList[0] != null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<Unit>().circulo.SetActive(false);
                    }

                    gameObject.GetComponent<PlayerMove>().Targets.Clear();

                    MoveToTile(CurrentTile.adjacencyList[0]);
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (CurrentTile.adjacencyList[2] != null)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");

                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<Unit>().circulo.SetActive(false);
                    }

                    gameObject.GetComponent<PlayerMove>().Targets.Clear();

                    MoveToTile(CurrentTile.adjacencyList[2]);
                }
            }
        }
        else
        {
            // Si se está moviendo, nos movemos
            Move();
        }
    }

    public GameObject UniqueTarget
    {
        get { return uniqueTarget; }
        set { uniqueTarget = value; }
    }

    public List<GameObject> Targets
    {
        get { return targets; }
        set { targets = value; }
    }
}
