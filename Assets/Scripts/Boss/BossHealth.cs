using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.U2D;

public class BossHealth : MonoBehaviour,IGetHit,Iaudioevent
{
    public BossConfig config;
    public bool ishurtable=true;
    public int maxhp => config.maxHp;
    public int nowhp ;
    private SpriteRenderer sprite;
    public event Action<int> onhpchanged;
    public event Action ondead;
    public event Action ongethit;
    private void Awake()
    {
        sprite=GetComponent<SpriteRenderer>();
        nowhp = config.maxHp;
    }
    public void GetHit(int attackdamage)
    {
        if (!ishurtable)
        {
            return;
        }
        nowhp= nowhp - attackdamage;
        if (nowhp <= 0)
        {
            nowhp = 0;
            onhpchanged?.Invoke(nowhp);
            ondead?.Invoke();
            return;
        }
        else
        {
            ongethit?.Invoke();
            onhpchanged?.Invoke(nowhp);
            StartCoroutine(gethitanimation());
        }
    }
    IEnumerator gethitanimation()
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
