using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip attackclip;
    public AudioClip gethitclip;
    public AudioClip deadclip;
    public PlayerHealth playerhealth;
    public PlayerStateController statecontroller;
    private void Awake()
    {
        statecontroller = GetComponent<PlayerStateController>();
        playerhealth = GetComponent<PlayerHealth>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechange += attackplay;
        playerhealth.ondead += deadplay;
        playerhealth.ongethit += gethitplay;
    }
    private void OnDisable()
    {
        statecontroller.onstatechange -= attackplay;
        playerhealth.ondead-=deadplay;
        playerhealth.ongethit -= gethitplay;
    }
    public void gethit()
    {
        AudioManager.Instance.SFXplay(gethitclip);
    }
    public void dead()
    {
        AudioManager.Instance.SFXplay(deadclip);
    }
    public void attackplay(PlayerStateController.currentstate newstate)
    {
        switch (newstate)
        {
            case PlayerStateController.currentstate.attackfront:
            case PlayerStateController.currentstate.attackup:
            case PlayerStateController.currentstate.attackdown:
                AudioManager.Instance.SFXplay(attackclip);
                break;
        }
    }
    public void deadplay()
    {
        dead();
    }
    public void gethitplay()
    {
            gethit();
    }
}
