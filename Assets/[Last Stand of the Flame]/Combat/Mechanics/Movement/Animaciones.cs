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
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 1.76f, 3.16f));
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.63f, 1.12f));
                break;
            case "Galentin":
                GameObject bastonGalentin = GetBastonGalentin();
                pj.Play("Galentin ataque");
                bastonGalentin.GetComponentInChildren<ProjectileSpawner>().SpawnProjectile(target);
                break;
            case "Jose Maria":
                pj.Play("JM ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.3f, 1.26f));
                break;
            case "Kaka":
                pj.Play("Kaka ataque");
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.3f, 1.15f));
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.45f, 1f));
                break;

            case "Brujo":
                pj.Play("Brujo ataque");
                a.llamarCoordinarRayos(myUnit, target);
                break;
            case "Ladron":
                pj.Play("Bandido ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.4f, 0.58f));
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 1f, 1.2f));
                break;
            case "Rata":
                pj.Play("Rata atacar2");
                break;
            case "Troll":
                pj.Play("Troll ataque");
                // El troll hace 2 garrotazos en el mismo ataque (esto es solo cosmético)
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.68f, 1.08f));
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 1.4f, 1.8f));
                break;
            case "Señor de la ceniza":
                pj.Play("Boss ataque");
                a.StartCoroutine(a.HabilitarArmaTrail(myUnit, 0.33f, 1.1f));
                break;
        }
    }
    
    public static void ataqueEspecial(Animator pj, string name,Animaciones a, GameObject unidadEspecial, Vector3 heading, GameObject objetivo = null)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara ataque especial");
                a.StartCoroutine(a.HabilitarArmaTrail(unidadEspecial, 0.4f, 1.5f));


                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque especial");
                Transform cabezaDeenecan = unidadEspecial.transform.Find("Deen Ecan idle/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head");
                Instantiate(a.fuegito, cabezaDeenecan.position, Quaternion.LookRotation(objetivo.transform.position));
                break;
            case "Galentin":
                GameObject bastonGalentin = GetBastonGalentin();
                pj.Play("Galentin ataque especial");
                bastonGalentin.GetComponentInChildren<ParticulaExplosionMagica>().ExplosionMagica(objetivo);
                break;
            case "Jose Maria":
                pj.Play("JM ataque especial");
                a.curarParticula(a, objetivo);
                break;
            case "Kaka":
                pj.Play("Kaka ataque especial");
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque especial");
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque especial");
                a.curarParticula(a, objetivo);
                break;

            case "Brujo":
                pj.Play("Brujo ataque especial");
                break;
            case "Ladron":
                pj.Play("Bandido ataque especial");
                break;
            case "Rata":
                pj.Play("Rata ataque especial2");
                break;
            case "Troll":
                pj.Play("Troll ataque especial");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss ataque especial");
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

    public static void sentado(Animator pj, string name)
    {
        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara Sentada");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan Sentado");
                break;
            case "Galentin":
                pj.Play("Galentin Sentado");
                break;
            case "Jose Maria":
                pj.Play("JM Sentado");
                break;
            case "Kaka":
                pj.Play("Kaka Sentado");
                break;
            case "Kazuro":
                pj.Play("Kazuro Sentado");
                break;
            case "Romero MacBeth":
                pj.Play("Romero Sentado");
                break;
        }
    }

    public static GameObject GetBastonGalentin()
    {
        GameObject bastonGalentin = GameObject.FindGameObjectWithTag("bastonGalentin");
        return bastonGalentin;
    }
    IEnumerator CoordinarRayos(GameObject myUnit, GameObject target)
    {
        yield return new WaitForSeconds(0.5f);
        myUnit.GetComponentInChildren<RayoBrujo>().DispararRayosAlObjetivo(target);

    }
    private void llamarCoordinarRayos(GameObject myUnit, GameObject target)
    {
        StartCoroutine(CoordinarRayos(myUnit, target));
    }

    public void curarParticula(Animaciones ani, GameObject objetivoCurar)
    {
        Instantiate(ani.curacionPrefab, objetivoCurar.transform.position, Quaternion.identity);
    }
    private IEnumerator HabilitarArmaTrail(GameObject myUnit, float tiempoInicial, float tiempoFinal)
    {
        TrailRenderer[] armasTrails = myUnit.GetComponentsInChildren<TrailRenderer>();
        yield return new WaitForSeconds(tiempoInicial);
        foreach (TrailRenderer trailRenderer in armasTrails)
        {
            trailRenderer.emitting = true;
        }
        // esto es para que tiempoFinal tenga en cuenta el tiempo en el que Trail está activo
        tiempoFinal = tiempoFinal - tiempoInicial;
        yield return new WaitForSeconds(tiempoFinal);
        foreach (TrailRenderer trailRenderer in armasTrails)
        {
            trailRenderer.emitting = false;
        }
    }

}
