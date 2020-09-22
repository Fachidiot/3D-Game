using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform[] m_WaypointsArr;
    bool m_bUsed = false;
    public bool Use { get { return m_bUsed; } set { m_bUsed = value; } }

    public bool Check()
    {
        if (m_bUsed)
            return true;
        else
            return false;
    }

    public Transform[] Get()
    {
        return m_WaypointsArr;
    }

    public int Length()
    {
        return m_WaypointsArr.Length;
    }
}
