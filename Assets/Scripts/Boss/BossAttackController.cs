using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    public BossConfig config;
    public BossPhaseController phasecontroller;
    public BossStateController statecontroller;
    public BossFirePositionController firecontroller;
    public BossAnimation bossanimation;
    public BossPhase2AttackType phase2attacktype;
    public List<Fire> fires=new List<Fire> { };
    private void Awake()
    {
        phasecontroller = GetComponent<BossPhaseController>();
        statecontroller=GetComponent<BossStateController>();
        firecontroller = GetComponent<BossFirePositionController>();
        bossanimation = GetComponent<BossAnimation>();
        phase2attacktype = GetComponent<BossPhase2AttackType>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechanged += onattackstate;
    }
    private void OnDisable()
    {
        statecontroller.onstatechanged -= onattackstate;
    }
    public void onattackstate(BossStateController.currentstate newstate)
    {
        if (newstate == BossStateController.currentstate.attack)
        {
            switch (phasecontroller.phase)
            {
                case BossPhaseController.currentphase.phase1:
                    StartCoroutine(phase1attack());
                    break;
                case BossPhaseController.currentphase.phase2:
                    StartCoroutine(phase2attack());
                    break;
            }
        }
        if (newstate == BossStateController.currentstate.dead)
        {
            stopattack();
        }
    }
    public void stopattack()
    {
        StopAllCoroutines();
        bossanimation.HideAttackVisual();
        foreach (Fire fire in fires)
        {
            if (fire != null && fire.gameObject.activeInHierarchy)
            {
                PoolManager.Instance.giveback("Fire", fire.gameObject);
            }
        }
        fires.Clear();
        firecontroller.chosenpoints.Clear();
        phase2attacktype.ClearFlameCircle();
    }
    IEnumerator phase1attack()
    {
        firecontroller.firepositionget();
        firecontroller.firetypechoser();
        for (int i = 0; i < firecontroller.chosenpoints.Count; i++)
        {
            GameObject obj = PoolManager.Instance.get("Fire");
            obj.transform.position = firecontroller.chosenpoints[i];
            Fire fire=obj.GetComponent<Fire>();
            fires.Add(fire);
        }
        yield return StartCoroutine(bossanimation.attackanimation(config.attackWindupTime));
        if (statecontroller.state == BossStateController.currentstate.dead)
        {
            yield break;
        }
        foreach (Fire fire in fires)
        {
            fire.activefire();
        }
        fires.Clear();
        yield return null;
        firecontroller.chosenpoints.Clear();
        statecontroller.changestate(BossStateController.currentstate.chase);
    }
    IEnumerator phase2attack()
    {
        yield return StartCoroutine(bossanimation.attackanimation(config.attackWindupTime));
        if (statecontroller.state == BossStateController.currentstate.dead)
        {
            yield break;
        }
        phase2attacktype.attacktypechoser();
        statecontroller.changestate(BossStateController.currentstate.chase);
    }
}
