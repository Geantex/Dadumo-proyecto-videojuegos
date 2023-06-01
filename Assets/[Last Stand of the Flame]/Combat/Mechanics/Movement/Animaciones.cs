using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.CanvasScaler;

public class Animaciones : MonoBehaviour
{
    public GameObject sangrePrefab;
    public GameObject curacionPrefab;
    public GameObject fuegito;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void idle(Animator pj, string name)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara idle");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan idle");
                break;
            case "Galentin":
                pj.Play("Galentin idle");
                break;
            case "Jose Maria":
                pj.Play("JM idle");
                break;
            case "Kaka":
                pj.Play("Kaka idle");
                break;
            case "Kazuro":
                pj.Play("Kazuro idle");
                break;
            case "Romero MacBeth":
                pj.Play("Romero idle");
                break;

            case "Brujo":
                pj.Play("Brujo idle");
                break;
            case "Ladron":
                pj.Play("Bandido idle");
                break;
            case "Rata":
                pj.Play("Rata idle2");
                break;
            case "Troll":
                pj.Play("Troll idle");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss idle");
                break;
        }
    }

    public static void correr(Animator pj, string name)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara correr");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan correr");
                break;
            case "Galentin":
                pj.Play("Galentin correr");
                break;
            case "Jose Maria":
                pj.Play("JM correr");
                break;
            case "Kaka":
                pj.Play("Kaka correr");
                break;
            case "Kazuro":
                pj.Play("Kazuro correr");
                break;
            case "Romero MacBeth":
                pj.Play("Romero correr");
                break;

            case "Brujo":
                pj.Play("Brujo correr");
                break;
            case "Ladron":
                pj.Play("Bandido correr");
                break;
            case "Rata":
                pj.Play("Rata correr2");
                break;
            case "Troll":
                pj.Play("Troll correr");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss correr");
                break;
        }
    }

    public static void ataque(Animator pj, string name, Animaciones a,  GameObject target, GameObject myUnit)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Galentin":
                GameObject bastonGalentin = GetBastonGalentin();
                pj.Play("Galentin ataque");
                // Esperamos medio segundo, despues hacemos aparecer la bola de fuego
                //a.StartCoroutine(a.EsperarMillonacoSegundo());
                bastonGalentin.GetComponentInChildren<ProjectileSpawner>().SpawnProjectile(target);
                a.voyASangrar(myUnit, target, pj);

                break;
            case "Jose Maria":
                pj.Play("JM ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Kaka":
                pj.Play("Kaka ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque");
                a.voyASangrar(myUnit, target, pj);
                break;

            case "Brujo":
                pj.Play("Brujo ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Ladron":
                pj.Play("Bandido ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Rata":
                pj.Play("Rata ataque2");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Troll":
                pj.Play("Troll ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
            case "Señor de la ceniza":
                pj.Play("Boss ataque");
                a.voyASangrar(myUnit, target, pj);
                break;
        }
    }
    
    public static void ataqueEspecial(Animator pj, string name,Animaciones a, GameObject objetivo, GameObject unidadEspecial, bool attack, Vector3 heading)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque especial");
                Transform cabezaDeenecan = unidadEspecial.transform.Find("Deen Ecan idle/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head");
                Instantiate(a.fuegito, heading, Quaternion.identity);
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Galentin":
                GameObject bastonGalentin = GetBastonGalentin();
                pj.Play("Galentin ataque especial");
                bastonGalentin.GetComponentInChildren<ParticulaExplosionMagica>().ExplosionMagica(objetivo);
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Jose Maria":
                pj.Play("JM ataque especial");
                a.curarParticula(a, objetivo);
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Kaka":
                pj.Play("Kaka ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque especial");
                a.curarParticula(a, objetivo);
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;

            case "Brujo":
                pj.Play("Brujo ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Ladron":
                pj.Play("Bandido ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Rata":
                pj.Play("Rata ataque especial2");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Troll":
                pj.Play("Troll ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
            case "Señor de la ceniza":
                pj.Play("Boss ataque especial");
                if (attack)
                {
                    a.voyASangrar(unidadEspecial, objetivo, pj);
                }
                break;
        }
    }

    public static void recibirDano(Animator pj, string name,GameObject damagedUnit, Animaciones a)
    {
        Instantiate(a.sangrePrefab, damagedUnit.transform.position, Quaternion.identity);

        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara recibir daño");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan recibir daño");
                break;
            case "Galentin":
                pj.Play("Galentin recibir daño");
                break;
            case "Jose Maria":
                pj.Play("JM recibir daño");
                break;
            case "Kaka":
                pj.Play("Kaka recibir daño");
                break;
            case "Kazuro":
                pj.Play("Kazuro recibir daño");
                break;
            case "Romero MacBeth":
                pj.Play("Romero recibir daño");
                break;

            case "Brujo":
                pj.Play("Brujo recibir daño");
                break;
            case "Ladron":
                pj.Play("Bandido recibir daño");
                break;
            case "Rata":
                pj.Play("Rata recibir daño2");
                break;
            case "Troll":
                pj.Play("Troll recibir daño");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss recibir daño");
                break;
        }
    }

    public static void morir(Animator pj, string name)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara morir");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan morir");
                break;
            case "Galentin":
                pj.Play("Galentin morir");
                break;
            case "Jose Maria":
                pj.Play("JM morir");
                break;
            case "Kaka":
                pj.Play("Kaka morir");
                break;
            case "Kazuro":
                pj.Play("Kazuro morir");
                break;
            case "Romero MacBeth":
                pj.Play("Romero morir");
                break;

            case "Brujo":
                pj.Play("Brujo morir");
                break;
            case "Ladron":
                pj.Play("Bandido morir");
                break;
            case "Rata":
                pj.Play("Rata morir2");
                break;
            case "Troll":
                pj.Play("Troll morir");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss morir");
                break;
        }
    }

    public static GameObject GetBastonGalentin()
    {
        GameObject bastonGalentin = GameObject.FindGameObjectWithTag("bastonGalentin");
        return bastonGalentin;
    }

    IEnumerator EsperarMillonacoSegundo()
    {
        yield return new WaitForSeconds(0.5f);
        //Aqu� es donde colocas la acci�n que quieres realizar despu�s de cinco segundos
    }
    public void curarParticula(Animaciones ani, GameObject objetivoCurar)
    {
        Instantiate(ani.curacionPrefab, objetivoCurar.transform.position, Quaternion.identity);
    }

    void voyASangrar(GameObject ally, GameObject enemy, Animator a)
    {
        //Animaciones.ataqueEspecial(ally.GetComponentInChildren<Animator>(), ally.GetComponent<Unit>().Name, FindObjectOfType<Animaciones>(), enemy, ally);
        float animationLength = 0;

        // Asegúrate de tener una referencia válida al componente Animator
        if (a != null)
        {
            // Obtén el estado actual de la animación
            AnimatorStateInfo stateInfo = a.GetCurrentAnimatorStateInfo(0);

            // Obtén la duración del estado actual
            animationLength = stateInfo.length;

            // Haz algo con la duración de la animación
            Debug.Log("Duración de la animación: " + animationLength + " segundos");

            StartCoroutine(RecibirSangrar(animationLength, enemy));
        }
        else
        {
            Debug.Log("No se encontró ningún componente Animator en el objeto.");
        }
    }


    IEnumerator RecibirSangrar(float t, GameObject enemy)
    {
        Debug.Log(t);
        yield return new WaitForSeconds(t-1);
        // Aquí es donde colocas la acción que quieres realizar después de esperar la duración de la animación
        Animaciones.recibirDano(enemy.GetComponentInChildren<Animator>(), enemy.GetComponent<Unit>().Name, enemy, FindObjectOfType<Animaciones>());
    }
}
