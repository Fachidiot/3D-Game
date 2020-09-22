using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject ScoreObj = null;
    [SerializeField]
    GameEnding EndingObj = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreObj.SetActive(false);
        Timer.reset();
        EndingObj.reset();
    }
}
