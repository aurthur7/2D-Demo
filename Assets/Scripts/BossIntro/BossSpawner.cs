using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameFlowController gameflowcontroller;
    public GameObject boss;
    private void OnEnable()
    {
        gameflowcontroller.onstatechanged += spawn;
    }
    private void OnDisable()
    {
        gameflowcontroller.onstatechanged -= spawn;
    }
    public void spawn(GameFlowController.currentstate newstate)
    {
        if (newstate == GameFlowController.currentstate.bossfight)
        {
            boss.SetActive(true);
            boss.transform.position = Player.Instance.transform.position + new Vector3(8, 8, 0);
        }
    }
}
