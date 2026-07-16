using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bombstatecontroller : MonoBehaviour
{
    public enum bombstate { none,flying,explore}
    public bombstate state;
    public event Action<bombstate> onstatechange;
    public Bomb bomb;
    public void ChangeState(bombstate newstate)
    {
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

    private void Awake()
    {
        state=bombstate.none;
        bomb = GetComponent<Bomb>();
    }

}
