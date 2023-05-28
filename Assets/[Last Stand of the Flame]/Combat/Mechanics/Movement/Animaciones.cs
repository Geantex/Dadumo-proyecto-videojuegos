using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
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
                pj.Play("Ladron idle");
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
                pj.Play("Ladron correr");
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

    public static void ataque(Animator pj, string name)
    {

        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara ataque");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque");
                break;
            case "Galentin":
                pj.Play("Galentin ataque");
                break;
            case "Jose Maria":
                pj.Play("JM ataque");
                break;
            case "Kaka":
                pj.Play("Kaka ataque");
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque");
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque");
                break;

            case "Brujo":
                pj.Play("Brujo ataque");
                break;
            case "Ladron":
                pj.Play("Ladron ataque");
                break;
            case "Rata":
                pj.Play("Rata ataque2");
                break;
            case "Troll":
                pj.Play("Troll ataque");
                break;
            case "Señor de la ceniza":
                pj.Play("Boss ataque");
                break;
        }
    }
    
    public static void ataqueEspecial(Animator pj, string name)
    {
        pj.Play("Barbara ataque especial");

        switch (name)
        {
            case "Barbara":
                pj.Play("Barbara ataque especial");
                break;
            case "Deen Ecan":
                pj.Play("Deen Ecan ataque especial");
                break;
            case "Galentin":
                pj.Play("Galentin ataque especial");
                break;
            case "Jose Maria":
                pj.Play("JM ataque especial");
                break;
            case "Kaka":
                pj.Play("Kaka ataque especial");
                break;
            case "Kazuro":
                pj.Play("Kazuro ataque especial");
                break;
            case "Romero MacBeth":
                pj.Play("Romero ataque especial");
                break;

            case "Brujo":
                pj.Play("Brujo ataque especial");
                break;
            case "Ladron":
                pj.Play("Ladron ataque especial");
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

    public static void recibirDaño(Animator pj, string name)
    {
        pj.Play("Barbara recibir daño");

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
                pj.Play("Ladron recibir daño");
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
        pj.Play("Barbara morir");

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
                pj.Play("Ladron morir");
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
}
