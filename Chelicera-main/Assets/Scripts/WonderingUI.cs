using UnityEngine;
using UnityEngine.AI;

public class WonderingUI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _wonderColdown;
    [SerializeField] private float _wonderRadius;
    private DecreaserTime _decreaserTime;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _decreaserTime = new DecreaserTime(0,RegeneratePosition);
        RegeneratePosition();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        WalkToPosition();
        _decreaserTime.DecreaseTime();
    }

    private void RegeneratePosition() 
    {
        _decreaserTime.CoolDown = _wonderRadius;
        Vector3 newWardingTarget = transform.position + new Vector3(Random.Range(0, _wonderRadius),0, Random.Range(0, _wonderRadius));
        _target.position = newWardingTarget;
    }

    private void WalkToPosition() 
    {
        _navMeshAgent.destination = _target.position;
    }
    private void OnDestroy() 
    {
      Pause.RemoveEntitie(_decreaserTime);
    }
}