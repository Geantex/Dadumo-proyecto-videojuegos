using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
            DondeRaton();
        }
        else
        {
            Move();
        }
    }

    // Esta funci�n mira donde est� el rat�n, sin falta de hacer click. Hay que llamarla desde el Update de vuestro script
    public void DondeRaton()
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
            // si hace click en enemigo en el futuro??
            // Hugo AQUI!!!!
            /*if (hit.collider.tag = "Enemigo") 
            {
            // atacarEnemigo();
            }
            */
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
                // si hace click en enemigo en el futuro??
                // Hugo AQUI!!!!
                /*if (hit.collider.tag = "Enemigo") 
                {
                // atacarEnemigo();
                }
                */
            }
        }
    }
}