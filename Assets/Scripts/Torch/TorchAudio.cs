using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAudio : MonoBehaviour
{
    public Torch torch;
    public AudioClip gethitclip;
    public AudioClip deadclip;
    private void Awake()
    {
        torch=GetComponent<Torch>();
    }
    private void OnEnable()
    {
        torch.ondead += deadplay;
        torch.ongethit +=gethitplay;
    }
    private void OnDisable()
    {
        torch.ondead -= deadplay;
        torch.ongethit -=gethitplay;
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
