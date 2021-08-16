using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainHUDHandler : MonoBehaviour {
    public static MainHUDHandler instance;

    public Slider healthbar, energybar;
    [Space]
    [SerializeField] CanvasGroup damageEffectGroup;
    [SerializeField] Image damageEffectImage;

    public float mainAlpha = 0;
    public RectTransform crosshair;
    [HideInInspector] public Image crosshairImage;

    TextMeshProUGUI _healthbarText;
    TextMeshProUGUI _energybarText;
    float _fadeAmount = 1;
    Color _mainColor = Color.black;
    private void Awake()
    {
        instance = this;
        _healthbarText = healthbar.GetComponentInChildren<TextMeshProUGUI>();
        _energybarText = energybar.GetComponentInChildren<TextMeshProUGUI>();
        crosshairImage = crosshair.GetComponent<Image>();
    }
    public void ShowEffect(Color color, float intensity = 1, float fade = 1)
    {
        damageEffectGroup.alpha = intensity;
        damageEffectImage.color = color;
        _fadeAmount = fade;
    }
    private void Update()
    {
        if (damageEffectGroup.alpha != mainAlpha) damageEffectGroup.alpha = Mathf.Lerp(damageEffectGroup.alpha, mainAlpha, Time.deltaTime * _fadeAmount);
        if (damageEffectImage.color != _mainColor) damageEffectImage.color = Color.Lerp(damageEffectImage.color, _mainColor, Time.deltaTime * _fadeAmount);

        HealthbarUpdate();
        EnergybarUpdate();
    }
    void HealthbarUpdate() => _healthbarText.text = string.Format("{0} HP", healthbar.value.ToString("F0"));
    void EnergybarUpdate() => _energybarText.text = string.Format("{0}% Energy", (energybar.value).ToString("F0")); 
}