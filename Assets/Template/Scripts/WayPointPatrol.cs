using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_NavMeshAgent;
    [SerializeField]
    private Transform[] m_WaypointsArr;
    int m_iCurrentWaypointIndex;

    private void Start()
    {
        m_NavMeshAgent.SetDestination(m_WaypointsArr[0].position);
    }

    private void Update()
    {
        if(m_NavMeshAgent.remainingDistance < m_NavMeshAgent.stoppingDistance)
        {
            m_iCurrentWaypointIndex = (m_iCurrentWaypointIndex + 1) % m_WaypointsArr.Length;
            m_NavMeshAgent.SetDestination(m_WaypointsArr[m_iCurrentWaypointIndex].position);
        }
    }
}
