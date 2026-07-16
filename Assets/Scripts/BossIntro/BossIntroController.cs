using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroController : MonoBehaviour
{
    public MonsterKillTracker tracker;
    public GameFlowController flowcontroller;
    private Coroutine introcoroutine;
    public event Action bossintrostarted;
    public event Action bossintrofinished;
    private void OnEnable()
    {
        tracker.achievekillnumber += bossintro;
    }
    private void OnDisable()
    {
        tracker.achievekillnumber -= bossintro;
    }
    public void bossintro()
    {
        if (introcoroutine == null)
        {
            introcoroutine = StartCoroutine(intro());
        }
    }
    IEnumerator intro()
    {
        yield return null;
        flowcontroller.changegamestate(GameFlowController.currentstate.bossintro);
        bossintrostarted?.Invoke();
        MonsterEvacuationController.Instance.startevacuateall();
        yield return new WaitUntil(()=>MonsterEvacuationController.Instance.allevacuated());
        bossintrofinished?.Invoke();
        flowcontroller.changegamestate(GameFlowController.currentstate.bossfight);
        introcoroutine=null;
    }
}
