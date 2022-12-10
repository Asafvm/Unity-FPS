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

    public bool _team = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
    }

    public void OnWalk(float speed)
    {
        if (source == null) return;
        source.clip = walkSounds[Random.Range(0,walkSounds.Length)];
        source.pitch = speed;
        source.Play();

    }
    public void OnDeath()
    {
        //if not player, turn off ai
        if (TryGetComponent(out CharacterAI ai))
            ai.enabled = false;
        if (TryGetComponent(out NavMeshAgent nav))
            nav.enabled = false;
        if (TryGetComponent(out PlayerInput pi))
            pi.enabled = false;

        //notify that a character died and specify if it was the player or npc
        FindObjectOfType<HudManager>().OnDeath(Team, GetComponent<PlayerController>() != null);

        SetRigidbodies(false);
        SetColliders(true);
        canvasHp.gameObject.SetActive(false);
       

    }

    /// <summary>
    /// Called from animation event. Dummy funciton
    /// </summary>
    public void OnThrowGranade() { }
}
