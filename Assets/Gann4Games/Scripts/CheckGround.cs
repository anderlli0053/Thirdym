using System.Collections.Generic;
using UnityEngine;
using Gann4Games.Thirdym.Localization; // a very bad code smell...

public class CheckGround : MonoBehaviour {

    
    public Rigidbody pickupableBody;

    public bool IsDraggingBody => _draggingBody;
    public bool IsGrounded => _grounded;
    public bool IsSwimming => _swimming;
    List<GameObject> objectList = new List<GameObject>();
    CharacterCustomization _character;
    EquipmentSystem _equipmentController;
    ConfigurableJoint _dragJoint;

    bool _grounded;
    bool _swimming;
    bool _draggingBody;

    private void Start()
    {
        _character = transform.parent.GetComponentInChildren<CharacterCustomization>();
        _equipmentController = _character.EquipmentController;
    }
    private void Update()
    {
        if (!_character.isNPC && !_character.HealthController.IsDead)
        {
            if (_draggingBody && pickupableBody != null && _dragJoint == null)
            {
                _dragJoint = pickupableBody.gameObject.AddComponent<ConfigurableJoint>();
                _dragJoint.xMotion = ConfigurableJointMotion.Locked;
                _dragJoint.yMotion = ConfigurableJointMotion.Locked;
                _dragJoint.zMotion = ConfigurableJointMotion.Locked;
                _dragJoint.autoConfigureConnectedAnchor = false;
                _dragJoint.connectedAnchor = Vector3.zero;
                _dragJoint.connectedBody = _equipmentController.IK.GetComponent<Rigidbody>();
            }
            if (InputHandler.instance.gameplayControls.Player.Use.triggered)
            {
                if (!_draggingBody)
                {
                    for (int i = 0; i < objectList.Count; i++)
                    {
                        GameObject obj = objectList[i].gameObject;
                        if (obj == null || objectList[i] == null) objectList.RemoveAt(i);
                        if (obj.HasTag("Pickupable") || obj.CompareTag("Pickupable"))
                        {
                            _equipmentController.DropAction();
                            pickupableBody = objectList[i].GetComponent<Rigidbody>();
                            _draggingBody = true;
                            break;
                        }
                    }
                }
                else
                {
                    StartCoroutine(_equipmentController.Equip(0));
                    Destroy(_dragJoint);
                    objectList = null;
                    objectList = new List<GameObject>();
                    pickupableBody = null;
                    _draggingBody = false;
                }
            }
        }
        if(_character.HealthController.IsDead)
        {
            _grounded = false;
        }
    }
    
    void OnTriggerStay(Collider collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Map":
                _grounded = true;
                break;
            case "Water":
                _swimming = true;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!_character.isNPC) objectList.Add(other.gameObject);

        CharacterBodypart part_collision = other.GetComponent<CharacterBodypart>();
        if(part_collision && !_character.isNPC && other.CompareTag("Pickupable"))
        {
            if (part_collision.character.RagdollController != _character)
            {
                string hint_text = "";
                switch (LanguagePrefs.Language)
                {
                    case AvailableLanguages.English:
                        hint_text = "Press E to grab {0}";
                        break;
                    case AvailableLanguages.Español:
                        hint_text = "Presiona E para agarrar a {0}";
                        break;
                }
                NotificationHandler.Notify(string.Format(hint_text, part_collision.character.preset.character_name), 1, 2, false);
            }
        }
        else if(other.CompareTag("Pickupable") && !part_collision)
        {
            string hint_text = "";
            switch(LanguagePrefs.Language)
            {
                case AvailableLanguages.English:
                    hint_text = "Press E to grab.";
                    break;
                case AvailableLanguages.Español:
                    hint_text = "Presiona E para agarrar.";
                    break;
            }
            NotificationHandler.Notify(hint_text, 3, 2, false);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (!_character.isNPC) objectList.Remove(collision.gameObject);

        switch (collision.gameObject.tag)
        {
            case "Map":
                _grounded = false;
                break;
            case "Water":
                _swimming = false;
                break;
        }
    }
}
