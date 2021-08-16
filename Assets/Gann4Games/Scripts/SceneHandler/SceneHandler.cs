using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Gann4Games.Thirdym.SceneHandler
{
    public class SceneHandler : MonoBehaviour
    {
        public static SceneHandler instance;
        static float _screenAlpha;

        [SerializeField] CanvasGroup loadingScreen;

        [SerializeField] Slider progressBar;
        [SerializeField] TextMeshProUGUI hintText;

        [SerializeField] string[] hints;

        bool _showScreen;
        string _levelName;

        AsyncOperation _ao;
        GameplayInput _playerActions;
        TextMeshProUGUI _progressBarText;
        string RandomHint => hints[Random.Range(0, hints.Length - 1)];

        private void Awake()
        {
            instance = this;

            _playerActions = new GameplayInput();
            _progressBarText = progressBar.GetComponentInChildren<TextMeshProUGUI>();
            ShowScreen(false);
        }
        private void OnEnable() => _playerActions.Enable();
        private void OnDisable() => _playerActions.Disable();
        private void Update()
        {
            loadingScreen.alpha = _screenAlpha;
            if (_showScreen && loadingScreen.alpha != 1) _screenAlpha = Mathf.Lerp(_screenAlpha, 1, Time.deltaTime * 10);
            else if (!_showScreen && loadingScreen.alpha != 0) _screenAlpha = Mathf.Lerp(_screenAlpha, 0, Time.deltaTime * 10);
        }
        void ShowScreen(bool value)
        {
            _showScreen = value;
            loadingScreen.blocksRaycasts = value;
        }
        public void LoadScene(string scene)
        {
            _levelName = scene;
            progressBar.value = 0;
            UpdateHintText(RandomHint);
            StartCoroutine(LoadLevelWithRealProgress());
            ShowScreen(true);
        }
        public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        IEnumerator LoadLevelWithRealProgress()
        {
            yield return new WaitForSeconds(0.1f);
            _ao = SceneManager.LoadSceneAsync(_levelName);
            _ao.allowSceneActivation = false;

            while (!_ao.isDone)
            {
                UpdateProgressBar();
                UpdateProgressText();
                if (_ao.progress == 0.9f)
                {
                    OnFinishLoading();
                    if (_playerActions.MainMenu.Submit.triggered)
                    {
                        _ao.allowSceneActivation = true;
                        ShowScreen(false);
                    }
                }
                yield return null;
            }
        }
        void UpdateProgressBar() => progressBar.value = _ao.progress + 0.1f;
        void UpdateProgressText() => _progressBarText.text = string.Format("Loading... {0}%", (int)progressBar.value * 100);
        void UpdateHintText(string text) => hintText.text = text;
        void OnFinishLoading() => _progressBarText.text = "Press a key to continue.";
    }
}