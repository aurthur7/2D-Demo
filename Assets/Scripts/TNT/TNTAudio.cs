using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTAudio : MonoBehaviour
{
    public AudioClip gethitSFX;
    public AudioClip deadSFX;
    private MonsterTNT tnt;
    private void Awake()
    {
        tnt = GetComponent<MonsterTNT>();
    }
    private void OnEnable()
    {
        tnt.ondead += deadplay;
        tnt.ongethit += gethitplay;
    }
    private void OnDisable()
    {
        tnt.ondead -= deadplay;
        tnt.ongethit -= gethitplay;
    }
    public void gethitplay()
    {
        AudioManager.Instance.SFXplay(gethitSFX);
    }
    public void deadplay()
    {
        AudioManager.Instance.SFXplay(deadSFX);
    }
}
