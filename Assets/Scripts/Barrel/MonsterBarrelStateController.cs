using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBarrelStateController : MonoBehaviour
{
    public enum cunrrentstate { none,chase,explore,dead}
    public cunrrentstate state;
    public event Action<cunrrentstate> onstatechange;
    private void Awake()
    {
    }
    public void changestate(cunrrentstate newstate)
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
}
