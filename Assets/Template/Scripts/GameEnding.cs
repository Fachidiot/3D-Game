using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public AudioSource ExitAudio;
    public AudioSource CaughtAudio;
    public float f_FadeDuration;
    public GameObject Player;
    public CanvasGroup ExitBackgroundImageCanvasGroup;
    public CanvasGroup CaughtBackgroundImageCanvasGroup;
    public float f_DisplayImageDuration;
    public Score ScoreBoard;
    
    private float m_fTimer;
    private bool m_bHasAudioPlayed = false;
    private bool m_bIsPlayerAtExit = false;
    private bool m_bIsPlayerCaught = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
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
            Timer.End = true;
            EndLevel(ExitBackgroundImageCanvasGroup, false, ExitAudio);
        }

        else if(m_bIsPlayerCaught)
        {
            Timer.Reset = true;
            EndLevel(CaughtBackgroundImageCanvasGroup, true, CaughtAudio);
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

        imageCanvasGroup.alpha = m_fTimer / f_FadeDuration;

        if(m_fTimer > f_FadeDuration + f_DisplayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
                Timer.reset();
            }
            else
            {
                ScoreBoard.SetActive(true);
            }
        }
    }

    public void reset()
    {
        m_bIsPlayerAtExit = false;
        m_bIsPlayerCaught = false;

        SceneManager.LoadScene(0);
    }
}
