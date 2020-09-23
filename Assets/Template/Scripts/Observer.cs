using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Target;
    public GameEnding GameEnding;

    private bool m_bIsTargetInRange;
    private Vector3 m_vDirection;
    private RaycastHit m_RaycastHit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == Target)
        {
            m_bIsTargetInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == Target)
        {
            m_bIsTargetInRange = false;
        }
    }

    private void Update()
    {
        if(m_bIsTargetInRange)
        {
            m_vDirection = Target.position - transform.position + Vector3.up;

            Ray m_ray = new Ray(transform.position, m_vDirection);

            if(Physics.Raycast(m_ray, out m_RaycastHit))
            {
                if(m_RaycastHit.collider.transform == Target)
                {
                    GameEnding.CaughtPlayer();
                }
            }
        }
    }
}
