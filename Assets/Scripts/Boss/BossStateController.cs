using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateController : MonoBehaviour
{
    public BossConfig config;
    public enum currentstate { none,idle,chase,wander,attack,phasechanging,dead}
    public currentstate state;
    public event Action<currentstate> onstatechanged;
    public BossHealth health;
    public float distance;
    private void Awake()
    {
        health = GetComponent<BossHealth>();
    }
    private void OnEnable()
    {
        health.onhpchanged += onhpchange;
    }
    private void OnDisable()
    {
        health.onhpchanged -= onhpchange;
    }
    public void onhpchange(int nowhp)
    {
        if (nowhp <= 0)
        {
            changestate(currentstate.dead);
        }    
    }
    private void FixedUpdate()
    {
        statejudge();
    }
    public void changestate(currentstate newstate)
    {
        if (state == currentstate.dead)
        {
            return;
        }
        if (state == newstate)
        {
            return;
        }
        else
        {
            state = newstate;
        }
        onstatechanged?.Invoke(state);
    }
    public void statejudge()
    {
        if (state == currentstate.phasechanging||state==currentstate.dead||state==currentstate.attack)
        {
            return ;
        }
        distance = Vector3.Distance(transform.position,Player.Instance.transform.position);
        if (distance >= config.chaseDistance)
        {
            changestate(currentstate.chase);
        }
        else 
        {
            changestate(currentstate.wander);
        }
    }
}
