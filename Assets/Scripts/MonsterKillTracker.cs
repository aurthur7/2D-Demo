using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKillTracker : MonoBehaviour
{
    public event Action achievekillnumber;
    private int nowkill=0;
    private int maxkill = 5;
    private bool hasreachgoal=false;
    public static MonsterKillTracker Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public void addkillnum()
    {
        if (hasreachgoal)
        {
            return;
        }
        nowkill++;
        Debug.Log(nowkill);
        if (nowkill >= maxkill)
        {
            hasreachgoal = true;
            achievekillnumber?.Invoke();
        }
    }
}
