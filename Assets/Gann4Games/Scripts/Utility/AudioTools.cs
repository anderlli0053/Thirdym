using UnityEngine;

namespace Gann4Games.Thirdym.Utility
{
    public class AudioTools
    {
        public static AudioClip GetRandomClip(AudioClip[] clips)
        {
            AudioClip clip;
            try { 
                clip = clips[Random.Range(0, clips.Length)]; 
            }
            catch(System.Exception) 
            {
                return null; 
            }

            return clip;
        }
    }
}
