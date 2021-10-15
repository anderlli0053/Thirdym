using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gann4Games.Thirdym.Enums;
public enum EquipMode
{
    Pickup, Drop, Equip
}
public class PlayerInventoryHUD : MonoBehaviour {
    static PlayerInventoryHUD instance;

    [Header("Background colors")]
    public Color colorBackgroundEmpty;
    public Color colorBackgroundHave;
    public Color colorBackgroundEquipped;
    [Header("Text colors")]
    public Color colorTextEmpty;
    public Color colorTextHave;
    public Color colorTextEquipped;


    Image[] bgs;
    TextMeshProUGUI[] txts;

    Image _imagePistol, _imageAutomatic, _imageShotgun, _imageEnergy, _imageExplosive, _imageDefibrilator, _imageBlades;
    Color _colorBackgroundPistol, _colorBackgroundAutomatic, _colorBackgroundShotgun, _colorBackgroundEnergy, _colorBackgroundExplosive, 
        _colorBackgroundDefibrilator, _colorBackgroundBlades;

    TextMeshProUGUI _textPistol, _textAutomatic, _textShotgun, _textEnergy, _textExplosive, _textDefibrilator, _textBlades;
    Color _colorTextPistol, _colorTextAutomatic, _colorTextShotgun, _colorTextEnergy, _colorTextExplosive, _colorTextDefibrilator, _colorTextBlades;

    private void Awake()
    {
        instance = this;
        bgs = GetComponentsInChildren<Image>();
        txts = GetComponentsInChildren<TextMeshProUGUI>();

        _imagePistol = bgs[0];
        _imageAutomatic = bgs[1];
        _imageShotgun = bgs[2];
        _imageEnergy = bgs[3];
        _imageExplosive = bgs[4];
        _imageDefibrilator = bgs[5];
        _imageBlades = bgs[6];

        _textPistol = txts[0];
        _textAutomatic = txts[1];
        _textShotgun = txts[2];
        _textEnergy = txts[3];
        _textExplosive = txts[4];
        _textDefibrilator = txts[5];
        _textBlades = txts[6];
    }
    private void Update()
    {
        float lerp = Time.deltaTime * 10;

        _imagePistol.color = Color.Lerp(_imagePistol.color, _colorBackgroundPistol, lerp);
        _imageAutomatic.color = Color.Lerp(_imageAutomatic.color, _colorBackgroundAutomatic, lerp);
        _imageShotgun.color = Color.Lerp(_imageShotgun.color, _colorBackgroundShotgun, lerp);
        _imageEnergy.color = Color.Lerp(_imageEnergy.color, _colorBackgroundEnergy, lerp);
        _imageExplosive.color = Color.Lerp(_imageExplosive.color, _colorBackgroundExplosive, lerp);
        _imageDefibrilator.color = Color.Lerp(_imageDefibrilator.color, _colorBackgroundDefibrilator, lerp);
        _imageBlades.color = Color.Lerp(_imageBlades.color, _colorBackgroundBlades, lerp);

        _textPistol.color = Color.Lerp(_textPistol.color, _colorTextPistol, lerp);
        _textAutomatic.color = Color.Lerp(_textAutomatic.color, _colorTextAutomatic, lerp);
        _textShotgun.color = Color.Lerp(_textShotgun.color, _colorTextShotgun, lerp);
        _textEnergy.color = Color.Lerp(_textEnergy.color, _colorTextEnergy, lerp);
        _textExplosive.color = Color.Lerp(_textExplosive.color, _colorTextExplosive, lerp);
        _textDefibrilator.color = Color.Lerp(_textDefibrilator.color, _colorTextDefibrilator, lerp);
        _textBlades.color = Color.Lerp(_textBlades.color, _colorTextBlades, lerp);
    }
    public static void SetWeapon(WeaponType category, EquipMode mode)
    {
        switch (category)
        {
            case WeaponType.Pistol:
                if (mode == EquipMode.Drop) { 
                    instance._colorBackgroundPistol = instance.colorBackgroundEmpty; 
                    instance._colorTextPistol = instance.colorTextEmpty; 
                }
                else if (mode == EquipMode.Pickup) { 
                    instance._colorBackgroundPistol = instance.colorBackgroundHave; 
                    instance._colorTextPistol = instance.colorTextHave; 
                }
                else if (mode == EquipMode.Equip) { 
                    instance._colorBackgroundPistol = instance.colorBackgroundEquipped; 
                    instance._colorTextPistol = instance.colorTextEquipped; 
                }
                break;

            case WeaponType.Rifle:
                if (mode == EquipMode.Drop) { 
                    instance._colorBackgroundAutomatic = instance.colorBackgroundEmpty; 
                    instance._colorTextAutomatic = instance.colorTextEmpty; 
                }
                else if (mode == EquipMode.Pickup) { 
                    instance._colorBackgroundAutomatic = instance.colorBackgroundHave; 
                    instance._colorTextAutomatic = instance.colorTextHave; 
                }
                else if (mode == EquipMode.Equip) { 
                    instance._colorBackgroundAutomatic = instance.colorBackgroundEquipped; 
                    instance._colorTextAutomatic = instance.colorTextEquipped; 
                }
                break;

            case WeaponType.Shotgun:
                if (mode == EquipMode.Drop) { 
                    instance._colorBackgroundShotgun = instance.colorBackgroundEmpty; 
                    instance._colorTextShotgun = instance.colorTextEmpty; 
                }
                else if (mode == EquipMode.Pickup) { 
                    instance._colorBackgroundShotgun = instance.colorBackgroundHave; 
                    instance._colorTextShotgun = instance.colorTextHave; 
                }
                else if (mode == EquipMode.Equip) { 
                    instance._colorBackgroundShotgun = instance.colorBackgroundEquipped; 
                    instance._colorTextShotgun = instance.colorTextEquipped; 
                }
                break;

            case WeaponType.Heavy:
                if (mode == EquipMode.Drop) {
                    instance._colorBackgroundEnergy = instance.colorBackgroundEmpty;
                    instance._colorTextEnergy = instance.colorTextEmpty;
                }
                else if (mode == EquipMode.Pickup) {
                    instance._colorBackgroundEnergy = instance.colorBackgroundHave;
                    instance._colorTextEnergy = instance.colorTextHave;
                }
                else if (mode == EquipMode.Equip) { 
                    instance._colorBackgroundEnergy = instance.colorBackgroundEquipped; 
                    instance._colorTextEnergy = instance.colorTextEquipped; 
                }
                break;

            case WeaponType.Melee:
                if (mode == EquipMode.Drop) { 
                    instance._colorBackgroundBlades = instance.colorBackgroundEmpty; 
                    instance._colorTextBlades = instance.colorTextEmpty; 
                }
                else if (mode == EquipMode.Pickup) { 
                    instance._colorBackgroundBlades = instance.colorBackgroundHave; 
                    instance._colorTextBlades = instance.colorTextHave; 
                }
                else if (mode == EquipMode.Equip) { 
                    instance._colorBackgroundBlades = instance.colorBackgroundEquipped; 
                    instance._colorTextBlades = instance.colorTextEquipped; 
                }
                break;
        }
    }
}
