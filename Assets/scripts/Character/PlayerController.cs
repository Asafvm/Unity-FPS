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
    private GameObject markedObject;
    public Transform spine;
    private Animator animator;
    private Color highlightColor = Color.yellow;
    Material originalMaterial, tempMaterial;
    Renderer rend = null;
    private float pickupRange = 5f;

    public Vector3 MoveDirection { get; private set; }

    public bool IsRunning { get; private set; }

    private void Start()
    {
        hintText.enabled = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("MoveSpeed", MoveDirection.magnitude);
        if (MoveDirection.magnitude < 0.1f)
        {
            MoveDirection = Vector3.zero;
            return;
        }
        // transform.position += MoveDirection * character.MoveSpeed * Time.deltaTime;


    }
    private void FixedUpdate()
    {
        Inspect();

    }

    //highlight specific objects
    private void Inspect()
    {
        Renderer currRend;
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, pickupRange))//,6))
        {
            if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Pickable"))
            {
                markedObject = hitInfo.collider.gameObject;
                ShowHint("Interact to pickup");
                currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();

                if (currRend == rend)
                    return;

                if (currRend && currRend != rend)
                {
                    if (rend)
                    {
                        rend.sharedMaterial = originalMaterial;
                    }
                }

                if (currRend)
                    rend = currRend;
                else
                    return;

                originalMaterial = rend.sharedMaterial;

                tempMaterial = new Material(originalMaterial);
                rend.material = tempMaterial;
                rend.material.color = highlightColor;
            }
            else
            {
                markedObject = null;
                hintText.enabled = false;
                if (rend)
                {
                    rend.sharedMaterial = originalMaterial;
                    rend = null;
                }
            }

        }
    }

    private void ShowHint(String messege)
    {
        hintText.enabled = true;
        hintText.text = messege;
    }


    private void LateUpdate()
    {
        //spine bend not working
        // spine.transform.rotation = Quaternion.AngleAxis(lastRotation + rotationValue, Vector3.forward);
        //Debug.Log($"last: {lastRotation}, current: {rotationValue}");
    }

    public void OnInteract(InputValue value)
    {
        if (markedObject)
        {
            //Debug.Log($"Picked up {markedObject.name}");
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
        IsRunning = value.isPressed;// context.ReadValueAsButton();
        animator.SetBool("Running", value.isPressed);
    }

    public void OnAim(InputValue value)
    {
        Weapon w = GetComponentInChildren<Weapon>();
        if (w)
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
        GetComponent<Animator>().SetBool("isDead", true);
        CharacterController collider = GetComponent<CharacterController>();
        if (collider)
        {
            collider.radius = 0.1f;
            collider.height = 0.1f;
        }
        GetComponent<PlayerInput>().enabled = false;
    }
    public void OnFireAnimationEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider)
                GetComponentInChildren<Weapon>().Fire(hit.collider.transform);
        }

    }
    public void OnThrowGranade()
    {
        Weapon w = GetComponentInChildren<Weapon>();
        if (w)
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
