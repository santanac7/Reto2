using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMeleeMovement : MonoBehaviour
{
    //Agent Movement
    [HideInInspector]
    public NavMeshAgent agent;
    public GameObject[] newTransform;
    //public GameObject prefabTransform;    
    //Vector3[] transPos;
    
    
    int randomTarget;
    public bool changeTarget = true;
    public float rotationSpeed;
    [HideInInspector]
    public Animator animator;

    // Player detection
    public GameObject player;
    public bool playerOnTarget;
    public float distanceWithPlayer;
    public Collider[] _collision;

    // Gizmo
    [SerializeField] Transform _detectionPivote;
    [SerializeField] float _detectionRadius;
    [SerializeField] LayerMask _detectionMask;

    public float minCollisionAngle = 60f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); 
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
        animator.SetFloat("Distance", distanceWithPlayer);
        Follow();
    }

    private void FixedUpdate()
    {
        _collision = Physics.OverlapSphere(_detectionPivote.position, _detectionRadius, _detectionMask);
    }

    void RandomTargets()
    {
        randomTarget = Random.Range(0, 3);
        agent.SetDestination(newTransform[randomTarget].transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_detectionPivote.position, _detectionRadius);
    }   
    IEnumerator Dying()
    {
        animator.SetBool("isAlive", false);
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        yield return null;
    }

    private void Follow()
    {

        if (playerOnTarget)
        {
            changeTarget = false;
            agent.speed = 4f;
            agent.SetDestination(player.transform.position);
            if (playerOnTarget && distanceWithPlayer <= 4f)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            //agent.SetDestination(newTransform[0].transform.position);
            changeTarget = true;
        }
    }
}
