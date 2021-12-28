// GENERATED AUTOMATICALLY FROM 'Assets/Gann4Games/Input/GameplayInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameplayInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""92985e1d-3188-4265-b8a6-ab73c28c562b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""51dfc02b-ba35-4cc7-b357-d34a92193a4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""e27e747d-18a6-438b-8ab3-85edbd25a9f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""ec5696df-b099-4704-9442-c0936d707b6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""e54959ab-250c-4de7-9194-204f61091689"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Value"",
                    ""id"": ""a4654e96-d10c-4d42-ab26-bba03ef7be13"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""af52557b-533a-4615-871d-ecf0a4b664e9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""767b8050-e5b3-4e82-97f1-3a5d4b2e58b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Ragdoll"",
                    ""type"": ""Value"",
                    ""id"": ""7368e401-ab8b-4777-9cf2-98e17d14d499"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""0c2ef7df-94a1-4d77-a43c-ae5746993c99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""a1e43d2f-5c70-45e2-8a1a-43eb15c8b0de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0d54004a-1f63-4056-91fd-aa170feeefcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Greanade"",
                    ""type"": ""Button"",
                    ""id"": ""bdf59116-d74f-43ce-967d-39783b8989c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""953da32e-b1f1-4de4-9265-58d38280c189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""gun_pistol"",
                    ""type"": ""Button"",
                    ""id"": ""2d2d5667-14d3-420b-848a-f249bf7711a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_rifle"",
                    ""type"": ""Button"",
                    ""id"": ""74e23f7b-a6e0-4ee3-89b1-ef93fee8b2ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_shotgun"",
                    ""type"": ""Button"",
                    ""id"": ""91768015-ba43-45c0-876a-6e983f28fa56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_energy"",
                    ""type"": ""Button"",
                    ""id"": ""d3900f07-0a02-4092-852b-125ed3af9851"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_explosive"",
                    ""type"": ""Button"",
                    ""id"": ""cb134100-6f2f-47ff-9c95-50f573569c70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_defibrilator"",
                    ""type"": ""Button"",
                    ""id"": ""d7445f5e-0e9c-456e-b278-5da9138aaba1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_blades"",
                    ""type"": ""Button"",
                    ""id"": ""bd570c56-6ec3-4f0c-bd46-91b35720c865"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""gun_next"",
                    ""type"": ""Button"",
                    ""id"": ""e129c5ad-39ea-4fb7-a29c-f3fcb90fdb73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""gun_previous"",
                    ""type"": ""Button"",
                    ""id"": ""2205349a-7e45-4e3c-a0b7-8027577eb8c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""gun_scroll"",
                    ""type"": ""Value"",
                    ""id"": ""804eab95-4cda-4ec3-8510-6c6666b23068"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""6315dfe9-b67a-41fc-92e4-af5cff0f810f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""6fcd908d-9872-42d5-9f2b-f68c8b6ff20c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c6711baa-da0d-4de7-ad18-9ce923e1a52d"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09cac2bc-94c7-4764-b60d-40d981d08470"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d069f79-678d-479d-ad11-dbb9452258c6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc85e1d0-5afa-4889-a3ef-01dd2e2df42d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CameraSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""34eb0c03-65ee-4599-a83f-4cccf6c6ae36"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c27ffbca-a5df-42d6-aa72-361d0adc97fd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""34cd06e6-be18-4d1a-86a4-155a0aa1122e"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""f1f9e420-5935-417e-bcd9-d6c4b2266ed3"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""544c754d-e5de-403d-abd7-550c04c256c4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3d661ee2-2e11-4335-be60-367a2ddb5b4d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ragdoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""23eb9ccd-5628-455e-a983-7996fd8276aa"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d75c2656-cc49-4888-a034-c6a9fbc426ed"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db0d1a45-f4c9-4abb-8a0a-efecbda0bb22"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2da50403-22df-41ca-8f54-8500dcc4dac2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e184bd62-8074-4f0a-91e7-d1d3e454bb15"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7398a927-9f43-4261-930d-b8ec873fd262"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c5969e1-5ecd-4817-a65b-a580ae97af1d"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Greanade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72b4ef2e-5d12-452f-a6a8-38548751c4d3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Greanade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e853f46e-1d6e-490a-94c3-24677994fd00"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ab019e3e-fc1b-434a-bec8-712337c97f3f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0e84bf9b-e963-4b34-93c3-abb7dd6e6162"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""402c00f4-7a9b-401d-8e5e-e19cc5303678"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2f5cdd51-b2aa-4566-94cb-cf97538a73e8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""02c18040-ca3d-4fd3-9161-05bce2e58cbf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19aefd6d-0a53-4d2b-bb9b-c4f16aec8ec0"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d799751-08f4-4698-9adc-70b11e99f76a"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89fd8e4d-86e4-41dd-93dc-a6ae41e5c329"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1)"",
                    ""groups"": ""Controller"",
                    ""action"": ""gun_next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b052f88a-e704-439c-a33b-ce6309173258"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1)"",
                    ""groups"": ""Controller"",
                    ""action"": ""gun_previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6413f0c-4aaf-43f1-a3dd-b8841bd9d2ae"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""657baea1-c584-40ee-8a1b-5fe7fa05fd39"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_pistol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db58a663-fe8c-42be-a680-4c01ab50cf68"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_rifle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""289aa1e3-188d-47d9-a318-41543ff455aa"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_blades"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9e79d47-6eb9-4949-a6c5-17ca2180e6ec"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_defibrilator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9d61b5e-6d2d-4167-a617-6c47d5571054"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_explosive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3d5c844-b184-4169-b383-ae63bcdbbb34"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_energy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fe493b8-a696-46e4-a425-7e1a515c8c4f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""gun_shotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ae4438a1-51f7-44c9-b7c2-549070a80184"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""907864f1-d7d0-4593-8b40-05fe11e95356"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e58415df-48ee-473b-bb12-2623bc07aa5d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""b568b7db-dd15-4080-be4c-619bd9d991bc"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7814b696-b103-434f-9f09-97e646c912fa"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""37e81dd1-7766-4ac7-bca1-4c14550ac29e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9c41f656-9b8d-4199-8138-9534bf5b0c14"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c24725d9-79ef-4c7d-961e-db44e772046b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""db6e15e3-33fe-44c2-9f63-867c57ba6c6d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a416899-d126-46d3-81bc-e8d2d9a600dc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fba6b57d-e5d3-441a-ac2b-10c88f3947ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e3e68425-b94d-4f68-8a04-80a81b85b069"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15507d99-8e48-4724-8b20-5d0571a36008"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""621d3ee1-654d-4fc8-ac1c-36f8b787a3ec"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=10,y=10)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6f8b64d5-0788-4194-9483-9eaf093872d7"",
                    ""path"": ""1DAxis(minValue=0,whichSideWins=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7e6d08e5-2511-4b9e-b79a-e46460b4f12c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""da84f203-fca7-4667-873d-6dac0992dc81"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3bdabcde-6323-48df-9b7d-a68f79f06011"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b97bb41-b8e9-47dd-b808-9c2f3edd7dd3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d934407a-dd8b-42af-b203-b2337c15a0c1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e066c99b-b7dd-4281-88df-9bc0d0d124f9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""022e345b-2571-4a53-b989-58e91dcb8697"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""0e0460bf-df8e-4e4b-b50e-e558c76f926e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""35896311-62cf-4c67-ad82-42c0b0274232"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0d80e7b-222c-47f8-80f7-ce11aa01c3f8"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51ecb280-3fb8-420f-9fcd-3b8de4b812b7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7b69ad2-8046-495f-84fc-f0717353e86c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.25,y=0.25)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9be9dfa-70cb-4738-8632-8b1c398dbc71"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_Ability = m_Player.FindAction("Ability", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_CameraSwitch = m_Player.FindAction("CameraSwitch", throwIfNotFound: true);
        m_Player_Ragdoll = m_Player.FindAction("Ragdoll", throwIfNotFound: true);
        m_Player_DropItem = m_Player.FindAction("DropItem", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Greanade = m_Player.FindAction("Greanade", throwIfNotFound: true);
        m_Player_Kick = m_Player.FindAction("Kick", throwIfNotFound: true);
        m_Player_gun_pistol = m_Player.FindAction("gun_pistol", throwIfNotFound: true);
        m_Player_gun_rifle = m_Player.FindAction("gun_rifle", throwIfNotFound: true);
        m_Player_gun_shotgun = m_Player.FindAction("gun_shotgun", throwIfNotFound: true);
        m_Player_gun_energy = m_Player.FindAction("gun_energy", throwIfNotFound: true);
        m_Player_gun_explosive = m_Player.FindAction("gun_explosive", throwIfNotFound: true);
        m_Player_gun_defibrilator = m_Player.FindAction("gun_defibrilator", throwIfNotFound: true);
        m_Player_gun_blades = m_Player.FindAction("gun_blades", throwIfNotFound: true);
        m_Player_gun_next = m_Player.FindAction("gun_next", throwIfNotFound: true);
        m_Player_gun_previous = m_Player.FindAction("gun_previous", throwIfNotFound: true);
        m_Player_gun_scroll = m_Player.FindAction("gun_scroll", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Submit = m_MainMenu.FindAction("Submit", throwIfNotFound: true);
        m_MainMenu_Camera = m_MainMenu.FindAction("Camera", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_Ability;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_CameraSwitch;
    private readonly InputAction m_Player_Ragdoll;
    private readonly InputAction m_Player_DropItem;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Greanade;
    private readonly InputAction m_Player_Kick;
    private readonly InputAction m_Player_gun_pistol;
    private readonly InputAction m_Player_gun_rifle;
    private readonly InputAction m_Player_gun_shotgun;
    private readonly InputAction m_Player_gun_energy;
    private readonly InputAction m_Player_gun_explosive;
    private readonly InputAction m_Player_gun_defibrilator;
    private readonly InputAction m_Player_gun_blades;
    private readonly InputAction m_Player_gun_next;
    private readonly InputAction m_Player_gun_previous;
    private readonly InputAction m_Player_gun_scroll;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Aim;
    public struct PlayerActions
    {
        private @GameplayInput m_Wrapper;
        public PlayerActions(@GameplayInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @Ability => m_Wrapper.m_Player_Ability;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @CameraSwitch => m_Wrapper.m_Player_CameraSwitch;
        public InputAction @Ragdoll => m_Wrapper.m_Player_Ragdoll;
        public InputAction @DropItem => m_Wrapper.m_Player_DropItem;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Greanade => m_Wrapper.m_Player_Greanade;
        public InputAction @Kick => m_Wrapper.m_Player_Kick;
        public InputAction @gun_pistol => m_Wrapper.m_Player_gun_pistol;
        public InputAction @gun_rifle => m_Wrapper.m_Player_gun_rifle;
        public InputAction @gun_shotgun => m_Wrapper.m_Player_gun_shotgun;
        public InputAction @gun_energy => m_Wrapper.m_Player_gun_energy;
        public InputAction @gun_explosive => m_Wrapper.m_Player_gun_explosive;
        public InputAction @gun_defibrilator => m_Wrapper.m_Player_gun_defibrilator;
        public InputAction @gun_blades => m_Wrapper.m_Player_gun_blades;
        public InputAction @gun_next => m_Wrapper.m_Player_gun_next;
        public InputAction @gun_previous => m_Wrapper.m_Player_gun_previous;
        public InputAction @gun_scroll => m_Wrapper.m_Player_gun_scroll;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Ability.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbility;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @CameraSwitch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @CameraSwitch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @CameraSwitch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraSwitch;
                @Ragdoll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @Ragdoll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @Ragdoll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRagdoll;
                @DropItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Greanade.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreanade;
                @Greanade.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreanade;
                @Greanade.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGreanade;
                @Kick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @gun_pistol.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_pistol;
                @gun_pistol.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_pistol;
                @gun_pistol.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_pistol;
                @gun_rifle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_rifle;
                @gun_rifle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_rifle;
                @gun_rifle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_rifle;
                @gun_shotgun.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_shotgun;
                @gun_shotgun.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_shotgun;
                @gun_shotgun.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_shotgun;
                @gun_energy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_energy;
                @gun_energy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_energy;
                @gun_energy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_energy;
                @gun_explosive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_explosive;
                @gun_explosive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_explosive;
                @gun_explosive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_explosive;
                @gun_defibrilator.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_defibrilator;
                @gun_defibrilator.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_defibrilator;
                @gun_defibrilator.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_defibrilator;
                @gun_blades.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_blades;
                @gun_blades.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_blades;
                @gun_blades.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_blades;
                @gun_next.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_next;
                @gun_next.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_next;
                @gun_next.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_next;
                @gun_previous.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_previous;
                @gun_previous.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_previous;
                @gun_previous.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_previous;
                @gun_scroll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_scroll;
                @gun_scroll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_scroll;
                @gun_scroll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGun_scroll;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @CameraSwitch.started += instance.OnCameraSwitch;
                @CameraSwitch.performed += instance.OnCameraSwitch;
                @CameraSwitch.canceled += instance.OnCameraSwitch;
                @Ragdoll.started += instance.OnRagdoll;
                @Ragdoll.performed += instance.OnRagdoll;
                @Ragdoll.canceled += instance.OnRagdoll;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Greanade.started += instance.OnGreanade;
                @Greanade.performed += instance.OnGreanade;
                @Greanade.canceled += instance.OnGreanade;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @gun_pistol.started += instance.OnGun_pistol;
                @gun_pistol.performed += instance.OnGun_pistol;
                @gun_pistol.canceled += instance.OnGun_pistol;
                @gun_rifle.started += instance.OnGun_rifle;
                @gun_rifle.performed += instance.OnGun_rifle;
                @gun_rifle.canceled += instance.OnGun_rifle;
                @gun_shotgun.started += instance.OnGun_shotgun;
                @gun_shotgun.performed += instance.OnGun_shotgun;
                @gun_shotgun.canceled += instance.OnGun_shotgun;
                @gun_energy.started += instance.OnGun_energy;
                @gun_energy.performed += instance.OnGun_energy;
                @gun_energy.canceled += instance.OnGun_energy;
                @gun_explosive.started += instance.OnGun_explosive;
                @gun_explosive.performed += instance.OnGun_explosive;
                @gun_explosive.canceled += instance.OnGun_explosive;
                @gun_defibrilator.started += instance.OnGun_defibrilator;
                @gun_defibrilator.performed += instance.OnGun_defibrilator;
                @gun_defibrilator.canceled += instance.OnGun_defibrilator;
                @gun_blades.started += instance.OnGun_blades;
                @gun_blades.performed += instance.OnGun_blades;
                @gun_blades.canceled += instance.OnGun_blades;
                @gun_next.started += instance.OnGun_next;
                @gun_next.performed += instance.OnGun_next;
                @gun_next.canceled += instance.OnGun_next;
                @gun_previous.started += instance.OnGun_previous;
                @gun_previous.performed += instance.OnGun_previous;
                @gun_previous.canceled += instance.OnGun_previous;
                @gun_scroll.started += instance.OnGun_scroll;
                @gun_scroll.performed += instance.OnGun_scroll;
                @gun_scroll.canceled += instance.OnGun_scroll;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Submit;
    private readonly InputAction m_MainMenu_Camera;
    public struct MainMenuActions
    {
        private @GameplayInput m_Wrapper;
        public MainMenuActions(@GameplayInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_MainMenu_Submit;
        public InputAction @Camera => m_Wrapper.m_MainMenu_Camera;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Camera.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnCameraSwitch(InputAction.CallbackContext context);
        void OnRagdoll(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnGreanade(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnGun_pistol(InputAction.CallbackContext context);
        void OnGun_rifle(InputAction.CallbackContext context);
        void OnGun_shotgun(InputAction.CallbackContext context);
        void OnGun_energy(InputAction.CallbackContext context);
        void OnGun_explosive(InputAction.CallbackContext context);
        void OnGun_defibrilator(InputAction.CallbackContext context);
        void OnGun_blades(InputAction.CallbackContext context);
        void OnGun_next(InputAction.CallbackContext context);
        void OnGun_previous(InputAction.CallbackContext context);
        void OnGun_scroll(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
}
