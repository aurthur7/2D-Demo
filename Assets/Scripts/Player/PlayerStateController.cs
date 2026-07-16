using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public enum currentstate { idle,walk,attackfront,attackup,attackdown,dead}
    public currentstate state;
    public event Action<currentstate> onstatechange;
    public PlayerInputController inputcontroller;
    private void Awake()
    {
        inputcontroller = GetComponent<PlayerInputController>();
    }
    public void statechange(currentstate newstate)
    {
        if (state==currentstate.dead)
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
        onstatechange?.Invoke(state);
    }
    public void statejudge()
    {
        if (inputcontroller.isattackpressed)
        {
            attackstatejudge();
            return;
        }
        if (inputcontroller.moveinput.x != 0 ||inputcontroller.moveinput.y!= 0)
        {
            statechange(currentstate.walk);
        }
        else
        {
            statechange(currentstate.idle);
        }
    }
    private void Update()
    {
        if (canmove())
        {
            return;
        }
        statejudge();
    }
    public void afterattack()
    {
        statechange(currentstate.idle);
    }
    public bool canmove()
    {
        return state == currentstate.attackfront || state == currentstate.attackup
            || state == currentstate.attackdown || state == currentstate.dead;
    }
    public void attackstatejudge()
    {
        if (Mathf.Abs(inputcontroller.dir.y) > Mathf.Abs(inputcontroller.dir.x))
        {
            if (inputcontroller.dir.y > 0)
            {
                statechange(currentstate.attackup);
            }
            else
            {
                statechange(currentstate.attackdown);
            }
        }
        else
        {
            statechange(currentstate.attackfront);
        }
    }
}
