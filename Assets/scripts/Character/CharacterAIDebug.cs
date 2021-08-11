using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(NavMeshAgent))]


public class CharacterAIDebug : MonoBehaviour
    {
    [SerializeField] float chaseRange = 8f;

    private LineRenderer lineRenderer;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = .15f;
        lineRenderer.endWidth = .15f;
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        Weapon w = GetComponentInChildren<Weapon>();
        if(w)
        Debug.DrawRay(w.transform.position, w.transform.TransformDirection(Vector3.forward), Color.red);
        if (navMeshAgent.hasPath && navMeshAgent.isActiveAndEnabled)
        {
            DrawPath();
        }
    }
    private void DrawPath()
    {
        Vector3[] corners = navMeshAgent.path.corners;
        lineRenderer.positionCount = corners.Length;
        lineRenderer.SetPosition(0, transform.position);
        if (navMeshAgent.path.corners.Length < 2) return;
        for (int i = 1; i < navMeshAgent.path.corners.Length; i++)
        {
            Vector3 pos = new Vector3(corners[i].x, corners[i].y + .2f, corners[i].z);
            lineRenderer.SetPosition(i, pos);
        }
    }

    //display chase range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }
}

