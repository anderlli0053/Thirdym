
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

    public float positionLerpSpeed = 1, lookatLerpSpeed = 4;

    Vector3 startPos;
    float Xpos, Ypos;
    Vector3 smoothLookatPoint;

    private void Start()
    {
        startPos = transform.position;
        smoothLookatPoint = new Vector3(Xpos, Ypos, 0);
    }
    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(Xpos, Ypos, startPos.z), Time.deltaTime*positionLerpSpeed);
        smoothLookatPoint = Vector3.Lerp(smoothLookatPoint, new Vector3(Xpos, Ypos, 0), Time.deltaTime * lookatLerpSpeed);
        transform.LookAt(smoothLookatPoint);
    }
    public void SetXPos(float pos)
    {
        Xpos = pos;
    }
    public void SetYPos(float pos)
    {
        Ypos = pos;
    }
    public void AddXPos(float pos)
    {
        Xpos += pos;
    }
    public void AddYPos(float pos)
    {
        Ypos += pos;
    }
    public void MoveAtTransform(Transform obj)
    {
        Xpos = obj.position.x;
        Ypos = obj.position.y;
    }
}
