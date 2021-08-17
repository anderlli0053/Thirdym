using UnityEngine;
using UnityEngine.Events;
using Gann4Games.Thirdym.Gann4Web;
public class NotifyUpdates : MonoBehaviour
{
    [SerializeField] UnityEvent onUpdateFound;
    [SerializeField] UnityEvent onServerDown;

    Gann4Web _gameVersionHandler;
    string _lastVersion;
    private void Start() 
    {
        switch(_gameVersionHandler.IsServerDown)
        {
            case false:
                UpdateCheck();
                break;
            case true:
                ServerDown();
                break;
        }
    }
    void UpdateCheck()
    {
        _lastVersion = _gameVersionHandler.GetLastVersion();
        if (Application.version != _lastVersion)
        {
            NotificationHandler.Notify($"Update available! (v{_lastVersion})");
            onUpdateFound.Invoke();
        }
    }
    void ServerDown()
    {
        NotificationHandler.Notify($"Couldn't connect with http://gann4life.ga.");
        onServerDown.Invoke();
    }
}
