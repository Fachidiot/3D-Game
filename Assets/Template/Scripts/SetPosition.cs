using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public List<Transform> transforms;
    public bool b_Captain;

    private bool m_bIsWorking = false;
    private static Dictionary<Transform, bool> m_TransformList = new Dictionary<Transform, bool>();

    private void Start()
    {
        if(b_Captain)
            SetList();
    }

    private void Update()
    {
        // 동작 여부 확인
        if (m_bIsWorking)
            return;

        // 동작하기위해 새로운 포지션으로 이동
        int index = DoRandom();

        SetTrans(index);
        m_TransformList[transforms[index]] = true;
    }

    void SetList()
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            m_TransformList.Add(transforms[i], false);
        }
    }

    // 랜덤 인덱서 가져오기
    int DoRandom()
    {
        int index = 0;
        bool m_bIsEnd = false;
        while (!m_bIsEnd)
        {
            index = Random.Range(0, transforms.Count);

            // 사용가능한 위치일때
            if(!m_TransformList[transforms[index]])
            {
                m_bIsEnd = true;
            }
        }

        return index;
    }

    // 위치 변경 함수
    void SetTrans(int index)
    {
        gameObject.transform.position = transforms[index].position;
        gameObject.transform.rotation = transforms[index].rotation;
        m_bIsWorking = true;
        StartCoroutine("StartWork", index);
    }

    IEnumerator StartWork(int index)
    {
        yield return new WaitForSeconds(5.0f);
        m_bIsWorking = false;
        m_TransformList[transforms[index]] = false;
    }
}
