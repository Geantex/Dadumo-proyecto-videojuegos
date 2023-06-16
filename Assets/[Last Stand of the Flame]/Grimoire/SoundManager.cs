using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSoundSiguiente;
    public AudioClip buttonSoundAnterior;

    public SoundManager soundManager;

    public void PlayButtonSound1()
    {
        soundManager.GetComponent<AudioSource>().PlayOneShot(soundManager.buttonSoundSiguiente);
    }

    public void PlayButtonSound2()
    {
        soundManager.GetComponent<AudioSource>().PlayOneShot(soundManager.buttonSoundAnterior);
    }
}
