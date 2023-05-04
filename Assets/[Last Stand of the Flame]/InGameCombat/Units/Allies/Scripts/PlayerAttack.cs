using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : BasicAttack
{
    public bool AoD = true;
    public Material enemyColor;



    // Start is called before the first frame update
    void Start()
    {
        //Damage = gameObject.GetComponent<Unit>().Damage;
        //Range = gameObject.GetComponent<Unit>().Range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject AttackMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Ray trackearCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit sobreUnidad;
        if (Physics.Raycast(trackearCursor, out sobreUnidad))
        {
            if (sobreUnidad.collider.tag == "NPC")
            {
                Debug.Log("Unidad encontrada! Se llama " + sobreUnidad.collider.gameObject.name);
                Renderer renderer = sobreUnidad.collider.gameObject.GetComponentInChildren<Renderer>();
                //renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Color.mat");
                renderer.material = enemyColor;
                //AoD = Attack(sobreUnidad.collider.gameObject, gameObject);
                return sobreUnidad.collider.gameObject;
                //TurnManager.EndTurn();

            }
        } 
        }
        return null;
    }
}
