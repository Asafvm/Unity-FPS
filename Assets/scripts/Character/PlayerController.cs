using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private FirstPersonController character;

    [SerializeField] GameObject granadePrefab;
    [SerializeField] Transform WeaponContainer;
    [SerializeField] TextMeshProUGUI hintText;
    [SerializeField] LayerMask pickableLayer;
    private GameObject markedObject;
    private Animator animator;
    private float pickupRange = 5f;
    private bool isPointingAtObject = false;
    private CharacterController characterController;
    public Vector3 MoveDirection { get; private set; }

    public bool IsRunning { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        characterController.enabled = true;
        hintText.enabled = false;
    }

    private void Update()
    {
        animator.SetFloat("MoveSpeed", MoveDirection.magnitude);
        if (MoveDirection.magnitude < 0.1f)
        {
            MoveDirection = Vector3.zero;
            return;
        }


    }
    private void FixedUpdate()
    {
        Inspect();

    }

    //highlight specific objects
    private void Inspect()
    {

        //check if player pointing at interactable object
        if (Physics.SphereCast(Camera.main.transform.position, .1f, Camera.main.transform.forward, out RaycastHit hitInfo, pickupRange, pickableLayer))
        {
            markedObject = hitInfo.collider.gameObject;
            isPointingAtObject = true;
            ShowHint("Press E to pickup");

            return;
        }

        isPointingAtObject = false;
        markedObject = null;
        ShowHint("");
    }

    private void ShowHint(String messege)
    {
        hintText.enabled = true;
        hintText.text = messege;
    }


    public void OnInteract(InputValue value)
    {
        if (isPointingAtObject)
        {
            markedObject.transform.SetParent(WeaponContainer);
            markedObject.GetComponent<Rigidbody>().useGravity = false;
            markedObject.transform.localPosition = Vector3.zero;
            markedObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            markedObject.transform.localScale = Vector3.one;
            markedObject.transform.GetComponent<MeshCollider>().enabled = false;
            GetComponentInChildren<HudManager>().OnWeaponPickup();
            animator.SetBool("AimGun", true);
        }

    }
    public void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        MoveDirection = transform.forward * movement.y + transform.right * movement.x;
    }
    public void OnSprint(InputValue value)
    {
        IsRunning = value.isPressed;
        animator.SetBool("Running", value.isPressed);
    }

    public void OnAim(InputValue value)
    {
        Weapon weapon = GetComponentInChildren<Weapon>();
        if (weapon != null)
            animator.SetBool("AimGun", value.isPressed);
    }

    public void OnGranade(InputValue value)
    {
        animator.SetTrigger("ThrowGranade");
    }
    public void OnShoot(InputValue value)
    {
        animator.SetTrigger("FireGun"); //holds an animation event
    }

    public void OnDeath()
    {

        characterController.radius = 0.1f;
        characterController.height = 0.1f;
        
        GetComponent<PlayerInput>().enabled = false;
    }

    /// <summary>
    /// Called from animation event
    /// </summary>
    public void OnFireAnimationEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider)
                GetComponentInChildren<Weapon>().Fire(hit.collider.transform);
        }

    }

    /// <summary>
    /// Called from animation event
    /// </summary>
    public void OnThrowGranade()
    {
        Weapon weapon = GetComponentInChildren<Weapon>();
        if (weapon!=null)
        {
            GameObject granade = Instantiate(granadePrefab, WeaponContainer.position, Quaternion.identity);
            Rigidbody rb = granade.GetComponent<Rigidbody>();
            granade.SetActive(true);
            rb.AddForce(Camera.main.transform.forward * 4, ForceMode.Impulse);
            float random = UnityEngine.Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 5);  // random rotation
        }
    }


}
