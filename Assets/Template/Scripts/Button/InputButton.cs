using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject InputObj = null;
    [SerializeField]
    Text NewName = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        Timer.ScoreInput(NewName.text);

        InputObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
