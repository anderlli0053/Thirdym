using UnityEngine;

[RequireComponent(typeof(CharacterCustomization))]
public class CharacterPoser : MonoBehaviour
{
    CharacterCustomization _customizator;
    [SerializeField] bool track;
    [SerializeField] Vector3 rootPosition;
    [SerializeField] Quaternion head, body, leftShoulder, leftElbow, leftHand, rightShoulder, rightElbow, rightHand, leftLeg, leftKnee, leftFoot, rightLeg, rightKnee, rightFoot;

    private void Awake() =>  _customizator = GetComponent<CharacterCustomization>();

    private void Update()
    {
        if (track)
        {
            rootPosition = transform.position;
            body = _customizator.baseBody.body.localRotation;
            head = _customizator.baseBody.head.localRotation;
            leftShoulder = _customizator.baseBody.leftShoulder.localRotation;
            leftElbow = _customizator.baseBody.leftElbow.localRotation;
            leftHand = _customizator.baseBody.leftElbow.localRotation;
            rightShoulder = _customizator.baseBody.rightShoulder.localRotation;
            rightElbow = _customizator.baseBody.rightElbow.localRotation;
            rightHand = _customizator.baseBody.rightHand.localRotation;
            leftLeg = _customizator.baseBody.leftLeg.localRotation;
            leftKnee = _customizator.baseBody.leftKnee.localRotation;
            leftFoot = _customizator.baseBody.leftFoot.localRotation;
            rightLeg = _customizator.baseBody.rightLeg.localRotation;
            rightKnee = _customizator.baseBody.rightKnee.localRotation;
            rightFoot = _customizator.baseBody.rightFoot.localRotation;
        }
    }
    public void PoseCharacter()
    {
        transform.position = rootPosition;
        _customizator.baseBody.body.localRotation = body;
        _customizator.baseBody.head.localRotation = head;
        _customizator.baseBody.leftShoulder.localRotation = leftShoulder;
        _customizator.baseBody.leftElbow.localRotation = leftElbow;
        _customizator.baseBody.leftHand.localRotation = leftHand;
        _customizator.baseBody.rightShoulder.localRotation = rightShoulder;
        _customizator.baseBody.rightElbow.localRotation = rightElbow;
        _customizator.baseBody.rightHand.localRotation = rightHand;
        _customizator.baseBody.leftLeg.localRotation = leftLeg;
        _customizator.baseBody.leftKnee.localRotation = leftKnee;
        _customizator.baseBody.leftFoot.localRotation = leftFoot;
        _customizator.baseBody.rightLeg.localRotation = rightLeg;
        _customizator.baseBody.rightKnee.localRotation = rightKnee;
        _customizator.baseBody.rightFoot.localRotation = rightFoot;
    }
}
