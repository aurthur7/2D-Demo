using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimation : MonoBehaviour
{
    public Animator torchanimator;
    public TorchStateController stateController;
    private void Awake()
    {
        stateController = GetComponent<TorchStateController>();
        torchanimator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        stateController.onstatechange += statechangeanimation;
    }
    private void OnDisable()
    {
        stateController.onstatechange -= statechangeanimation;
    }
    public void idleanimation()
    {
        torchanimator.SetBool("isidle",true);
        torchanimator.SetBool("iswalk",false);
    }
    public void walkanimation()
    {
        torchanimator.SetBool("iswalk", true);
        torchanimator.SetBool("isidle",false);
    }
    public void attackfrontanimation()
    {
        torchanimator.SetBool("iswalk", false);
        torchanimator.SetBool("isidle", false);
        torchanimator.SetTrigger("isattack");
    }
    public void attackupanimation()
    {
        torchanimator.SetBool("iswalk", false);
        torchanimator.SetBool("isidle", false);
        torchanimator.SetTrigger("isattackup");
    }
    public void attackdownanimation()
    {
        torchanimator.SetBool("iswalk", false);
        torchanimator.SetBool("isidle", false);
        torchanimator.SetTrigger("isattackdown");
    }
    public void deadanimation()
    {
        torchanimator.SetBool("iswalk", false);
        torchanimator.SetBool("isidle", false);
        torchanimator.SetBool("isdead", true);
    }

    public void statechangeanimation(TorchStateController.cunrrentstate newstate)
    {
        switch (newstate)
        {
            case TorchStateController.cunrrentstate.idle:
                idleanimation();
                break;
            case TorchStateController.cunrrentstate.chase:
                walkanimation();
                break;
            case TorchStateController.cunrrentstate.attackfront:
                attackfrontanimation();
                break;
            case TorchStateController.cunrrentstate.attackup:
                attackupanimation();
                break;
            case TorchStateController.cunrrentstate.attackdown:
                attackdownanimation();
                break;
            case TorchStateController.cunrrentstate.dead:
                deadanimation();
                break;
            case TorchStateController.cunrrentstate.wander:
                walkanimation();
                break;
        }
    }
}
