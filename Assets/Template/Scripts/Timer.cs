using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static float m_fTime;
    [SerializeField]
    Text m_Text;

    static bool m_bIsEnd;
    public static bool End
    {
        get
        {
            return m_bIsEnd;
        }
        set
        {
            m_bIsEnd = value;
        }
    }
    static bool m_bIsReset;
    public static bool Reset
    {
        get
        {
            return m_bIsReset;
        }
        set
        {
            m_bIsReset = value;
        }
    }
    
    [SerializeField]
    private static List<ScoreData> m_ScoreArr;
    public static List<ScoreData> ScoreArr { get { return m_ScoreArr; } }

    public static void reset()
    {
        m_fTime = 0f;
        m_bIsEnd = m_bIsReset = false;
    }

    public class ScoreData
    {
        public string m_Name;
        public float m_fScore;

        public ScoreData(string _Name, float _Score)
        {
            m_Name = _Name;
            m_fScore = _Score;
        }
    }

    void Start()
    {
        m_fTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bIsEnd || m_bIsReset)
        {
            if (m_bIsEnd)
            {
                Score.time = m_fTime;
                return;
            }
            m_fTime = 0f;
            Invoke("reset", 5f);
        }
        else if (!m_bIsEnd || !m_bIsReset)
        {
            m_fTime += Time.deltaTime;
            m_Text.text = string.Format("{0:0.#}", m_fTime);
        }
    }

    public static void ScoreLoad()
    {
        if (PlayerPrefs.HasKey("Name0") == true)
        {
            m_ScoreArr = new List<ScoreData>();

            for (int i = 0; i < 7; i++)
            {
                ScoreData NewScore = new ScoreData(PlayerPrefs.GetString("Name" + i), PlayerPrefs.GetFloat("Score" + i));
                m_ScoreArr.Add(NewScore);
            }

            return;
        }

        m_ScoreArr = new List<ScoreData>();

        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetString("Name" + i, "");
            PlayerPrefs.SetFloat("Score" + i, 0.0f);

            ScoreData NewScore = new ScoreData("", 0.0f);
            m_ScoreArr.Add(NewScore);
        }
    }

    public static bool ScoreCheck()
    {
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_fTime < ScoreArr[i].m_fScore)
            {
                return true;
            }
            else if(ScoreArr[i].m_fScore <= 0f)
            {
                return true;
            }
        }

        return false;
    }

    public static void ScoreInput(string _Name)
    {
        // Score Sorting
        ScoreData CheckData = new ScoreData(_Name, m_fTime);
        m_fTime = 0;

        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (CheckData.m_fScore < ScoreArr[i].m_fScore)
            {
                ScoreData TempScore = ScoreArr[i];
                ScoreArr[i] = CheckData;
                CheckData = TempScore;

            }
            else if (ScoreArr[i].m_fScore <= 0f)
            {
                ScoreData TempScore = ScoreArr[i];
                ScoreArr[i] = CheckData;
                CheckData = TempScore;
            }
        }

        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetString("Name" + i, m_ScoreArr[i].m_Name);
            PlayerPrefs.SetFloat("Score" + i, m_ScoreArr[i].m_fScore);
        }
    }
}
