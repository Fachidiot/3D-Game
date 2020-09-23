using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject InputObj;
    public Text NewName;

    public void OnPointerClick(PointerEventData eventData)
    {
        Timer.ScoreInput(NewName.text);

        InputObj.SetActive(false);
    }
}
