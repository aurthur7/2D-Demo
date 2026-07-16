using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAnimation : MonoBehaviour
{
    public Animator Barrelanimator;
    public MonsterBarrelStateController statecontroller;
    // Start is called before the first frame update
    void Awake()
    {
        Barrelanimator=GetComponent<Animator>();
        statecontroller = GetComponent<MonsterBarrelStateController>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechange += statechangeanimation;
    }
    private void OnDisable()
    {
        statecontroller.onstatechange -= statechangeanimation;
    }
    public void exploreanimation()
    {
        Barrelanimator.SetTrigger("explore");
    }

    public void deadanimation()
    {
        Barrelanimator.SetBool("IsDead",true);
    }

    public void statechangeanimation(MonsterBarrelStateController.cunrrentstate newstate)
    {
        if (newstate== MonsterBarrelStateController.cunrrentstate.explore)
        {
            exploreanimation();
        }
        else if(newstate== MonsterBarrelStateController.cunrrentstate.dead)
        {
            deadanimation();
        }
    }
}
