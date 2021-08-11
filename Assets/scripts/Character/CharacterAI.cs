using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CharacterAI : MonoBehaviour
{
    public Transform target;
    public Transform follow;
    private Health characterStatus;
    [SerializeField] bool debugMesseges = false;
    [SerializeField] float chaseRange = 6f;
    [SerializeField] float rateOfFire = 1.8f;
    [SerializeField] float engageDistance = 5f;
    [SerializeField] float pickupDistance = 2f;
    [SerializeField] private float tureSpeed = 3f;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject granadePrefab;
    [SerializeField] private Transform WeaponContainer;

    [Range(1, 200)] public float walkRadius = 20;

    NavMeshAgent navMeshAgent;
    Animator animator;

    //bool isProvoked = false;
    public bool hasGun = false;
    public bool hasGranade = false;
    private Coroutine attack;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.stoppingDistance = engageDistance;
        characterStatus = GetComponent<Health>();

    }


    // Update is called once per frame
    void Update()
    {
        navMeshAgent.enabled = characterStatus.isAlive();
        if (target)
        {
            Health h = target.GetComponent<Health>();
            if (h)
            {
                animator.SetBool("AimGun", h.isAlive());      //draw when target is close

                navMeshAgent.stoppingDistance = engageDistance;

                if (h.isAlive())
                {

                    GetTo(target.position);
                    EngageTarget(target);
                }
                else
                {
                    target = null;
                }
            }
            else
            {
                navMeshAgent.stoppingDistance = pickupDistance;
                animator.SetBool("AimGun", false);

                GetTo(target.position);
                PickupTarget();
            }

        }
        else if(!hasGun)    //look for weapon
        {
            navMeshAgent.stoppingDistance = pickupDistance;
            if (!navMeshAgent.hasPath || GetRemainingDistance(navMeshAgent.pathEndPosition) <= navMeshAgent.stoppingDistance)
                GetTo(RandomLocation()); // look for enemies
            else
                GetTo(navMeshAgent.pathEndPosition);
        }
        
        else if (follow && follow.GetComponent<Health>().isAlive())
        {
            animator.SetBool("AimGun", false);
            navMeshAgent.stoppingDistance = engageDistance;
            GetTo(follow.position);
        }
        else //look for targets
        {
            navMeshAgent.stoppingDistance = pickupDistance;
            if (!navMeshAgent.hasPath || GetRemainingDistance(navMeshAgent.pathEndPosition) <= navMeshAgent.stoppingDistance)
                GetTo(RandomLocation()); 
            else
                GetTo(navMeshAgent.pathEndPosition);
        }
    }

    private void PickupTarget()
    {

        if (GetRemainingDistance(navMeshAgent.pathEndPosition) <= navMeshAgent.stoppingDistance)
        {
            
            switch (target.tag)
            {
                case "Pistol":          //one package for all
                    gun.SetActive(true);
                    hasGun = true;
                    hasGranade = true;
                    Destroy(target.gameObject);
                    


                    break;
                //case "Granade":
                //    hasGranade = true;
                //    Destroy(target.gameObject);
                //    target = null;
                //    navMeshAgent.stoppingDistance = engageDistance;
                //    break;
            }
            target = null;
            navMeshAgent.stoppingDistance = engageDistance;
        }

    }

    private Vector3 RandomLocation()
    {
        Vector3 location = Vector3.zero;
        Vector3 randomLocation = UnityEngine.Random.insideUnitSphere * walkRadius;
        randomLocation += transform.position;
        if (NavMesh.SamplePosition(randomLocation, out NavMeshHit hit, walkRadius, 1))
        {
            location = hit.position;
        }
        return location;
    }

    private void GetTo(Vector3 location)
    {
        //set destination and travel speed / animations
        FaceTarget(location);
        navMeshAgent.SetDestination(location);
        animator.SetFloat("MoveSpeed", navMeshAgent.hasPath && GetRemainingDistance(location) >= navMeshAgent.stoppingDistance ? 1 : 0);
        navMeshAgent.speed = GetRemainingDistance(location) > chaseRange ? 5 : 2;
        animator.SetBool("Running", GetRemainingDistance(location) > chaseRange);

        if (debugMesseges)
            Debug.Log($"{gameObject.name} : Path: {navMeshAgent.hasPath}, remaining: {GetRemainingDistance(location)}, stopping at: {navMeshAgent.stoppingDistance}, move condition: {navMeshAgent.hasPath && GetRemainingDistance(location) >= navMeshAgent.stoppingDistance}");

    }

    private float GetRemainingDistance(Vector3 location)
    {
        if (navMeshAgent.pathPending)
        {
             return Vector3.Distance(transform.position, location);
        }
        else
        {
            return navMeshAgent.remainingDistance;
        }
    }

    private void EngageTarget(Transform target)
    {
        if (GetRemainingDistance(target.position) <= navMeshAgent.stoppingDistance && TargetInSight(target))    //attack on sight
            attack = StartCoroutine(AttackTarget());
        else
        {
            if(attack!= null)
                StopCoroutine(attack);
        }
            

    }


    private bool TargetInSight(Transform target)
    {
        RaycastHit hit;
        Weapon weapon = GetComponentInChildren<Weapon>();
        if (Physics.Raycast(weapon.transform.position, weapon.transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.gameObject == target.gameObject)
                return true;
            else
            {
                return false;
            }
        }
        return false;
    }

    private IEnumerator AttackTarget()
    {
        float attackType = Random.Range(0, 100);
        if (attackType < 90)
            animator.SetTrigger("FireGun");
        else
        {
            animator.SetTrigger("ThrowGranade");
        }
        
        yield return new WaitForSeconds(rateOfFire);
    }

    public void OnThrowGranade()
    {
        if (hasGranade)
        {
            transform.LookAt(target.position);
            GameObject granade = Instantiate(granadePrefab, WeaponContainer.position, Quaternion.identity);
            Rigidbody rb = granade.GetComponent<Rigidbody>();
            granade.SetActive(true);
            rb.AddForce(transform.forward * 4, ForceMode.Impulse);
            float random = UnityEngine.Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 5);  // random rotation
        } 
            
        
    }

    private void FaceTarget(Vector3 location)
    {
        Vector3 direction = (location - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * tureSpeed);
    }


    public void OnFireAnimationEvent()
    {
        if(hasGun)
            GetComponentInChildren<Weapon>().Fire(target);
    }


}
