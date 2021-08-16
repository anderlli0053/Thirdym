using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(WorldGUI_Button))]
public class WorldGUI_Toggle : MonoBehaviour {
    public bool usePlayerPrefs;
    public string playerPrefsValue;
    public UnityEvent OnEnable, OnDisable;
    public SpriteRenderer[] toggleIndicators;
    public Color enabledColor = Color.cyan, disabledColor = Color.black;
    public bool enabled;

    Color currentColor;
    float toggleColorSpeed = 20;
    WorldGUI_Button btn;
    private void Start()
    {
        LoadSaved();
    }
    private void Update()
    {
        if (btn == null)
            btn = GetComponent<WorldGUI_Button>();
        foreach (SpriteRenderer spr in toggleIndicators)
        {
            Color col = Color.Lerp(spr.material.color, currentColor, Time.deltaTime * toggleColorSpeed);
            spr.material.color = col;
            spr.material.SetColor("_EmissionColor", col * btn.emissiveIntensity);
        }
    }
    void ChooseColor()
    {
        if (enabled) currentColor = enabledColor; else currentColor = disabledColor;
    }
    void ChooseToggle()
    {
        if (enabled) OnEnable.Invoke();
        else OnDisable.Invoke();
    }
    public void ToggleAction()
    {
        enabled = !enabled;
        ChooseColor();
        ChooseToggle();
    }
    public void LoadSaved()
    {
        if (usePlayerPrefs)
        {
            if (playerPrefsValue == "graphics_bloom") enabled = PlayerPreferences.instance.GetJsonData().graphics_bloom;
            else if (playerPrefsValue == "graphics_tonemapping") enabled = PlayerPreferences.instance.GetJsonData().graphics_toneMapping;
            else if (playerPrefsValue == "graphics_whitebalance") enabled = PlayerPreferences.instance.GetJsonData().graphics_whiteBalance;
        }
        ChooseToggle();
        ChooseColor();
    }
}
