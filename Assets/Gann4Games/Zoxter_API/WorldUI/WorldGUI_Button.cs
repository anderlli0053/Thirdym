using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class WorldGUI_Button : MonoBehaviour {

    SpriteRenderer spr;
    Color choosenColor;
    float colorLerpSpeed = 30;
    bool mouseOver;

    public AudioClip hoverSFX, clickSFX, releaseSFX;
    public float emissiveIntensity = 1.5f;
    public bool interactable = true;
    public Color normalColor = Color.white, highlightColor = Color.red, clickColor = Color.green;
    public UnityEvent OnClick, OnMouseHover;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        choosenColor = normalColor;
    }
    private void Update()
    {
        if (!Application.isPlaying)
            choosenColor = normalColor;
        else
        {
            spr.material.color = Color.Lerp(spr.material.color, choosenColor, Time.deltaTime * colorLerpSpeed);
            //spr.material.SetColor("_EmissionColor", spr.material.color/* *emissiveIntensity */);
        }
        if (spr.color != choosenColor)
        {
            spr.color = Color.Lerp(spr.color, choosenColor, Time.deltaTime * colorLerpSpeed);
        }
    }
    private void OnMouseDown()
    {
        if (interactable)
        {
            choosenColor = clickColor;
            Zoxter_API.PlaySound(clickSFX);
        }
    }
    private void OnMouseUp()
    {
        if (interactable && mouseOver)
        {
            choosenColor = highlightColor;
            Zoxter_API.PlaySound(releaseSFX);
            OnClick.Invoke();
        }
    }
    private void OnMouseExit()
    {
        if (interactable)
        {
            mouseOver = false;
            choosenColor = normalColor;
        }
    }
    public void OnMouseEnter()
    {
        if (interactable)
        {
            mouseOver = true;
            choosenColor = highlightColor;
            OnMouseHover.Invoke();
            Zoxter_API.PlaySound(hoverSFX);
        }
    }
    public void SetInteractable(bool value) => interactable = value;
}
