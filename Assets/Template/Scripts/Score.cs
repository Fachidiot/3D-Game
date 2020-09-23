using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static float m_fTime;
    public static float time { get { return m_fTime; } set { m_fTime = value; } }

    private Text[] ArrText = null;
    private GameObject m_NameInput = null;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Awake()
    {
        Timer.ScoreLoad();

        if(m_NameInput == null)
        {
            Debug.LogError("NameInput is Null");
            return;
        }

        if(Timer.ScoreCheck())
        {
            m_NameInput.SetActive(true);
        }
    }
    
    void Update()
    {
        ArrText = GetComponentsInChildren<Text>();

        if (Timer.ScoreArr.Count != ArrText.Length)
        {
            Debug.LogError("Loaded Score isn't currect");
            return;
        }

        for (int i = 0; i < ArrText.Length; i++)
        {
            if (Timer.ScoreArr[i].m_fScore == 0)
            {
                ArrText[i].text = "NULL";
                continue;
            }

            string strName = Timer.ScoreArr[i].m_Name;

            if (strName == "")
            {
                strName = "NONAME";
            }

            ArrText[i].text = (i + 1).ToString() + ". " + strName +
                " " + string.Format("{0:0.0#}", Timer.ScoreArr[i].m_fScore) + "초";
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
