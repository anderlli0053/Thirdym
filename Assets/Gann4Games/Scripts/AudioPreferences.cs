using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPreferences : MonoBehaviour
{
    public AudioMixer mixer;

    public UnityEngine.UI.Slider master;
    public UnityEngine.UI.Slider environment;
    public UnityEngine.UI.Slider music;
    public UnityEngine.UI.Slider fx;

    private void Start()
    {
        master.value = PlayerPreferences.instance.GetJsonData().audio_master;
        environment.value = PlayerPreferences.instance.GetJsonData().audio_environment;
        music.value = PlayerPreferences.instance.GetJsonData().audio_music;
        fx.value = PlayerPreferences.instance.GetJsonData().audio_effects;
    }
    public void MasterVolume(float value)
    {
        PlayerPreferences.instance.json_structure.audio_master = value;
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) *20);
    }
    public void EnvironmentVolume(float value)
    {
        PlayerPreferences.instance.json_structure.audio_environment = value;
        mixer.SetFloat("EnvironmentVolume", Mathf.Log10(value) * 20);
    }
    public void MusicVolume(float value)
    {
        PlayerPreferences.instance.json_structure.audio_music = value;
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }
    public void FXVolume(float value)
    {
        PlayerPreferences.instance.json_structure.audio_effects = value;
        mixer.SetFloat("FXVolume", Mathf.Log10(value) * 20);
    }
    public void SaveChanges()
    {
        PlayerPreferences.instance.RefreshJsonFile();
        NotificationHandler.Notify("Audio data has been saved.");
    }
}
