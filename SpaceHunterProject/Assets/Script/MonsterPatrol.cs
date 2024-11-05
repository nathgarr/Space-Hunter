using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering;

public class MonsterPatrol : MonoBehaviour
{
    public Transform targetObject;
    public NavMeshAgent navMeshAgent;
    public float walkSpeed = 4;
    public float runspeed = 6;

    public float viewRaduis = 10;
    public float viewAngles = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public Transform[] waypoint;
    int m_CurrentWaypointIndex;

    Vector3 PlayerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    bool m_PlayerInRAnge;

    public float chaseMaxDistance = 10;


    /*private IEnumerator coroutine;*/

    private void Start()
    {
        m_PlayerInRAnge = false;

        m_CurrentWaypointIndex = 0;

        navMeshAgent.isStopped = false;
        StartCoroutine(PatrolCorout());
    }
    private void Update()
    {
        EnvironementView();
        
    }

    public Vector3 NextPoint()
    {
        m_CurrentWaypointIndex++;
        if (m_CurrentWaypointIndex == waypoint.Length)
        {
            m_CurrentWaypointIndex = 0;
        }
        return waypoint[m_CurrentWaypointIndex].position;

    }
    public void OnDrawGizmosSelected()
    {
        Handles.color = m_PlayerInRAnge ? Color.red : Color.green;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, viewAngles, viewRaduis);

    }


    void EnvironementView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRaduis, playerMask);
        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngles / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRAnge = true;
                }
                else
                {
                    m_PlayerInRAnge = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRaduis)
            {
                m_PlayerInRAnge = false;
            }
            if (m_PlayerInRAnge)
            {
                m_PlayerPosition = player.transform.position;
            }
        }
    }

    IEnumerator PatrolCorout()
    {
        while (!m_PlayerInRAnge)
        {
            Vector3 targetPos = NextPoint();
            yield return StartCoroutine(MovePlayer(targetPos));
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(ChaseCorout());
    }
    IEnumerator MovePlayer(Vector3 targetPos)
    {
        navMeshAgent.speed = walkSpeed;
        navMeshAgent.SetDestination(waypoint[m_CurrentWaypointIndex].position);
        while (navMeshAgent.pathPending) yield return null;
        while (navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance && !m_PlayerInRAnge)
        {
            yield return null;

        }
    }
    IEnumerator ChaseCorout()
    {
        navMeshAgent.speed = runspeed;
        do
        {
            navMeshAgent.SetDestination(m_PlayerPosition);
            while (navMeshAgent.pathPending) yield return null;
            yield return null;
            
        } while (navMeshAgent.remainingDistance < chaseMaxDistance);
        StartCoroutine(PatrolCorout());
    }
}
