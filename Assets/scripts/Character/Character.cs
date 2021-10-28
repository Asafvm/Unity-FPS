using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Health))]

public sealed class Character : MonoBehaviour
{
    [SerializeField] GameObject canvasHp;
    [SerializeField] AudioClip[] walkSounds;
    AudioSource source;
    Animator animator;

    //[SerializeField] Rigidbody rigidbody;
    public bool _team = false;

    // Start is called before the first frame update
    void Start()
    {

        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        SetRigidbodies(true);
        SetColliders(false);
    }

    public bool Team { 
        get => _team; 
        set { _team = value; GetComponentInChildren<TeamMarker>().OnTeamChange(value); } 
    }


    private void SetRigidbodies(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
            rb.isKinematic = state;
        //GetComponent<Rigidbody>().isKinematic = !state;
    }

    private void SetColliders(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
            c.enabled = state;
        GetComponent<Collider>().enabled = !state;
        BoxCollider bc = GetComponent<BoxCollider>();
        if (bc)
            bc.enabled = !state;
        animator.enabled = !state;
        //GetComponent<Rigidbody>().useGravity = !state;

    }

    public void OnWalk(float speed)
    {
        source.clip = walkSounds[Random.Range(0,walkSounds.Length)];
        source.pitch = speed;
        source.Play();

    }
    public void OnDeath()
    {
        //if not player, turn off ai
        if (TryGetComponent<CharacterAI>(out CharacterAI ai))
            ai.enabled = false;
        if (TryGetComponent<NavMeshAgent>(out NavMeshAgent nav))
            nav.enabled = false;
        if (TryGetComponent<PlayerInput>(out PlayerInput pi))
            pi.enabled = false;

        FindObjectOfType<HudManager>().OnDeath(Team, GetComponent<PlayerController>() != null);

        SetRigidbodies(false);
        SetColliders(true);
        canvasHp.gameObject.SetActive(false);
       

    }
}
