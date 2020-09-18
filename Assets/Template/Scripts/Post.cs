using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Post : MonoBehaviour
{
    [SerializeField]
    PostProcessVolume m_Volume;
    ChromaticAberration m_Chromatic;

    static bool m_bIsBoost;
    public static bool Boost
    {
        get
        {
            return m_bIsBoost;
        }
        set
        {
            m_bIsBoost = value;
        }
    }

    private void Start()
    {
    }

    void Update()
    {
        if (m_bIsBoost)
        {
            m_Volume.enabled = true;
        }
        else
            m_Volume.enabled = false;
    }
}
