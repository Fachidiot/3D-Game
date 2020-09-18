using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public AudioSource m_ExitAudio;
    public AudioSource m_CaughtAudio;

    [SerializeField]
    private float m_fFadeDuration = 1f;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private CanvasGroup m_ExitBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup m_CaughtBackgroundImageCanvasGroup;
    [SerializeField]
    private float m_fDisplayImageDuration = 1f;
    
    float m_fTimer;
    bool m_bHasAudioPlayed = false;
    bool m_bIsPlayerAtExit = false;
    bool m_bIsPlayerCaught = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == m_player)
        {
            m_bIsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_bIsPlayerCaught = true;
    }

    private void Update()
    {
        if (m_bIsPlayerAtExit)
        {
            EndLevel(m_ExitBackgroundImageCanvasGroup, false, m_ExitAudio);
        }

        else if(m_bIsPlayerCaught)
        {
            EndLevel(m_CaughtBackgroundImageCanvasGroup, true, m_CaughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_bHasAudioPlayed)
        {
            audioSource.Play();
            m_bHasAudioPlayed = true;
        }

        m_fTimer += Time.deltaTime;

        m_ExitBackgroundImageCanvasGroup.alpha = m_fTimer / m_fFadeDuration;

        if(m_fTimer > m_fFadeDuration + m_fDisplayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
