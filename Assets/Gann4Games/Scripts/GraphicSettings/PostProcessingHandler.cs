using UnityEngine;
using UnityEngine.Rendering.Universal;

// Help source: 'https://forum.unity.com/threads/urp-volume-cs-how-to-access-the-override-settings-at-runtime-via-script.813093/'

public class PostProcessingHandler : MonoBehaviour
{
    public UnityEngine.Rendering.VolumeProfile volumeProfile;
    Bloom bloomFX;
    Tonemapping tonemappingFX;
    WhiteBalance whiteBalanceFX;

    void Awake()
    {
        //volumeProfile = GetComponent<Volume>().profile;
        volumeProfile.TryGet(out bloomFX);
        volumeProfile.TryGet(out tonemappingFX);
        volumeProfile.TryGet(out whiteBalanceFX);
    }
    public void SetBloom(bool active) { bloomFX.active = active; }
    public void SetToneMapping(bool active) { tonemappingFX.active = active; }
    public void SetWhiteBalance(bool active) { whiteBalanceFX.active = active; }

    public void SaveChanges()
    {
        PlayerPreferences.instance.json_structure.graphics_bloom = bloomFX.active;
        PlayerPreferences.instance.json_structure.graphics_toneMapping = tonemappingFX.active;
        PlayerPreferences.instance.json_structure.graphics_whiteBalance = whiteBalanceFX.active;
        PlayerPreferences.instance.RefreshJsonFile();
        NotificationHandler.Notify("Graphics have been changed.");
    }
}
