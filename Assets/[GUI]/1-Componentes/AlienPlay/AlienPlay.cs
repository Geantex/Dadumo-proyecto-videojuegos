using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPlay : MonoBehaviour
{
    public GameObject[] objetosColor;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Weapon", AlienCustomData.armado);
        foreach (var item in objetosColor)
        {
            Utilidades.CambiarColor(item, AlienCustomData.Color, "teamColor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
