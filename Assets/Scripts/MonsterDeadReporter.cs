using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeadReporter : MonoBehaviour
{
    private Iaudioevent audioevent;
    private bool isdeadreported=false;
    private void Awake()
    {
        audioevent = GetComponent<Iaudioevent>();
    }
    private void OnEnable()
    {
        isdeadreported = false;
        if (audioevent != null)
        {
            audioevent.ondead += deathreport;
        }
    }
    private void OnDisable()
    {
        if (audioevent != null)
        {
            audioevent.ondead -= deathreport;
        }
    }
    public void deathreport()
    {
        if (isdeadreported)
        {
            return;
        }
        isdeadreported = true;
        if (MonsterKillTracker.Instance != null)
        {
            MonsterKillTracker.Instance.addkillnum();
        }
    }
}
