using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public List<Transform> TransformList;

    private bool m_bIsUse = false;

    public bool IsUse()
    {
        if (m_bIsUse)
            return true;
        else
            return false;
    }

    public Vector3 GetPosition(int index)
    {
        return TransformList[index].position;
    }

    public int Count()
    {
        return TransformList.Count;
    }
}
