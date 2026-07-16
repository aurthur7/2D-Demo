using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseController : MonoBehaviour
{
    public BossConfig config;
    public enum currentphase {phase1,phase2 }
    public currentphase phase;
    public event Action<currentphase> onphasechange;
    public event Action<currentphase> phaserequest;
    public BossHealth health;
    private void Awake()
    {
        health = GetComponent<BossHealth>();
    }
    private void OnEnable()
    {
        health.onhpchanged += onhpchanged;
    }
    private void OnDisable()
    {
        health.onhpchanged -= onhpchanged;
    }
    public void onhpchanged(int nowhp)
    {
        if (nowhp <= config.phase2Hp)
        {
            phasechangerequest(currentphase.phase2);
        }
    }
    public void phasechangerequest(currentphase targetphase)
    {
        if (phase == targetphase)
        {
            return;
        }
        phaserequest?.Invoke(targetphase);
    }
    public void changephase(currentphase newphase)
    {
        if (phase == newphase)
        {
            return;
        }
        else
        {
            phase = newphase;
        }
        onphasechange?.Invoke(phase);
    }
}
