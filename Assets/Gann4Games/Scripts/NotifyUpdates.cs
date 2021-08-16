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
        if (!_gameVersionHandler.IsServerDown) UpdateCheck();  
        else ServerDown();
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
