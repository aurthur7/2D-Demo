using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerHealth : MonoBehaviour,IGetHit,Iaudioevent
{
    public struct Playerdata
    {
        public int maxhp;
        public int nowhp;
        public Playerdata(int maxhp,int nowhp)
        {
            this.maxhp = maxhp;
            this.nowhp = nowhp;
        }
    }
    public Playerdata playerdata=new Playerdata(5,5);
    public bool ishurtable=true;
    public PlayerStateController statecontroller;
    public event Action ongethit;
    public event Action ondead;
    public event Action<int, int> onhpchanged;
    public SpriteRenderer sprite;
    private void Awake()
    {
        statecontroller = GetComponent<PlayerStateController>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void GetHit(int attacknum)
    {
        if (!ishurtable)
        {
            return;
        }
        ishurtable = false;
        playerdata.nowhp = (int)MathF.Max(0,playerdata.nowhp-attacknum);
        onhpchanged?.Invoke(playerdata.nowhp, playerdata.maxhp);
        if (playerdata.nowhp <= 0)
        {
            ondead?.Invoke();
            statecontroller.statechange(PlayerStateController.currentstate.dead);
            playerdata.nowhp = 0;
            return;
        }
        else
        {
            ongethit?.Invoke();
            StartCoroutine(takedamageanimation());
        }
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
        ishurtable = true;
    }
}
