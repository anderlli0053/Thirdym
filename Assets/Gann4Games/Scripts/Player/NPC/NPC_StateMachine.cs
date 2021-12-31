using System;
using UnityEngine;
using Gann4Games.Thirdym.Utility;

namespace Gann4Games.Thirdym.NPC
{
    public class NPC_StateMachine : MonoBehaviour
    {
        public enum NPCState
        {
            Idle,
            Alert,
            Attacking,
            LookingForWeapons,
            Dead,
        }
        public NPCState NPCStatus;
        public NPC_Ragdoll NPC;

        TimerTool _timer;
        CharacterCustomization _closestEnemy => NPC.GetClosestAliveRagdoll(NPC.character.preset.enemyTags);
        CharacterCustomization _closestAlly => NPC.GetClosestAliveRagdoll(NPC.character.preset.allyTags);
        PickupableWeapon _closestWeapon => NPC.GetClosestWeapon();

        void Awake()
        {
            _timer = new TimerTool();
        }
        public void RunStateMachine()
        {
            /*
             * An NPC can't go into attack mode directly.
             * An NPC will analyze a player before attacking, this action takes two seconds.
             * Once the enemy is identified, the attack state will begin.
             *      Once the enemy is beaten, the idle state will begin.
             *      
             * [Idle] <> [Alert]
             *   ^           v
             *   |_____ [Attacking]
             */

            switch(NPCStatus)
            {
                case NPCState.Idle:
                    if (_timer.GeTimeOut != 3) _timer.SetTimeOut(3);

                    if (_timer.IsTimeOut())
                    {
                        _timer.ResetTime();
                        NPC.HeadLookAt(NPC.GetRandomPlaceAround(NPC.transform.position, Vector2.one * 10));
                    } 
                    else _timer.CountTime();

                    NPC.SelfBalance();
                    NPC.character.Animator.SetFloat("X", 0);
                    NPC.character.Animator.SetFloat("Y", 0);

                    if (NPC.IsOnSight(_closestEnemy.transform.position))
                    {
                        // [Idle] >> Alert
                        NPCStatus = NPCState.Alert;
                        break;
                    }
                    // [Idle] >> Idle (Loop)
                    break;

                case NPCState.Alert:
                    // Idle >> [Alert]. | ALWAYS from Idle.
                    if(_timer.GeTimeOut != 2) _timer.SetTimeOut(2);


                    if (_timer.IsTimeOut())
                    {
                        _timer.ResetTime();
                        if (NPC.character.EquipmentController.currentWeapon == null)
                        {
                            // [Alert] >> LookingForWeapons
                            NPCStatus = NPCState.LookingForWeapons;
                            return;
                        }
                        else
                        {
                            // [Alert] >> Attacking
                            NPCStatus = NPCState.Attacking;
                            return;
                        }
                    }
                    else
                    {
                        _timer.CountTime();
                        if (NPC.IsOnSight(_closestEnemy.transform.position))
                        {
                            NPC.HeadLookAt(_closestEnemy.baseBody.head.position);
                            NPC.RagdollWalk2Nav();
                            NPC.RagdollBodyLookAt(_closestEnemy.transform.position);
                            NPC.GoTo(_closestEnemy.transform.position);
                        }
                    }
                    break;

                case NPCState.Attacking:
                    if (NPC.IsOnSight(_closestEnemy.transform.position))
                    {
                        NPC.character.Animator.SetBool("WeaponAiming", true);
                        NPC.character.ArmController.AimWeapon(true);
                        NPC.character.ArmController.RightHandLookAt(_closestEnemy.transform.position);
                        NPC.HeadLookAt(_closestEnemy.baseBody.head.position);
                        NPC.RagdollWalk2Nav();
                        NPC.RagdollBodyLookAt(_closestEnemy.transform.position);
                        NPC.GoTo(_closestEnemy.transform.position);
                        NPC.character.ShootSystem.ShootAsNPC();
                    } 
                    else
                    {
                        // [Attacking] >> Idle
                        NPC.character.Animator.SetBool("WeaponAiming", false);
                        NPCStatus = NPCState.Idle;
                        break;
                    }
                    break;
                case NPCState.LookingForWeapons:
                    // Alert >> [LookingForWeapons]
                    
                    EquipAWeapon();

                    // Idle << [LookingForWeapons]
                    NPCStatus = NPCState.Idle;
                    break;
            }
        }
        void EquipAWeapon()
        {
            if (NPC.character.EquipmentController.HasWeapon(Enums.WeaponType.Pistol))
            {
                NPC.character.EquipmentController.EquipWeapon(Enums.WeaponType.Pistol);
                return;
            }
            if (NPC.character.EquipmentController.HasWeapon(Enums.WeaponType.Rifle))
            {
                NPC.character.EquipmentController.EquipWeapon(Enums.WeaponType.Shotgun);
                return;
            }
            if (NPC.character.EquipmentController.HasWeapon(Enums.WeaponType.Shotgun))
            {
                NPC.character.EquipmentController.EquipWeapon(Enums.WeaponType.Shotgun);
                return;
            }
            if (NPC.character.EquipmentController.HasWeapon(Enums.WeaponType.Heavy))
            {
                NPC.character.EquipmentController.EquipWeapon(Enums.WeaponType.Heavy);
                return;
            }
            if (NPC.character.EquipmentController.HasWeapon(Enums.WeaponType.Melee))
            {
                NPC.character.EquipmentController.EquipWeapon(Enums.WeaponType.Melee);
                return;
            }
        }
    }
}
