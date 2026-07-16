using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class BossAnimation : MonoBehaviour
{
    public Animator bossanimator;
    public SpriteRenderer bosssprite;
    public BossPhaseController phasecontroller;
    public BossStateController statecontroller;
    public GameObject magiccircle;
    public event Action ondeadend;
    public float time;
    public float durationtime=1;
    private void Awake()
    {
        bossanimator = GetComponent<Animator>();
        bosssprite = GetComponent<SpriteRenderer>();
        phasecontroller = GetComponent<BossPhaseController>();
        statecontroller=GetComponent<BossStateController>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechanged += onstatechange;
        phasecontroller.onphasechange += onphasechanged;
    }
    private void OnDisable()
    {
        statecontroller.onstatechanged -= onstatechange;
        phasecontroller.onphasechange -= onphasechanged;
    }
    public void onstatechange(BossStateController.currentstate newstate)
    {
        if (newstate == BossStateController.currentstate.dead)
        {
            deadanimation();
        }
    }
    public void onphasechanged(BossPhaseController.currentphase newphase)
    {
        switch (newphase)
        {
            case BossPhaseController.currentphase.phase1:
                phase1animation();
                break;
            case BossPhaseController.currentphase.phase2:
                phase2animation();
                break;
        }
    }
    public void phase1animation()
    {
          
    }
    public void phase2animation()
    {
        bossanimator.SetBool("1to2", true);
    }
    public void deadanimation()
    {
        bossanimator.SetBool("dead", true);
    }
    public void deadfinish()
    {
        ondeadend?.Invoke();    
    }
    public void HideAttackVisual()
    {
        magiccircle.SetActive(false);
    }
    public IEnumerator attackanimation(float attacktime)
    {
        magiccircle.SetActive(true);
        yield return new WaitForSeconds(attacktime);
        magiccircle.SetActive(false);
    }
    public IEnumerator phasevisualfadein()
    {
        Color startcolor = bosssprite.color;
        Color endcolor = new Color(1,1,1,1);
        float time = 0;
        float timecost = 1;
        while (time < timecost)
        {
            time += Time.deltaTime;
            bosssprite.color = Color.Lerp(startcolor, endcolor, time / timecost);
            yield return null;
        }
    }
    public IEnumerator phasevisualfadeout()
    {
        Color startcolor=bosssprite.color;
        Color endcolor =new Color(1,1,1,0);
        float time = 0;
        float timecost = 1;
        while (time < timecost)
        {
            time += Time.deltaTime;
            bosssprite.color = Color.Lerp(startcolor, endcolor, time / timecost);
            yield return null;
        }
    }
}
