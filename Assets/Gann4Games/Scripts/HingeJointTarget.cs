using UnityEngine;
public class HingeJointTarget : MonoBehaviour
{
    public HingeJoint hj;
    public Transform target;
    [Tooltip("Only use one of these values at a time. Toggle invert if the rotation is backwards.")]
    public bool x, y, z, invert;
    public Vector3 bloodRotationOffset;
    
    public bool CanBeDismembered { get => _startBreakForce != 0; }

    float _startBreakForce = 0;
    CharacterBodypart _partCollision;
    void Start()
    {
        _partCollision = GetComponent<CharacterBodypart>();

        hj = GetComponent<HingeJoint>();
        //hj.autoConfigureConnectedAnchor = false;
        if (hj.breakForce != Mathf.Infinity) _startBreakForce = hj.breakForce;
    }
    void Update()
    {
        if (hj != null)
        {
            if (hj.breakForce < _startBreakForce)
                hj.breakForce += 10;
            if (x)
            {
                JointSpring js;
                js = hj.spring;

                js.targetPosition = target.transform.localEulerAngles.x;
                if (js.targetPosition > 180)
                    js.targetPosition -= 360;
                if (invert)
                    js.targetPosition *= -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
            else if (y)
            {
                JointSpring js;
                js = hj.spring;
                js.targetPosition = target.transform.localEulerAngles.y;
                if (js.targetPosition > 180)
                    js.targetPosition -= 360;
                if (invert)
                    js.targetPosition *= -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
            else if (z)
            {
                JointSpring js;
                js = hj.spring;
                js.targetPosition = target.transform.localEulerAngles.z;
                if (js.targetPosition > 180)
                    js.targetPosition -= 360;
                if (invert)
                    js.targetPosition *= -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
        }
    }
    private void OnJointBreak()
    {
        _partCollision.character.preset.IndicateDamage(transform.position).Display("Dismembered", Color.red);
        if (_partCollision != null) _partCollision.character.HealthController.DealDamage(_partCollision.character.HealthController.CurrentHealth, Vector3.zero);
        GameObject BleedGO = _partCollision.character.preset.BloodSquirtFX();
        BleedGO.transform.position = transform.position;
        BleedGO.transform.rotation = transform.rotation;
        BleedGO.transform.SetParent(transform);
        BleedGO.transform.Rotate(bloodRotationOffset);
        transform.SetParent(null);
        Destroy(this);
    }
}