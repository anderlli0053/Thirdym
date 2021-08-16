using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PostProcessing.Utilities;
using UnityEngine.UI;

public class GraphicPrefs : MonoBehaviour {
    public bool idk;
    public int idk2;        // Wow such an amazing code

    int resolution;
    bool FullScreen;
    Resolution[] resolutions;
    public Text resIndicator;
    /*public PostProcessingController[] ppc;
    public Toggle AmbientOcclusion;
    public Toggle Antialiasing;
    public Toggle Bloom;
    public Toggle ChromaticAberration;
    public Toggle ColorGrading;
    public Toggle DOF;
    public Toggle eyeAdaptation;
    public Toggle Grain;
    public Toggle MotionBlur;
    public Toggle Reflection;
    public Toggle UserLut;
    public Toggle Vignette;
    private void Start()
    {
        //ppc = FindObjectsOfType<PostProcessingController>();
        ppc = Resources.FindObjectsOfTypeAll<PostProcessingController>();
        resolutions = Screen.resolutions;
        resolution = PlayerPrefs.GetInt("Resolution", resolutions.Length);
        resIndicator.text = "Current resolution: " + Screen.currentResolution.width + "x" + Screen.currentResolution.height;
        SetResolution();
    }
    private void Update()
    {
        if (resolution > resolutions.Length)
            resolution = resolutions.Length;
        if (resolution < 0)
            resolution = 0;
    }
    private void OnLevelWasLoaded(int level)
    {
        //ppc = FindObjectsOfType<PostProcessingController>();
        ppc = Resources.FindObjectsOfTypeAll<PostProcessingController>();
        Invoke("SetPostProcessing", 1);
    }

    public void SetResolution()
    {
        resolutions = Screen.resolutions;
        PlayerPrefs.SetInt("Resolution", resolution);
        Screen.SetResolution(resolutions[resolution].width, resolutions[resolution].height, FullScreen);
        resIndicator.text = "Current resolution: " + resolutions[resolution].width + "x" + resolutions[resolution].height;
    }
    public void NextRes()
    {
        resolution = resolution + 1;
        SetResolution();
    }
    public void PrevRes()
    {
        resolution = resolution - 1;
        SetResolution();
    }
    public void SetScreenMode(bool fs)
    {
        FullScreen = fs;
        SetResolution();
    }

    public void SetPostProcessing()
    {
        for(int i = 0; i < ppc.Length; i++)
        {
            ppc[i].enableAmbientOcclusion = AmbientOcclusion.isOn;
            ppc[i].enableAntialiasing = Antialiasing.isOn;
            ppc[i].enableBloom = Bloom.isOn;
            ppc[i].enableChromaticAberration = ChromaticAberration.isOn;
            ppc[i].enableColorGrading = ColorGrading.isOn;
            ppc[i].enableDepthOfField = DOF.isOn;
            ppc[i].enableEyeAdaptation = eyeAdaptation.isOn;
            ppc[i].enableGrain = Grain.isOn;
            ppc[i].enableMotionBlur = MotionBlur.isOn;
            ppc[i].enableScreenSpaceReflection = Reflection.isOn;
            ppc[i].enableUserLut = UserLut.isOn;
            ppc[i].enableVignette = Vignette.isOn;
        }
    }*/
}
