using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToTheTarget : MonoBehaviour
{
    [SerializeField] private string _objectName;
    private Transform _targetPosition;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        SetTarget();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void SetTarget()
    {
        _targetPosition = GameObject.Find("/" + _objectName).transform;
    }

    private void Update()
    {
        _navMeshAgent.destination = _targetPosition.position;
    }
}
