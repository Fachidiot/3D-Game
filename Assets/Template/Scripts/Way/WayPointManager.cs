using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public WayPoint[] PointsArr;

    public ref WayPoint GetPoint()
    {
        int a = random();

        return ref PointsArr[a];
    }

    bool CheckUsing(int index)
    {
        if (!PointsArr[index].Check())
        {
            return true;
        }
        else
            return false;
    }

    public int random()
    {
        int temp = 0;
        bool end = true;
        while (end)
        {
            temp = Random.Range(0,5);
            end = CheckUsing(temp);
        }

        return temp;
    }
}
