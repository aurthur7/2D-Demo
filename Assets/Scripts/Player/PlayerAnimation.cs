using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playeranimator;
    public PlayerStateController statecontroller;
    public event Action ondeadend;
    private void OnEnable()
    {
        statecontroller.onstatechange += statechange;
    }
    private void OnDisable()
    {
        statecontroller.onstatechange -= statechange;
    }
    public void statechange(PlayerStateController.currentstate newstate)
    {
        switch (newstate)
        {
            case PlayerStateController.currentstate.idle:
                idleanimation();
                break;
            case PlayerStateController.currentstate.walk:
                moveanimation();
                break;
            case PlayerStateController.currentstate.attackfront:
                attackfront();
                break;
            case PlayerStateController.currentstate.attackup:
                attackup();
                break;
            case PlayerStateController.currentstate.attackdown:
                attackdown();
                break;
            case PlayerStateController.currentstate.dead:
                Deadanimation();
                break;
        }
    }
    void Awake()
    {
        playeranimator=GetComponent<Animator>();
        statecontroller=GetComponent<PlayerStateController>();  
    }
    public void idleanimation()
    {
        playeranimator.SetBool("walk", false);
        playeranimator.SetBool("idle",true);
    }
    public void moveanimation()
    {
        playeranimator.SetBool("idle", false);
        playeranimator.SetBool("walk",true);
    }
    public void attackfront()
    {
        playeranimator.SetTrigger("Attackfront");
    }
    public void attackup()
    {
        playeranimator.SetTrigger("AttackUp");
    }
    public void attackdown()
    {
        playeranimator.SetTrigger("AttackDown");
    }
    public void Deadanimation()
    {
        playeranimator.SetBool("IsDead",true);
    }
    public void ondeadanimationend()
    {
        ondeadend?.Invoke();
    }
}

