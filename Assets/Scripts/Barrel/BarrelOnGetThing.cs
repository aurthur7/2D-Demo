using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelOnGetThing : MonoBehaviour,IPoolable
{
    public MonsterBarrelStateController statecontroller;
    public MonsterBarrel monsterbarrel;
    public BarrelAnimation barrelanimation;
    public MonsterEvacuate evacuate;
    private void Awake()
    {
        evacuate = GetComponent<MonsterEvacuate>();
        statecontroller = GetComponent<MonsterBarrelStateController>();
        monsterbarrel = GetComponent<MonsterBarrel>();
        barrelanimation = GetComponent<BarrelAnimation>();
    }
    public void onSpawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.register(evacuate);
        monsterbarrel.hp = 1;
        barrelanimation.Barrelanimator.SetBool("IsDead",false);
        barrelanimation.Barrelanimator.ResetTrigger("explore");
        statecontroller.changestate(MonsterBarrelStateController.cunrrentstate.none);
        statecontroller.changestate(MonsterBarrelStateController.cunrrentstate.chase);
    }
    public void onDespawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.unregister(evacuate);
        barrelanimation.Barrelanimator.SetBool("IsDead", false);
        barrelanimation.Barrelanimator.ResetTrigger("explore");
        statecontroller.changestate(MonsterBarrelStateController.cunrrentstate.none);
    }
}
