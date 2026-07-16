using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirePositionController : MonoBehaviour
{
    public Camera maincamera;
    float hight;
    float width;
    public int raw = 15;
    public int column = 15;
    Vector3 center ;
    float minx;
    float miny;
    float maxx;
    float maxy;
    float pointx;
    float pointy;
    Vector3[,] firepoints;
    public List<Vector3> chosenpoints;
    private void Awake()
    {
        firepoints=new Vector3[raw,column];
        chosenpoints=new List<Vector3> { };
    }
    public void firepositionget()
    {
            hight = maincamera.orthographicSize * 2;
            width = hight * maincamera.aspect;
            center = maincamera.transform.position;
            minx = center.x - width / 2f;
            maxx = center.x + width / 2f;
            miny = center.y - hight / 2f;
            maxy = center.y + hight / 2f;
            for (int i = 0; i < raw; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    pointx = Mathf.Lerp(minx, maxx, (i + 0.5f) / column);
                    pointy = Mathf.Lerp(miny, maxy, (j + 0.5f) / raw);
                    firepoints[i, j] = new Vector3(pointx, pointy);
                }
            }
    }
    public void firetypechoser()
    {
        int a=Random.Range(0, 3);
        switch (a)
        {
            case 0:
                firetype1();
                break;
            case 1: 
                firetype2();
                break;
            case 2: 
                firetype3(); 
                break;
        }
    }
    public List<Vector3> firetype1()
    {
        for (int i = 0; i < raw; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (i % 2 == 0 && j%2 == 0)
                {
                    chosenpoints.Add(firepoints[i,j]);
                }
            }
        }
        return chosenpoints;
    }
    public List<Vector3> firetype2()
    {
        for (int i = 0; i < raw; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (i==j||i+j==raw-1)
                {
                    chosenpoints.Add(firepoints[i, j]);
                }
            }
        }
        return chosenpoints;
    }
    public List<Vector3> firetype3()
    {
        for (int i = 0; i < raw; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if ((i==5||i==9)||(j==5||j==9))
                {
                    chosenpoints.Add(firepoints[i, j]);
                }
            }
        }
        return chosenpoints;
    }
}
