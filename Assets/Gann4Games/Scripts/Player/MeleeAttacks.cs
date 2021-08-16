using System.Collections.Generic;
using UnityEngine;
using Gann4Games.Thirdym.Utility;

public class MeleeAttacks : MonoBehaviour {
    public CharacterCustomization character;
    public GameObject impactPrefab;
    [Space]
    [Tooltip("The amount of time it takes to blades to disable the collider component.")]
    [SerializeField] float bladeDuration = 0.5f;
    [SerializeField] BoxCollider leftPsiBlade, rightPsiBlade;
    [SerializeField] AudioClip[] bladeSfx;
    
    readonly List<CharacterBlade> _blades = new List<CharacterBlade>();

    float kickCurrentTime;
    float kickDuration;

    float leftSliceCurrentTime;

    float rightSliceCurrentTime;

    private void Awake()
    {
        leftSliceCurrentTime = bladeDuration;
        rightSliceCurrentTime = bladeDuration;
        _blades.Add(leftPsiBlade.GetComponent<CharacterBlade>());
        _blades.Add(rightPsiBlade.GetComponent<CharacterBlade>());
        for(int i = 0; i < _blades.Count; i++)
        {
            _blades[i].character = character;
            _blades[i].impactPrefab = impactPrefab;
        }
    }

    private void Update()
    {
        if (!character.HealthController.IsDead)
        {
            if (kickCurrentTime < kickDuration)
                Kick();

            if (leftSliceCurrentTime < bladeDuration)
            {
                leftSliceCurrentTime += Time.deltaTime;
                leftPsiBlade.enabled = true;
            }
            else
                leftPsiBlade.enabled = false;

            if (rightSliceCurrentTime < bladeDuration)
            {
                rightSliceCurrentTime += Time.deltaTime;
                rightPsiBlade.enabled = true;
            }
            else
                rightPsiBlade.enabled = false;
        }
    }
    void PerfomKick(float duration)
    {
        kickCurrentTime = 0;
        kickDuration = duration;
    }
    void PerfomLeftSlice()
    {
        leftSliceCurrentTime = 0;
        character.SoundSource.PlayOneShot(AudioTools.GetRandomClip(bladeSfx));
    }
    void PerfomRightSlice()
    {
        rightSliceCurrentTime = 0;
        character.SoundSource.PlayOneShot(AudioTools.GetRandomClip(bladeSfx));
    }
    void Kick()
    {
        kickCurrentTime += Time.deltaTime;
        Transform leftFoot = character.baseBody.leftFoot;

        if (Physics.Raycast(leftFoot.position, leftFoot.forward, out RaycastHit hit))
        {
            float dist = 0.25f;
            Debug.DrawLine(leftFoot.position + leftFoot.TransformDirection(Vector3.forward * dist), leftFoot.position + leftFoot.TransformDirection(new Vector3(0, dist, dist)));
            if (hit.distance < dist)
            {
                Debug.DrawLine(leftFoot.position, hit.point, Color.green);
                GameObject prefab = Instantiate(impactPrefab);
                prefab.transform.position = hit.point;
                hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(leftFoot.forward * 100000 * Time.deltaTime);
                kickCurrentTime = kickDuration+Time.deltaTime;
            }
            else
                Debug.DrawLine(leftFoot.position, hit.point, Color.red);
        }
    }
}
