using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform Rect_Background;
    public RectTransform Rect_Joystick;
    public GameObject Player;
    public PlayerMovement PlayerMovement;
    public float f_MoveSpeed;

    private Vector3 m_Moveposition;
    private Vector2 m_vValue;
    private float m_fRadius;
    private float m_fDistance;
    private bool m_bIsTouch;
    private bool m_bIsMove;
    
    void Start()
    {
        m_fRadius = Rect_Background.rect.width * 0.5f;
    }
    
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
        Debug.Log(m_fDistance);
        if (m_fDistance > 0.85)
            Post.Boost = true;
        else
            Post.Boost = false;

        m_vValue = m_vValue.normalized;
        m_Moveposition = new Vector3(m_vValue.x * f_MoveSpeed * m_fDistance * Time.deltaTime, 0f, m_vValue.y * f_MoveSpeed * m_fDistance * Time.deltaTime);

        PlayerMovement.GetMovement(m_Moveposition);
        PlayerMovement.Move(m_bIsMove);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_bIsTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_bIsTouch = false;
        m_bIsMove = false;
        PlayerMovement.Move(m_bIsMove);
        Rect_Joystick.localPosition = Vector3.zero;
        m_Moveposition = Vector3.zero;
        m_fDistance = 0.0f;
        Post.Boost = false;
    }
}
