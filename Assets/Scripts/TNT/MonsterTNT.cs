using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MonsterTNT : MonoBehaviour,IGetHit,Iaudioevent
{
    public int hp = 1;
    public event Action ongethit;
    public event Action ondead;
    private SpriteRenderer sprite;
    public MonsterTNTStateController statecontroller;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        statecontroller = GetComponent<MonsterTNTStateController>();
    }
    public void GetHit(int playerdamage)
    {
        if ( statecontroller.state== MonsterTNTStateController.cunrrentstate.dead)
        {
            return;
        }
        hp-=playerdamage;
        if (hp <= 0)
        {
            hp = 0;
            ondead?.Invoke();
            statecontroller.changestate(MonsterTNTStateController.cunrrentstate.dead);
        }
        else
        {
            ongethit?.Invoke();
            StartCoroutine(takedamageanimation());
        }
    }

    public void give()
    {
        PoolManager.Instance.giveback("Monster_TNT",gameObject);
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
