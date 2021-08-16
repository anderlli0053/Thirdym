using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFKDetector : MonoBehaviour {
    RagdollController ragdoll;
    CharacterArms arms;
    EquipmentSystem equipment;
    public float checkTime;
    bool afk = false;
    int TimesAFK;
    private void Start()
    {
        InvokeRepeating("checkPlayerState", checkTime, checkTime);

        ragdoll = GetComponent<RagdollController>();
        arms = GetComponent<CharacterArms>();
        equipment = GetComponent<EquipmentSystem>();
    }
    private void Update()
    {
        if (afk)
        {
            if (!UnityEngine.InputSystem.Keyboard.current.anyKey.isPressed)
            {
                afk = false;
                TimesAFK = 0;
            }
        }
        if (TimesAFK >= 4)
        {
            ragdoll.RagdollMode(false, true);
            arms.LeftShoulder[0].useSpring = false;
            arms.LeftShoulder[1].useSpring = false;
            arms.LeftBicep.useSpring = false;
            arms.LeftElbow.useSpring = false;
            arms.RightShoulder[0].useSpring = false;
            arms.RightShoulder[1].useSpring = false;
            arms.RightBicep.useSpring = false;
            arms.RightElbow.useSpring = false;
        }
    }
    public void checkPlayerState()
    {
        if (UnityEngine.InputSystem.Keyboard.current.anyKey.isPressed)
        {
            afk = false;
            TimesAFK = 0;
        }
        else
        {
            afk = true;
            TimesAFK++;
        }
    }
}
