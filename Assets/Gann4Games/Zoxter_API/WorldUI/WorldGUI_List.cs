using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
[System.Serializable]
public class ButtonConfiguration {
    public string buttonText;
    public UnityEvent buttonEvent;
    public GameObject buttonPrefab;
}
public class WorldGUI_List : MonoBehaviour {
    public float LerpSpeed = 10;
    public float Spacing = 10;
    public ButtonConfiguration[] buttons;
    public List<Transform> spawnedButtons;
    bool open;
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            GameObject newButton = Instantiate(buttons[i].buttonPrefab, transform.position + Vector3.forward*2, transform.rotation);
            WorldGUI_Button buttonScript = newButton.GetComponent<WorldGUI_Button>();

            newButton.GetComponent<SpriteRenderer>().size = new Vector2(23, newButton.GetComponent<SpriteRenderer>().size.y);

            buttonScript.GetComponentInChildren<TextMeshPro>().text = buttons[i].buttonText;
            buttonScript.OnClick = buttons[i].buttonEvent;
            spawnedButtons.Add(newButton.transform);
        }
    }
    private void Update()
    {
        for(int i = 0; i < spawnedButtons.Count; i++)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - i * (open==true ? Spacing : 0) - (open==true ? Spacing : 0), transform.position.z+2);
            spawnedButtons[i].position = Vector3.Lerp(spawnedButtons[i].position, pos, Time.deltaTime*LerpSpeed);
        }
    }
    public void OpenList()
    {
        open = !open;
    }
}
