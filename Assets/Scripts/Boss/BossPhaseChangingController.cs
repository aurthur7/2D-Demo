using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseChangingController : MonoBehaviour
{
    public BossPhaseController phasecontroller;
    public BossAnimation bossanimation;
    public MonsterCreat monstercreatcontroller;
    public bool istransioning = false;
    public BossHealth bosshealth;
    public BossMoveController movecontroller;
    public BossAttackController attackcontroller;
    public BossStateController statecontroller;
    private void Awake()
    {
        phasecontroller = GetComponent<BossPhaseController>();
        bossanimation = GetComponent<BossAnimation>();
        bosshealth = GetComponent<BossHealth>();
        movecontroller = GetComponent<BossMoveController>();
        attackcontroller = GetComponent<BossAttackController>();
        statecontroller = GetComponent<BossStateController>();
    }
    private void OnEnable()
    {
        phasecontroller.phaserequest += phasechanging;
    }
    private void OnDisable()
    {
        phasecontroller.phaserequest -= phasechanging;
    }
    public void phasechanging(BossPhaseController.currentphase newphase)
    {
        if (istransioning)
        {
            return;
        }
        if (newphase == BossPhaseController.currentphase.phase2)
        {
            StartCoroutine(phase1to2transition());
        }
    }
    IEnumerator phase1to2transition()
    {
        statecontroller.changestate(BossStateController.currentstate.phasechanging);
        istransioning =true;
        bosshealth.ishurtable = false;
        movecontroller.stopmove();
        attackcontroller.stopattack();
        yield return StartCoroutine(bossanimation.phasevisualfadeout()); ;
        transform.position = new Vector3(500,500,-10);
        monstercreatcontroller.phasechangingmonsterlist();
        yield return new WaitUntil(() => monstercreatcontroller.monstercleared());
        transform.position=Player.Instance.transform.position+new Vector3(4,4,0);
        phasecontroller.changephase(BossPhaseController.currentphase.phase2);
        yield return StartCoroutine(bossanimation.phasevisualfadein()); ;
        statecontroller.changestate(BossStateController.currentstate.idle);
        istransioning = false;
        bosshealth.ishurtable = true;

    }
}
