using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienConfigurador : MonoBehaviour
{

    public Transform alien;

    public GameObject[] objetosColor;

    public Animator animator;

    public string Nombre
    {
        get
        {
            return AlienCustomData.nombre;
        }
        set
        {
            AlienCustomData.nombre = value;
        }
    }
    public bool Armado
    {
        get
        {
            return AlienCustomData.armado;
        }
        set
        {
            AlienCustomData.armado = value;
            animator.SetBool("Weapon", AlienCustomData.armado);
        }
    }
    public int Color
    {
        get
        {
            return AlienCustomData.ColorIndex;
        }
        set
        {
            AlienCustomData.ColorIndex = value;
            foreach (var item in objetosColor)
            {
                Utilidades.CambiarColor(item, AlienCustomData.Color, "teamColor");
            }
        }
    }
    public float Rotation
    {
        get
        {
            return alien.rotation.y;
        }
        set
        {
            Vector3 rot = alien.rotation.eulerAngles;
            rot.y = -value;
            alien.rotation = Quaternion.Euler(rot);
        }
    }

    public void Continuar()
    {
        SceneManager.LoadSceneAsync("AlienPlay");
    }
}
