namespace Gann4Games.Thirdym.Enums
{
    public enum CharacterSkills 
    { 
        None, 
        Slowmotion, 
        Sprint 
    }
    public enum SwitchMode
    {
        Switch_Set,
        Switch_Toggle,
        Trigger_Enter,
        Trigger_Exit,
        Trigger_EnterExit,
        Trigger_Enter_Toggle,
        Trigger_Exit_Toggle,
        Spawn_Prefab,
    }
    public enum Weapons
    {
        PistolC01p,
        PistolCSPro,
        RifleC01r,
        RifleC02m,
        RifleCSRC,
        RifleAlien,
        ShotgunCSDAZ,
        EnergyHeavyRailgun,
        EnergyCSBNG,
        DefibrilatorElectroshock
    }
    public enum WeaponCategory
    {
        Pistol, 
        Automatic, 
        Shotgun, 
        EnergyBased, 
        Explosives, 
        Defibrilator, 
        Melee
    }
    public enum VehicleType
    {
        Mobile,
        Walker,
        Ship
    }
    public enum CameraMode
    {
        Player,
        FlyCam,
        ButtonSwitch,
        Vehicle
    }
}
