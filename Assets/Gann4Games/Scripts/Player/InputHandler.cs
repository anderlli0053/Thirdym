using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    public GameplayInput gameplayControls;

    [SerializeField] Vector2 cameraSensitivity = Vector2.one*4;

    public Vector2 cameraAxis => gameplayControls.Player.Camera.ReadValue<Vector2>() * Time.deltaTime*cameraSensitivity;
    public Vector2 movementAxis => gameplayControls.Player.Movement.ReadValue<Vector2>();

    public bool aiming => gameplayControls.Player.Aim.ReadValue<float>() > 0;
    public bool firing => gameplayControls.Player.Fire.ReadValue<float>() > 0;
    public bool ability => gameplayControls.Player.Ability.triggered;
    public bool use => gameplayControls.Player.Use.triggered;
    public bool walking => gameplayControls.Player.Walk.ReadValue<float>()>0;
    public bool jumping => gameplayControls.Player.Jump.ReadValue<float>()>0;
    public bool ragdolling => gameplayControls.Player.Ragdoll.ReadValue<float>()>0;
    public bool crouching => gameplayControls.Player.Crouch.ReadValue<float>()>0;
    public bool kicking => gameplayControls.Player.Kick.ReadValue<float>()>0;
    public bool cameraSwitch => gameplayControls.Player.CameraSwitch.triggered;
    public bool pause => gameplayControls.Player.Pause.triggered;

    private void Awake()
    {
        instance = this;
        gameplayControls = new GameplayInput();
    }
    private void OnEnable()=>gameplayControls.Enable();
    private void OnDisable() => gameplayControls.Disable();
}
