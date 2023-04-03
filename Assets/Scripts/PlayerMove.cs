using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{
    // Start is called before the first frame update
    void Start()
    {
        //Init(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMove(GameObject gameObject, bool turn)
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {

            FindSelectableTiles(gameObject);
            CheckMouse();

            WhereMouse();

        }
        else
        {
            Move(gameObject);
        }
    }

    // Esta función mira donde está el ratón, sin falta de hacer click. Hay que llamarla desde el Update de vuestro script
    public void WhereMouse()
    //public Unidad DondeRaton()
    {
        Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit sobreUnidad;
        if (Physics.Raycast(trackearCursor, out sobreUnidad))
        {
            if (sobreUnidad.collider.tag == "Unidad")
            {
                // falta crear la clase unidad
                // Unidad unidad = hit.collider.GetComponent<Unidad>();

                Debug.Log("Unidad encontrada! Se llama " + sobreUnidad.collider.gameObject.name);
            }
        }
    }
    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }
}