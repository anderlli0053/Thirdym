using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using Gann4Games.Thirdym.Utility;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.NPC
{
    public class NPC_Ragdoll : MonoBehaviour
    {
        [HideInInspector] public Vector3 targetPoint;

        public StateMachine stateMachine;
        public CharacterCustomization character;
        public Vector3 pointToLookAt;



        [Tooltip("A transform that is used by the head to follow its rotation")]
        public Transform facerTransform;

        [SerializeField] NavMeshAgent navmeshAgent;
        [SerializeField] CharacterCustomization target;

        List<CharacterCustomization> charactersOnScene = new List<CharacterCustomization>();
        List<CharacterCustomization> CharactersOnScene()
        { 
            CharacterCustomization[] characterArray = FindObjectsOfType<CharacterCustomization>();
            List<CharacterCustomization> characterList = new List<CharacterCustomization>();
            for (int i = 0; i < characterArray.Length; i++)
            {
                if (characterArray[i] != character)
                {
                    characterList.Add(characterArray[i]);
                }
            }
            return characterList;
        }

        public void Awake()
        {
            character = GetComponent<CharacterCustomization>();

            character.HealthController.OnDamageDealed += OnDamageDealed;

            charactersOnScene = CharactersOnScene();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.Label(targetPoint, "(Vector3) Target");
            Gizmos.DrawLine(transform.position, targetPoint);
        }
#endif

        private void OnDamageDealed(object sender, CharacterHealthSystem.OnDamageDealedArgs e)
        {
            SetTargetPoint(e.where);
            RagdollBodyLookAt(targetPoint);
            HeadLookAt(targetPoint);
        }
        private void OnDestroy()
        {
            character.HealthController.OnDamageDealed -= OnDamageDealed;
        }


        public bool IsOnSight(Vector3 point)
        {
            Vector3 directionToPoint = point - transform.position;
            float product = Vector3.Dot(character.baseBody.head.forward, directionToPoint.normalized);
            return product > 0.25f;
        }

        /// <summary>
        /// Avoids the Nav agent to go too far from the ragdoll
        /// </summary>
        /// <param name="maximumDistance">Max distance that the nav is able to travel</param>>
        public void ClampNavAgent(float maximumDistance = 3)
        {
            if (Vector3.Distance(navmeshAgent.transform.position, transform.position) > maximumDistance)
                navmeshAgent.transform.position = transform.position;
        }
        public void SelfBalance() => character.RagdollController.AISelfBalance();
        public void GoTo(Vector3 place, float stopDistance = 2)
        {
            navmeshAgent.stoppingDistance = stopDistance;
            navmeshAgent.SetDestination(place);
        }

        /// <summary>
        /// Walks towards the Nav Mesh agent automatically
        /// </summary>
        public void RagdollWalk2Nav() => RagdollWalkTowards(navmeshAgent.transform.position);
        /// <summary>
        /// Walks towards any desired position set
        /// </summary>
        /// <param name="toPoint">The point to walk at</param>
        public void RagdollWalkTowards(Vector3 toPoint, float stopDistance = .5f)
        {
            //Direction to move feet
            Vector3 feetDirection = transform.InverseTransformDirection(transform.position - toPoint);

            // Stop feet movement at desired distance
            if (Vector3.Distance(transform.position, transform.position + feetDirection) < stopDistance) feetDirection = Vector3.zero;

            //Set feet movement on its Y position
            character.Animator.SetFloat("Y", Mathf.Lerp(character.Animator.GetFloat("Y"), -feetDirection.z, Time.deltaTime));
            //Set feet movement on its X position
            character.Animator.SetFloat("X", Mathf.Lerp(character.Animator.GetFloat("X"),
                -feetDirection.x, Time.deltaTime));
        }
        public void RagdollBodyLookAt(Vector3 point2face)
        {
            point2face.y = character.RagdollController.rootBalancer[0].transform.position.y;
            character.RagdollController.rootBalancer[0].transform.LookAt(point2face);
        }
        public void RagdollBodySetRotation(Vector3 rotation) => character.RagdollController.guide.transform.eulerAngles = rotation;
        /// <summary>
        /// Sets the body rotation to be equals as the NavMesh Agent rotation
        /// </summary>
        public void RagdollBody2Nav() => RagdollBodySetRotation(navmeshAgent.transform.eulerAngles);
        public void RagdollBodyLookAtCurrentTarget() => RagdollBodyLookAt(new Vector3(target.transform.position.x, character.RagdollController.guide.transform.position.y, target.transform.position.z));
        /// <summary>
        /// Sets the vector target point
        /// </summary>
        /// <param name="newVector">The new point to set on the vector target</param>
        public void SetTargetPoint(Vector3 newVector) => targetPoint = newVector;
        public void HeadLookAtNav()
        {
            Vector3 navPosition = navmeshAgent.transform.position;
            HeadLookAt(new Vector3(navPosition.x, facerTransform.position.y, navPosition.z));
        }
        public void HeadLookAt(Vector3 point2face) => facerTransform.LookAt(point2face);
        public void Attack() => character.ShootSystem.Shoot();
        /// <summary>
        /// Fires a raycast towards the current target and checks for any specified list of tags
        /// </summary>
        /// <returns>true if any of the tags specified has been found on the target</returns>
        public bool IsFacingAt(Vector3 point, string[] tagList)
        {
            Vector3 rayPos = transform.position + Vector3.up * 0.75f;
            Vector3 direction = (point - new Vector3(0, .25f, 0)) - (rayPos);
            if (Physics.Raycast(rayPos, direction, out RaycastHit hit))
            {
                Debug.DrawLine(rayPos, hit.point, Color.red);
                foreach (string currentTag in tagList)
                {
                    if (hit.transform.CompareTag(currentTag))
                    {
                        Debug.DrawLine(rayPos, hit.point, Color.green);
                        return true;
                    }
                }
                // else kind of part
                Debug.DrawLine(rayPos, hit.point, Color.red);
                return false;
            }
            else return false;
        }
        public CharacterCustomization GetClosestAliveRagdoll(string[] tagList)
        {
            List<CharacterCustomization> ragdollList = new List<CharacterCustomization>();
            foreach (string currentTag in tagList)
            {
                foreach (CharacterCustomization ragdoll in charactersOnScene)
                {
                    if (ragdoll == null)
                    {
                        charactersOnScene.Remove(ragdoll);
                        continue;
                    }
                    if (ragdoll.CompareTag(currentTag))
                    {
                        if (ragdoll.HealthController.IsFullyAlive)
                            ragdollList.Add(ragdoll);
                        else
                            continue;
                    }
                }
            }
            Transform[] ragdollTransforms = GeneralTools.GetTransformsOfArray(ragdollList.ToArray());

            try
            {
                return GeneralTools.GetClosestTransform(transform.position, ragdollTransforms).GetComponent<CharacterCustomization>();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public CharacterCustomization GetClosestDeadRagdoll(string[] tagList)
        {
            List<CharacterCustomization> ragdollList = new List<CharacterCustomization>();
            foreach (string allyTag in tagList)
            {
                foreach (CharacterCustomization corpse in charactersOnScene)
                {
                    if (corpse.CompareTag(allyTag) && !corpse.HealthController.IsFullyAlive)
                        ragdollList.Add(corpse);
                }
            }
            Transform[] ragdollTransforms = GeneralTools.GetTransformsOfArray(ragdollList.ToArray());

            try
            {
                return GeneralTools.GetClosestTransform(transform.position, ragdollTransforms).GetComponent<CharacterCustomization>();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a random place relative to a specified point
        /// </summary>
        /// <param name="referencePoint">The referenced point</param>
        /// <returns>A random point closer to the reference point</returns>
        public Vector3 GetRandomPlaceAround(Vector3 referencePoint, Vector2 range)
        {
            float XRange = Random.Range(0, range.x);
            float X = Random.Range(-XRange, XRange);
            float YRange = Random.Range(0, range.y);
            float Y = Random.Range(-YRange, YRange);

            return referencePoint + new Vector3(X, 0, Y);
        }
        public bool HasActiveTarget => target != null;
        public bool HasArrived => navmeshAgent.remainingDistance <= navmeshAgent.stoppingDistance;
        public PickupableGun[] FindGuns() => FindObjectsOfType<PickupableGun>();
        public PickupableGun FindDefibrilator()
        {
            PickupableGun[] guns = GameObject.FindObjectsOfType<PickupableGun>();
            PickupableGun defibrilatorWorldWeapon = new PickupableGun();
            foreach (PickupableGun gun in guns)
            {
                if (gun.GunType == Weapons.DefibrilatorElectroshock)
                { defibrilatorWorldWeapon = gun; break; }
            }
            return defibrilatorWorldWeapon;
        }
    }
}