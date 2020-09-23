using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public List<WayPoint> waypoints;

    private int m_iIndex = 0;
    private int m_iCount = 0;
    private int m_CurrentWaypointIndex;

    void Start()
    {
        m_iIndex = RandomIndex();
        SetDistance();
    }

    void Update()
    {
        CheckDistance();
    }

    int RandomIndex()
    {
        m_iCount = 0;
        int temp = 0;
        bool m_bIsEnd = false;
        while (!m_bIsEnd)
        {
            temp = Random.Range(0, waypoints.Count);
            if (!waypoints[temp].IsUse())
                m_bIsEnd = true;
        }

        return temp;
    }

    void SetDistance()
    {
        navMeshAgent.SetDestination(waypoints[m_iIndex].GetPosition(m_CurrentWaypointIndex));
    }

    void CheckDistance()
    {
        if (m_iCount >= waypoints[m_iIndex].Count() - 1)
        {
            m_iIndex = RandomIndex();
            CheckDistance();
            return;
        }
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_iCount++;
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints[m_iIndex].Count();
            navMeshAgent.SetDestination(waypoints[m_iIndex].GetPosition(m_CurrentWaypointIndex));
        }
    }
}
