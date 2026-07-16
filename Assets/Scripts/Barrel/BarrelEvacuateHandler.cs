using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEvacuateHandler : MonoBehaviour,IMonsterEvacuateHandler
{
    private MonsterBarrelStateController statecontroller;
    private Animator animator;
    private void Awake()
    {
        statecontroller = GetComponent<MonsterBarrelStateController>();
        animator = GetComponent<Animator>();
    }
    public bool canevacuate()
    {
        if (statecontroller.state == MonsterBarrelStateController.cunrrentstate.dead)
        {
            return false;
        }
        if (statecontroller.state == MonsterBarrelStateController.cunrrentstate.explore)
        {
            return false;
        }
        return true;
    }
    public void onevacuatestart()
    {
        statecontroller.state = MonsterBarrelStateController.cunrrentstate.none;
        animator.ResetTrigger("explore");
        animator.SetBool("IsDead", false);
    }
    public void onevacuateend()
    {
        animator.ResetTrigger("explore");
        animator.SetBool("IsDead", false);
    }
}
