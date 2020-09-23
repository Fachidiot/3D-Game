using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Post : MonoBehaviour
{
    public PostProcessVolume Volume;

    private ChromaticAberration m_Chromatic;

    static bool m_bIsBoost;
    public static bool Boost { get { return m_bIsBoost; } set { m_bIsBoost = value; } }

    void Update()
    {
        if (m_bIsBoost)
        {
            Volume.enabled = true;
        }
        else
            Volume.enabled = false;
    }
}
