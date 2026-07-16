using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAudio : MonoBehaviour
{
    public MonsterBarrel barrel;
    public AudioClip deadclip;
    public AudioClip gethitclip;
    private void Awake()
    {
        barrel=GetComponent<MonsterBarrel>();
    }
    private void OnEnable()
    {
        barrel.ondead += deadplay;
        barrel.ongethit += gethitplay;
    }
    private void OnDisable()
    {
        barrel.ongethit -= gethitplay;
        barrel.ondead -= deadplay;
    }
    public void gethitplay()
    {
        AudioManager.Instance.SFXplay(gethitclip);
    }
    public void deadplay()
    {
        AudioManager.Instance.SFXplay(deadclip);
    }
}
