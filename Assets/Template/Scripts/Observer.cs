using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private GameEnding m_GameEnding;

    bool m_bIsTargetInRange = false;
    Vector3 m_vDirection;
    RaycastHit m_RaycastHit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == m_Target)
        {
            m_bIsTargetInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == m_Target)
        {
            m_bIsTargetInRange = false;
        }
    }

    private void Update()
    {
        if(m_bIsTargetInRange)
        {
            m_vDirection = m_Target.position - transform.position + Vector3.up;

            Ray m_ray = new Ray(transform.position, m_vDirection);

            if(Physics.Raycast(m_ray, out m_RaycastHit))
            {
                if(m_RaycastHit.collider.transform == m_Target)
                {
                    m_GameEnding.CaughtPlayer();
                }
            }
        }
    }
}
