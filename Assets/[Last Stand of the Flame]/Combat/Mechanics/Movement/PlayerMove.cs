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
        basicAttack = false;
        specialAttack = false;

        TurnManager.EndTurn(gameObject.GetComponent<TacticsMove>(), FindObjectOfType<TurnManager>()); //AQUI
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
