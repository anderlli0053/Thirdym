using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {
    AudioSource sourceAudio;
    bool onBattle;

    public float maxVolume = 0.5f;

    static BackgroundMusic instance;
    private void Start()
    {
        sourceAudio = GetComponent<AudioSource>();
        instance = this;
    }
    public static void EnableMusic(bool enable)
    {
        if (!instance) return;
        if(enable)
            instance.sourceAudio.volume = Mathf.Lerp(instance.sourceAudio.volume, instance.maxVolume, Time.deltaTime);
        else
            instance.sourceAudio.volume = Mathf.Lerp(instance.sourceAudio.volume, 0, Time.deltaTime / 5);
    }
}
