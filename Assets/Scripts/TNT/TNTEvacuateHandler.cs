using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTEvacuateHandler : MonoBehaviour,IMonsterEvacuateHandler
{
    private MonsterTNTStateController statecontroller;
    private Animator animator;
    private void Awake()
    {
        statecontroller = GetComponent<MonsterTNTStateController>();
        animator = GetComponent<Animator>();
    }
    public bool canevacuate()
    {
        return statecontroller.state != MonsterTNTStateController.cunrrentstate.dead;
    }
    public void onevacuatestart()
    {
        statecontroller.StopAllCoroutines();
        statecontroller.ringcoroutine = null;
        statecontroller.state = MonsterTNTStateController.cunrrentstate.none;
        animator.ResetTrigger("attack");
        animator.SetBool("idle", false);
        animator.SetBool("isdead", false);
        animator.SetBool("iswalk", true);
    }

    public void onevacuateend()
    {
        animator.ResetTrigger("attack");
        animator.SetBool("idle", false);
        animator.SetBool("iswalk", false);
    }
}
