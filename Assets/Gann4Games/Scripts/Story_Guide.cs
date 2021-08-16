using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Guide : MonoBehaviour {
    
    public Text StoryGuide;
    static public Color textColor;

    static public string actualMessage;
    private void Update()
    {
        StoryGuide.color = textColor;
        StoryGuide.text = actualMessage;
        textColor.r = 0;
        textColor.g = 155;
        textColor.b = 255;
    }
}
