using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Input, Mathf 클래스에 대한 메서드는 정적.
    Vector3 m_vMovement;
    Vector3 m_vDesiredForward;
    Quaternion m_qRotation = Quaternion.identity;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    [SerializeField]
    float m_fTurnSpeed = 20;
    float m_fHorizontal;
    float m_fVertical;
    bool m_bHasHorizontalInput;
    bool m_bHasVerticalInput;
    bool m_bIsWalking;

    public void Move(bool _1)
    {
        m_bIsWalking = _1;
    }

    public void GetMovement(Vector3 vector3)
    {
        m_vMovement = vector3;
    }

    void Start()
    {
        m_fHorizontal = Input.GetAxis("Horizontal");
        m_fVertical = Input.GetAxis("Vertical");
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //m_fHorizontal = Input.GetAxis("Horizontal");
        //m_fVertical = Input.GetAxis("Vertical");

        //m_vMovement.Set(m_fHorizontal, 0f, m_fVertical);
        //m_vMovement.Normalize(); // 벡터는 최대 1값을 가질수 있는 숫자 2개로 이뤄져 있음 따라서 1.414의 값을 정규화 시켜줌

        //m_bHasHorizontalInput = !Mathf.Approximately(m_fHorizontal, 0f);   // horizontal값이 0에 가까우면 true
        //m_bHasVerticalInput = !Mathf.Approximately(m_fVertical, 0f);
        //m_bIsWalking = m_bHasHorizontalInput || m_bHasVerticalInput;
        m_Animator.SetBool("IsWalking", m_bIsWalking);

        if(m_bIsWalking)
        {
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        m_vDesiredForward = Vector3.RotateTowards(transform.forward, m_vMovement, m_fTurnSpeed * Time.deltaTime, 0f);
        m_qRotation = Quaternion.LookRotation(m_vDesiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_vMovement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_qRotation);
    }
}
