using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDecisionController : MonoBehaviour
{
    public BossConfig config;
    public BossStateController statecontroller;
    public Coroutine wandertoattackcor;
    private void Awake()
    {
        statecontroller = GetComponent<BossStateController>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechanged += entostate;
    }
    private void OnDisable()
    {
        statecontroller.onstatechanged -= entostate;
    }
    public void entostate(BossStateController.currentstate newstate)
    {
        switch (newstate)
        {
            case BossStateController.currentstate.wander:
                if (wandertoattackcor == null)
                {
                    wandertoattackcor = StartCoroutine(wandertoattack());
                }
                break;
            case BossStateController.currentstate.chase:

                break;
        }
    }
    IEnumerator wandertoattack()
    {
        while (statecontroller.state == BossStateController.currentstate.wander)
        {
            yield return new WaitForSeconds(config.attackCooldown);
            if (statecontroller.state == BossStateController.currentstate.wander)
            {
                statecontroller.changestate(BossStateController.currentstate.attack);
                break;
            }
        }
        wandertoattackcor = null;
    }
}
