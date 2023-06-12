using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienteSound : MonoBehaviour
{
    public SoundClips soundClips;
    public AudioSource soundClipsSource;
    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "BosqueCombate":
                soundClipsSource.clip = soundClips.ambienteBosque;
                soundClipsSource.Play();
                break;
            case "PuebloCombate":
                soundClipsSource.clip = soundClips.ambientePueblo;
                soundClipsSource.Play();
                break;
            case "MontanaCombate":
                soundClipsSource.clip = soundClips.ambienteMontana;
                soundClipsSource.Play();
                break;
            case "VolcanCombate":
                soundClipsSource.clip = soundClips.ambienteVolcan;
                soundClipsSource.Play();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
