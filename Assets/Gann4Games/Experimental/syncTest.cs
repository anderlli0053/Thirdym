using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncTest : MonoBehaviour {
    int qSamples = 1024;  // array size
    float refValue = 0.1f; // RMS value for 0 dB
    float rmsValue;   // sound level - RMS
    float dbValue;    // sound level - dB
    float volume = 2; // set how much the scale will vary
 
    float[] samples; // audio samples
    public AudioSource sourceAudio;
    public bool useScale;
    public bool useRotation;
    public bool rawImage;

    void Start()
    {
        samples = new float[qSamples];
        if(useRotation)
            transform.Rotate(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
    }

    void GetVolume()
    {
        sourceAudio.GetOutputData(samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < qSamples; i++)
        {
            sum += samples[i] * samples[i]; // sum squared samples
        }
        rmsValue = Mathf.Sqrt(sum / qSamples); // rms = square root of average
        dbValue = 20 * Mathf.Log10(rmsValue / refValue); // calculate dB
        if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
    }

    void Update()
    {
        GetVolume();
        float speed = 2;
        float scaleMultiplier = 1;
        if (GetComponent<Animator>())
        {
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("animSpeed", volume * rmsValue);
        }
        if (useScale)
            transform.localScale = new Vector3(scaleMultiplier + volume * rmsValue, scaleMultiplier + volume * rmsValue, scaleMultiplier + volume * rmsValue);
        if(useRotation)
            transform.Rotate(Random.Range(-speed, speed) * volume * rmsValue, speed * volume * rmsValue, Random.Range(-speed, speed) * volume * rmsValue);
        if(rawImage)
        {
            UnityEngine.UI.RawImage img = GetComponent<UnityEngine.UI.RawImage>();
            img.color = new Color(255, 255, 255, volume * rmsValue);
        }
    }
}
