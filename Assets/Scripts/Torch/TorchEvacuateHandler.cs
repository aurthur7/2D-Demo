using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchEvacuateHandler : MonoBehaviour,IMonsterEvacuateHandler
{
    private TorchStateController statecontroller;
    private TorchAttack attack;
    private Animator animator;
    private void Awake()
    {
        statecontroller = GetComponent<TorchStateController>();
        attack = GetComponent<TorchAttack>();
        animator = GetComponent<Animator>();
    }
    public bool canevacuate()
    {
        return statecontroller.state != TorchStateController.cunrrentstate.dead;
    }
    public void onevacuatestart()
    {
        statecontroller.StopAllCoroutines();
        statecontroller.wandercoroutine = null;
        statecontroller.state = TorchStateController.cunrrentstate.none;
        attack.closehitbox();
        animator.ResetTrigger("isattack");
        animator.ResetTrigger("isattackup");
        animator.ResetTrigger("isattackdown");
        animator.SetBool("isidle", false);
        animator.SetBool("isdead", false);
        animator.SetBool("iswalk", true);
    }

    public void onevacuateend()
    {
        attack.closehitbox();
        animator.ResetTrigger("isattack");
        animator.ResetTrigger("isattackup");
        animator.ResetTrigger("isattackdown");
        animator.SetBool("isidle", false);
        animator.SetBool("iswalk", false);
    }
}
