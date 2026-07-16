using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingUI : MonoBehaviour
{
    public Slider bgmslider;
    public Slider sfxslider;
    public Slider masterslider;
    public Image masterimage;
    public Image bgmimage;
    public Image sfximage;
    public Sprite normalsprite;
    public Sprite mutedsprite;
    private void Start()
    {
        if (AudioManager.Instance == null)
        {
            return;
        }
        float mastervolume=AudioManager.Instance.getsavedMastervolume();
        float bgmvolume=AudioManager.Instance.getsavedBGMvolume();
        float sfxvolume=AudioManager.Instance.getsavedSFXvolume();
        masterslider.value = mastervolume;
        bgmslider.value = bgmvolume;
        sfxslider.value = sfxvolume;
        AudioManager.Instance.ApplySavedVolume();
        refreshsprite();
    }
    public void onBGMsliderchange(float value)
    {
        AudioManager.Instance.setBGMvolume(value);
    }
    public void onSFXsliderchange(float value)
    {
        AudioManager.Instance.setSFXvolume(value);
    }
    public void onMasterSliderchange(float value)
    {
        AudioManager.Instance.setMastervolume(value);
    }
    public void refreshsprite()
    {
        masterimage.sprite = AudioManager.Instance.isMastermuted() ? mutedsprite : normalsprite;
        bgmimage.sprite = AudioManager.Instance.isBGMmuted() ? mutedsprite : normalsprite;
        sfximage.sprite = AudioManager.Instance.isSFXmuted() ? mutedsprite : normalsprite;
    }
    public void BGMmute()
    {
        AudioManager.Instance.pressBGMmute();
        refreshsprite();
    }
    public void SFXmute()
    {
        AudioManager.Instance.pressSFXmute();
        refreshsprite();
    }
    public void Mastermute()
    {
        AudioManager.Instance.pressmastermute();
        refreshsprite();
    }
}
