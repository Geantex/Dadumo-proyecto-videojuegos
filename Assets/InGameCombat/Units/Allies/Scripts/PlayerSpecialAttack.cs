using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public bool AoD = true;
    public List<SpecialAttack> AllSpecialAttacks = new List<SpecialAttack>();

    /*public PlayerSpecialAttack(int damage, int range, string stateEffect, double stateEffectProbability, string boostType, double boostValue)
    {
        this.Damage = damage;
        this.Range = range;
        this.StateEffect = stateEffect;
        this.StateEffectProbability = stateEffectProbability;
        this.BoostType = boostType;
        this.BoostValue = boostValue;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        AddSpecialAttack(new SpecialAttack(20, 8, "Paralyze", 80, "Attack", 20));
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
                    renderer.material = AssetDatabase.LoadAssetAtPath<Material>("Assets/InGameCombat/Units/Enemies/Materials/Enemigo_Seleccionado.mat");

                    //AoD = Attack(sobreUnidad.collider.gameObject, gameObject);
                    return sobreUnidad.collider.gameObject;
                    //TurnManager.EndTurn();

                }
            }
        }
        return null;
    }

    public void AddSpecialAttack(SpecialAttack SpecialAttack)
    {
        if (!AllSpecialAttacks.Contains(SpecialAttack))
        {
            if (AllSpecialAttacks.Count < 4)
            {
                AllSpecialAttacks.Add(SpecialAttack);
            }
        }
    }
}
