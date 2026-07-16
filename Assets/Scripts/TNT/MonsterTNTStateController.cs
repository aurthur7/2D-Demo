using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTNTStateController : MonoBehaviour
{
    public enum cunrrentstate { none,chase, escape, wander,idle,attack,dead }
    public cunrrentstate state;
    public float outcircle = 6f;
    public float incircle = 4f;
    public Coroutine ringcoroutine;
    private Transform monsterTNTtransform;
    public MonsterTNTMove move;
    public event Action<cunrrentstate> oncunrrentstatechange;
    private void Awake()
    {
        monsterTNTtransform = GetComponent<Transform>();
        move=GetComponent<MonsterTNTMove>();
    }
    public void distancejudge(float distance)
    {
        if (state == cunrrentstate.dead||state==cunrrentstate.attack||state==cunrrentstate.idle)
        {
            return;
        }
        if (distance > outcircle)
        {
            changestate(cunrrentstate.chase);
        }
        else if (distance < incircle)
        {
            changestate(cunrrentstate.escape);
        }
        else if(distance>incircle&&distance<outcircle)
        {
            changestate(cunrrentstate.wander);
        }
    }
    public void changestate(cunrrentstate newstate)
    {
        if (state == cunrrentstate.dead)
        {
            return ;
        }
        if (state == newstate)
        {
            return;
        }
        else
        {
            state = newstate;
        }
        if (state == cunrrentstate.dead)
        {
            ringcoroutine = null;
            StopAllCoroutines();
        }
        oncunrrentstatechange?.Invoke(newstate);
    }
    public void statejudge()
    {
        switch (state)
        {
            case cunrrentstate.chase:
                if (ringcoroutine != null)
                {
                    StopCoroutine(ringcoroutine);
                    ringcoroutine = null;
                }
                break;
            case cunrrentstate.escape:
                if (ringcoroutine != null)
                {
                    StopCoroutine(ringcoroutine);
                    ringcoroutine = null;
                }
                break;
            case cunrrentstate.wander:
                if (ringcoroutine == null)
                {
                    ringcoroutine = StartCoroutine(wanderingstate());
                }
                break;
            case cunrrentstate.dead:
                if (ringcoroutine != null)
                {
                    StopCoroutine (ringcoroutine);
                    ringcoroutine = null;
                }
                break;
        }
    }

    IEnumerator wanderingstate()
    {
        yield return new WaitUntil(()=>move.hasarrived());
        if (state != cunrrentstate.wander)
        {
            ringcoroutine=null;
            yield break;
        }
        changestate(cunrrentstate.idle);
        yield return new WaitForSeconds(1f);

        changestate(cunrrentstate.attack);
        ringcoroutine=null;
    }
    private void FixedUpdate()
    {
        if (state == cunrrentstate.wander)
        {
            statejudge();
            return;
        }
        float distance = Vector2.Distance(monsterTNTtransform.position,Player.Instance.transform.position);
        distancejudge(distance);
        statejudge();
        
    }
    public void afterattack()
    {
        if (state == cunrrentstate.dead)
        {
            return;
        }
        changestate(cunrrentstate.chase);
    }
}
