using UnityEngine;

namespace Gann4Games.Thirdym.Utility
{
    public class TimerTool
    {
        float _timeOut;
        public float currentTime;
        public void CountTime() 
        {
            if(!IsTimeOut())
                currentTime += Time.deltaTime;
        }
        public void ResetTime() => currentTime = 0; 
        public void SetTimeOut(float newTimeOut) => _timeOut = newTimeOut;
        public bool IsTimeOut() => currentTime > _timeOut;
    }
}
