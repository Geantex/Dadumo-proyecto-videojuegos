using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSounds : MonoBehaviour
{
    public SoundClips soundClips;
    public AudioSource soundClipsSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void idle(string name)
    {
        switch (name)
        {
            case "Barbara":
                
                break;
            case "Deen Ecan":
                
                break;
            case "Galentin":
                
                break;
            case "Jose Maria":
                
                break;
            case "Kaka":
                
                break;
            case "Kazuro":
                
                break;
            case "Romero MacBeth":
                
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }

    public void correr(string name)
    {
        switch (name)
        {
            case "Barbara":
                
                break;
            case "Deen Ecan":
                
                break;
            case "Galentin":
                
                break;
            case "Jose Maria":
                
                break;
            case "Kaka":
                
                break;
            case "Kazuro":
                
                break;
            case "Romero MacBeth":
                
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }

    public void ataque(string name)
    {
        switch (name)
        {
            case "Barbara":
                soundClipsSource.clip = soundClips.BarbaraAttack[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Deen Ecan":
                soundClipsSource.clip = soundClips.DeenEcanAttack[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Galentin":
                soundClipsSource.clip = soundClips.GalentinFXAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;
            case "Jose Maria":
                soundClipsSource.clip = soundClips.JoseMariaAttack[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Kaka":
                soundClipsSource.clip = soundClips.KakaAttack[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Kazuro":
                soundClipsSource.clip = soundClips.KazuroAttack[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Romero MacBeth":
                soundClipsSource.clip = soundClips.RomeroAttack[Random.Range(0, 3)];
                soundClipsSource.Play();
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }

    public void ataqueEspecial(string name)
    {
        switch (name)
        {
            case "Barbara":
                soundClipsSource.clip = soundClips.BarbaraSpecialAttack[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Deen Ecan":
                soundClipsSource.clip = soundClips.DeenEcanFXSpecialAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;
            case "Galentin":
                soundClipsSource.clip = soundClips.GalentinFXSpecialAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;
            case "Jose Maria":
                soundClipsSource.clip = soundClips.JoseMariaFXSpecialAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;
            case "Kaka":
                soundClipsSource.clip = soundClips.KakaSpecialAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;
            case "Kazuro":
                soundClipsSource.clip = soundClips.KazuroSpecialAttack[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Romero MacBeth":
                soundClipsSource.clip = soundClips.RomeroFXSpecialAttack[Random.Range(0, 1)];
                soundClipsSource.Play();
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }

    public void recibirDano(string name)
    {
        switch (name)
        {
            case "Barbara":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 3)];
                soundClipsSource.Play();
                break;
            case "Deen Ecan":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Galentin":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 6)];
                soundClipsSource.Play();
                break;
            case "Jose Maria":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Kaka":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Kazuro":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 5)];
                soundClipsSource.Play();
                break;
            case "Romero MacBeth":
                soundClipsSource.clip = soundClips.BarbaraHurt[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }

    public void morir(string name)
    {
        switch (name)
        {
            case "Barbara":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Deen Ecan":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Galentin":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Jose Maria":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Kaka":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Kazuro":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;
            case "Romero MacBeth":
                soundClipsSource.clip = soundClips.BarbaraDeath[Random.Range(0, 4)];
                soundClipsSource.Play();
                break;

            case "Brujo":
                
                break;
            case "Ladron":
                
                break;
            case "Rata":
                
                break;
            case "Troll":
                
                break;
            case "Señor de la ceniza":
                
                break;
        }
    }
}
