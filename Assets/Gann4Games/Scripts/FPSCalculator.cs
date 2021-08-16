using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCalculator : MonoBehaviour {

    float fps;
    Text txt;
    private void Start()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        txt.text = "FPS: " + fps.ToString("F0");
        CalculateFPS();
        if (fps >= 60)
            txt.color = Color.green;
        else if (fps > 30 && fps < 60)
            txt.color = Color.white;
        else if (fps < 30)
            txt.color = Color.red;
    }
    public void CalculateFPS()
    {
        fps = 1 / Time.deltaTime;
    }
}
