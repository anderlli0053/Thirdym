using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Gann4Games.Thirdym.SceneHandler;

public class IngameMenuHandler : MonoBehaviour
{
    public static IngameMenuHandler instance;

    public bool paused = false;

    [SerializeField] TextMeshProUGUI UIMessageBox;
    [SerializeField] Button UISelectButton;

    [SerializeField] UnityEvent OnPause, OnResume;

    CanvasGroup _canvasVisuals;
    SceneHandler _sceneHandler;
    Button[] _buttonArray;

    float _startFixedDeltaTime;
    private void Start()
    {
        instance = this;
        _sceneHandler = FindObjectOfType<SceneHandler>();

        _canvasVisuals = GetComponentInChildren<CanvasGroup>();
        _canvasVisuals.alpha = paused ? 1 : 0;

        _buttonArray = _canvasVisuals.GetComponentsInChildren<Button>();

        _startFixedDeltaTime = Time.fixedDeltaTime;
    }
    private void Update()
    {
        if (InputHandler.instance.pause) SetPausedStatus(!paused);
        switch (paused)
        {
            case true:
                if (!_canvasVisuals.interactable) _canvasVisuals.interactable = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            case false:
                if (_canvasVisuals.interactable) _canvasVisuals.interactable = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
        Cursor.visible = paused;

        AdjustMenuAlpha();
    }
    public void AdjustTimeScale(float scale)
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
    void AdjustMenuAlpha() => _canvasVisuals.alpha = Mathf.Lerp(_canvasVisuals.alpha, paused ? 1 : 0, 0.1f);
    public void ResetAction() => _sceneHandler.ReloadScene();
    public void QuitAction() => _sceneHandler.LoadScene("Thirdym_MainMenu");
    public void SetPausedStatus(bool pause)
    {
        paused = pause;
        instance.UISelectButton.Select();
        foreach (Button _button in _buttonArray) _button.interactable = paused;
        
        if(paused) OnPause.Invoke();
        else OnResume.Invoke();
    }
    public static void PauseAndShowMessage(string message)
    {
        instance.SetPausedStatus(true);
        instance.UIMessageBox.text = message;
    }
}
