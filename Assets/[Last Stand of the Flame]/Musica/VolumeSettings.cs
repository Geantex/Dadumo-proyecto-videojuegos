using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider SliderGeneral;
    [SerializeField] private Slider SliderMusica;
    [SerializeField] private Slider SliderAmbiente;
    [SerializeField] private Slider SliderFX;
    [SerializeField] private Slider SliderFXWeapons;

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumenGeneral") || PlayerPrefs.HasKey("VolumenMusica") || 
            PlayerPrefs.HasKey("VolumenAmbiente") || PlayerPrefs.HasKey("VolumenFX") ||
            PlayerPrefs.HasKey("VolumenFXWeapons")) 
        {
            LoadVolume();
        }
        else
        {
            SetGeneralVolume();
            SetMusicVolume();
            SetAmbienteVolume();
            SetFXVolume();
            SetFXWeaponsVolume();
        }
    }

    //----------------------------------
    //--------Volumen General-----------
    //----------------------------------
    public void SetGeneralVolume()
    {
        float volume = SliderGeneral.value;
        audioMixer.SetFloat("General", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("VolumenGeneral", volume);
    }
    //----------------------------------
    //--------Volumen Musica------------
    //----------------------------------
    public void SetMusicVolume()
    {
        float volume = SliderMusica.value;
        audioMixer.SetFloat("Musica", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumenMusica", volume);
    }
    //----------------------------------
    //--------Volumen Ambiente----------
    //----------------------------------
    public void SetAmbienteVolume()
    {
        float volume = SliderAmbiente.value;
        audioMixer.SetFloat("Ambiente", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumenAmbiente", volume);
    }
    //----------------------------------
    //--------Volumen FX----------------
    //----------------------------------
    public void SetFXVolume()
    {
        float volume = SliderFX.value;
        audioMixer.SetFloat("FX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumenFX", volume);
    }
    //----------------------------------
    //--------Volumen FXWeapons----------------
    //----------------------------------
    public void SetFXWeaponsVolume()
    {
        float volume = SliderFXWeapons.value;
        audioMixer.SetFloat("FX weapon", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumenFXWeapons", volume);
    }

    //----------------------------------
    //--------Carga de volumenes--------
    //----------------------------------
    private void LoadVolume()
    {
        SliderGeneral.value = PlayerPrefs.GetFloat("VolumenGeneral");
        SetGeneralVolume();
        SliderMusica.value = PlayerPrefs.GetFloat("VolumenMusica");
        SetMusicVolume();
        SliderAmbiente.value = PlayerPrefs.GetFloat("VolumenAmbiente");
        SetAmbienteVolume();
        SliderFX.value = PlayerPrefs.GetFloat("VolumenFX");
        SetFXVolume();
        SliderFXWeapons.value = PlayerPrefs.GetFloat("VolumenFXWeapons");
        SetFXWeaponsVolume();
    }
}


