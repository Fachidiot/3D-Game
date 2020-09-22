using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_NavMeshAgent;
    [SerializeField]
    private WayPointManager manager;

    private WayPoint m_Waypoint;
    int m_iCurrentWaypointIndex;
    int m_iMaxIndex;

    private void Start()
    {
        SetStart();
    }

    void SetStart()
    {
        m_Waypoint = manager.GetPoint();
        m_iMaxIndex = m_Waypoint.Length();
        m_Waypoint.Use = true;
        m_NavMeshAgent.SetDestination(m_Waypoint.Get()[0].position);
    }

    private void Update()
    {
        if (m_NavMeshAgent.remainingDistance < m_NavMeshAgent.stoppingDistance)
        {
            m_iMaxIndex--;
            m_iCurrentWaypointIndex = (m_iCurrentWaypointIndex + 1) % m_Waypoint.Get().Length;
            m_NavMeshAgent.SetDestination(m_Waypoint.Get()[m_iCurrentWaypointIndex].position);
            if(m_iMaxIndex == m_iCurrentWaypointIndex)
            {
                m_Waypoint.Use = false;
                SetStart();
            }
        }
    }
}
