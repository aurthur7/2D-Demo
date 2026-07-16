using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class OnGetThing : MonoBehaviour,IPoolable
{
    public MonsterTNTStateController statecontroller;
    public MonsterTNT monster;
    public MonsterTNTMove tntmove;
    public TNTAnimation tntanimation;
    public MonsterEvacuate evacuate;
    private void Awake()
    {
        evacuate=GetComponent<MonsterEvacuate>();
        monster = GetComponent<MonsterTNT>();
        tntmove = GetComponent<MonsterTNTMove>();
        statecontroller = GetComponent<MonsterTNTStateController>();
        tntanimation = GetComponent<TNTAnimation>();
    }
    public void onSpawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.register(evacuate);
        monster.hp = 1;
        tntmove.point = Vector3.zero;
        statecontroller.StopAllCoroutines();
        tntanimation.TNTanimator.SetBool("isdead",false);
        tntanimation.TNTanimator.SetBool("idle",false);
        tntanimation.TNTanimator.SetBool("iswalk",false);
        statecontroller.state=MonsterTNTStateController.cunrrentstate.none;
    }
    public void onDespawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.unregister(evacuate);
        statecontroller.StopAllCoroutines();
        statecontroller.ringcoroutine = null;
        tntmove.point = Vector3.zero;
        tntanimation.TNTanimator.SetBool("isdead", false);
        tntanimation.TNTanimator.SetBool("idle", false);
        tntanimation.TNTanimator.SetBool("iswalk", false);
        statecontroller.state=MonsterTNTStateController.cunrrentstate.none;

    }
}
