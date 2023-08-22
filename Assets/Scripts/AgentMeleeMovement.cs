using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AgentMeleeMovement : MonoBehaviour
{
    //Agent Movement
    public NavMeshAgent agent;
    public Transform[] targetsPatrolling;
    int randomTarget;
    public bool changeTarget = true;
    public float rotationSpeed;
    Animator animator;  

    // Player detection
    public GameObject player;
    public bool playerOnTarget;
    public float distanceWithPlayer;
    public Collider[] _collision;

    // Gizmo
    [SerializeField] Transform _detectionPivote;
    [SerializeField] float _detectionRadius;
    [SerializeField] LayerMask _detectionMask;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (playerOnTarget)
        {
            RaycastHit hit;
            Vector3 direction = player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit, distanceWithPlayer))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

            }
        }

        if (changeTarget) {
            if (agent.remainingDistance <= 1f) {
                RandomTargets();
            }
        }

        if (_collision.Length > 0)
        {
            playerOnTarget = true;
        }
        else
        {
            playerOnTarget = false;
        }

        if (playerOnTarget)
        {
            distanceWithPlayer = Vector3.Distance(transform.position, _collision[0].transform.position);
        }
        else
        {
            distanceWithPlayer = 1000;
        }

        animator.SetBool("playerOnTarget", playerOnTarget);         
    }

    private void FixedUpdate()
    {
        _collision = Physics.OverlapSphere(_detectionPivote.position, _detectionRadius, _detectionMask);
    }

    void RandomTargets()
    {
        randomTarget = Random.Range(0, 3);
        agent.SetDestination(targetsPatrolling[randomTarget].position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_detectionPivote.position, _detectionRadius);
    }
}
