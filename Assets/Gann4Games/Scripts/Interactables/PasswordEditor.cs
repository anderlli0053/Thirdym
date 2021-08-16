using UnityEngine;
using UnityEngine.UI;

namespace Gann4Games.Thirdym.Interactables
{
    public class PasswordEditor : MonoBehaviour
    {
        public string Code;
        public Text UIText;
        public Switch_MovableObject currentSwitch;
        public void AddChar(string character)
        {
            Code += character;
            UIText.text = Code;
        }
        public void ApplyCode()
        {
            currentSwitch.CheckPassword(Code);
        }
        public void ClearCode()
        {
            Code = Code.Remove(Code.Length - 1);
            UIText.text = Code;
        }
    }
}