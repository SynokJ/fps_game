using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTr = default;
    private NavMeshAgent _agent = default;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        _agent.destination = _playerTr.position;
    }
}
