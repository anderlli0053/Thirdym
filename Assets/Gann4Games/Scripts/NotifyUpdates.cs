using UnityEngine;
using UnityEngine.Events;

namespace Gann4Games.Thirdym
{
    public class NotifyUpdates : MonoBehaviour
    {
        [SerializeField] UnityEvent onUpdateFound;

        readonly ThirdymAPI _gameAPI = new ThirdymAPI();

        private void Start() 
        {
            StartCoroutine(_gameAPI.InitializeRequest());
            _gameAPI.OnRequestFinished += CheckForUpdates;
        }

        void CheckForUpdates(object sender, System.EventArgs args)
        {
            if (_gameAPI.IsUpToDate) return;

            NotificationHandler.Notify($"Update available! (v{_gameAPI.LastVersion})");
            onUpdateFound.Invoke();
        }
    }
}
