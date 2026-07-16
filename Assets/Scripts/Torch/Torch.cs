using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Torch : MonoBehaviour,IGetHit,Iaudioevent
{
    public int hp = 2;
    private SpriteRenderer sprite;
    public event Action ongethit;
    public event Action ondead;
    public TorchStateController statecontroller;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        statecontroller = GetComponent<TorchStateController>();
    }
    public void GetHit(int playerdamage)
    {
        if (statecontroller.state == TorchStateController.cunrrentstate.dead)
        {
            return;
        }
        hp-=playerdamage;
        if (hp <= 0)
        {
            hp = 0;
            ondead?.Invoke();
            statecontroller.statechange(TorchStateController.cunrrentstate.dead);
        }
        else
        {
            ongethit?.Invoke();
            StartCoroutine(takedamageanimation());
        }
    }
    public void ondeadend()
    {
        PoolManager.Instance.giveback("Monster_Torch",gameObject);
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
