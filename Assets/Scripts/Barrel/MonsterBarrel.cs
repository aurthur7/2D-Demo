using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MonsterBarrel : MonoBehaviour,IGetHit,Iaudioevent
{
    public event Action ondead;
    public event Action ongethit;
    private SpriteRenderer sprite;
    public MonsterBarrelMove monsterBarrelMove;
    public int hp = 1;
    public BarrelAnimation barrelanimator;
    public MonsterBarrelStateController stateController;
    public void GetHit(int playerdamage)
    {
        if (stateController.state==MonsterBarrelStateController.cunrrentstate.dead
            ||stateController.state == MonsterBarrelStateController.cunrrentstate.explore)
        {
            return;
        }
        hp-=playerdamage;
        if (hp <= 0)
        {
            hp = 0;
            ondead?.Invoke();
            stateController.changestate(MonsterBarrelStateController.cunrrentstate.dead);
        }
        else
        {
            ongethit?.Invoke();
            StartCoroutine(takedamageanimation());
        }
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        monsterBarrelMove = GetComponent<MonsterBarrelMove>();
        barrelanimator=GetComponent<BarrelAnimation>();
        stateController=GetComponent<MonsterBarrelStateController>();
    }
    public void give()
    {
        PoolManager.Instance.giveback("Monster_Barrel", gameObject);
    }
    IEnumerator takedamageanimation()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
