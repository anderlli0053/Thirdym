using UnityEngine;
using Gann4Games.Thirdym.Utility;
public class LiquidSplash : MonoBehaviour
{
    public float waterLevel;
    [SerializeField] AudioClip[] soundEffects;
    AudioSource _audio;
    private void Awake() {
        _audio = GetComponent<AudioSource>();
        _audio.PlayOneShot(AudioTools.GetRandomClip(soundEffects));
    }
    private void Update()
    {
        if (transform.position.y > waterLevel) Destroy(gameObject);
    }
}
