using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTNTAttack : MonoBehaviour
{
    public Transform throwpoint;
    public MonsterTNTStateController TNTStateController;

    private void Awake()
    {
        TNTStateController = GetComponent<MonsterTNTStateController>();
    }

    private void OnEnable()
    {
        TNTStateController.oncunrrentstatechange += attackstate;
    }
    private void OnDisable()
    {
        TNTStateController.oncunrrentstatechange -= attackstate;
    }
    public void attackstate(MonsterTNTStateController.cunrrentstate ringstate)
    {
        if (ringstate == MonsterTNTStateController.cunrrentstate.attack)
        {   
            attack();
        }
    }
    public void attack()
    {
        GameObject boom= PoolManager.Instance.get("Bomb");
        boom.transform.position=throwpoint.position;
        boom.GetComponent<Bomb>().beforefly();
    }
}
