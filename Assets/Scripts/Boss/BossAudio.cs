using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    public AudioClip attackclip;
    public AudioClip deadclip;
    public AudioClip gethitclip;
    private BossStateController stateController;
    private BossHealth health;
    private void Awake()
    {
        stateController=GetComponent<BossStateController>();
        health=GetComponent<BossHealth>();
    }
    private void OnEnable()
    {
        stateController.onstatechanged += attackplay;
        health.ongethit += gethitplay;
        health.ondead += deadplay;
    }
    private void OnDisable()
    {
        stateController.onstatechanged -= attackplay;
        health.ongethit -= gethitplay;
        health.ondead -= deadplay;
    }
    public void attackplay(BossStateController.currentstate newstate)
    {
        if (newstate == BossStateController.currentstate.attack)
        {
            AudioManager.Instance.SFXplay(attackclip);
        }
    }
    public void deadplay()
    {
        AudioManager.Instance.SFXplay(deadclip);
    }
    public void gethitplay()
    {
        AudioManager.Instance.SFXplay(gethitclip);
    }
}
