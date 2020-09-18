using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform Rect_Background;
    [SerializeField] private RectTransform Rect_Joystick;

    Vector3 m_Moveposition;
    Vector2 m_vValue;
    float m_fRadius;
    float m_fDistance;
    bool m_bIsTouch;
    bool m_bIsMove;

    [SerializeField] private GameObject Player;
    [SerializeField] private PlayerMovement m_PlayerMovement;
    [SerializeField] private float m_fMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_fRadius = Rect_Background.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bIsTouch)
            Player.transform.position += m_Moveposition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_bIsMove = true;
        m_vValue = eventData.position - (Vector2)Rect_Background.position;

        m_vValue = Vector2.ClampMagnitude(m_vValue, m_fRadius);
        Rect_Joystick.localPosition = m_vValue;

        m_fDistance = Vector2.Distance(Rect_Background.position, Rect_Joystick.position) / m_fRadius;
        m_vValue = m_vValue.normalized;
        m_Moveposition = new Vector3(m_vValue.x * m_fMoveSpeed * m_fDistance * Time.deltaTime, 0f, m_vValue.y * m_fMoveSpeed * m_fDistance * Time.deltaTime);

        m_PlayerMovement.GetMovement(m_Moveposition);
        m_PlayerMovement.Move(m_bIsMove);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_bIsTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_bIsTouch = false;
        m_bIsMove = false;
        m_PlayerMovement.Move(m_bIsMove);
        Rect_Joystick.localPosition = Vector3.zero;
        m_Moveposition = Vector3.zero;
    }

}
