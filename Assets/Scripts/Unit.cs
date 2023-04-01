using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int life = 150;
    private int mana = 100;
    private int movement;
    private BasicAtack atack = new BasicAtack(9, 20);
    private ArrayList specialAtacks = new ArrayList();
    private GameObject selectedObject = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    selectedObject = hit.transform.gameObject;
                }
                
            }
        }
        if(selectedObject != null)
        {
            Debug.Log("Clicked: " + selectedObject);
        }
        if(selectedObject != null && selectedObject.GetComponent<Unit>() != null)
        {
            Debug.Log("Clicked: " + selectedObject.GetComponent<Unit>().Life);
            atack.Atack(selectedObject, GameObject.FindGameObjectWithTag("Player"));
            Debug.Log("Clicked: " + selectedObject.GetComponent<Unit>().Life);
        }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }
    }
    public void AddSpecialAtack(SpecialAtack specialAtack)
    {
        specialAtacks.Add(specialAtack);
    }
}
