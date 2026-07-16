using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGMsource;
    public AudioSource SFXsource;
    public AudioMixer audiomixer;
    public AudioClip menuclip;
    public AudioClip fightingclip;
    public AudioClip bossintroclip;
    public AudioClip bossfightclip;
    public static AudioManager Instance { get; private set; }
    private const string SFX_VOLUME_KEY="SFXVolume";
    private const string BGM_VOLUME_KEY = "BGMVolume";
    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string SFXMUTE_KEY = "SFXMute";
    private const string BGMMUTE_KEY = "BGMMute";
    private const string MasterMUTE_KEY = "MasterMute";
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ApplySavedVolume();
    }
    public void BGMplay(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        if (BGMsource.clip == clip&&BGMsource.isPlaying)
        {
            return ;
        }
        BGMsource.clip = clip;
        BGMsource.loop = true;
        BGMsource.Play();
    }
    public void BGMstop()
    {
        BGMsource.Pause();
    }
    public void BGMcontinue()
    {
        BGMsource.UnPause();
    }
    public void BGMchange()
    {
        
    }
    public void SFXplay(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }
        SFXsource.PlayOneShot(clip);
    }
    public void menuBGMplay()
    {
        BGMplay(menuclip);
    }
    public void fightingBGMplay()
    {
        BGMplay(fightingclip);
    }
    public void bossintroBGMplay()
    {
        BGMplay(bossintroclip);
    }
    public void bossfightBGMplay()
    {
        BGMplay(bossfightclip);
    }
    public float volumetodb(float value)
    {
        if (value < 0.0001f)
        {
            return -80f;
        }
        return Mathf.Log10(value)*20f;
    }
    public void setSFXvolume(float value)
    {
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY,value);
        ApplySavedVolume();
    }
    public void setBGMvolume(float value)
    {
        PlayerPrefs.SetFloat (BGM_VOLUME_KEY,value);
        ApplySavedVolume();
    }
    public void setMastervolume(float value)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
        ApplySavedVolume();
    }
    public float getsavedSFXvolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY,1f);
    }
    public float getsavedBGMvolume()
    {
        return PlayerPrefs.GetFloat (BGM_VOLUME_KEY,1f);
    }
    public float getsavedMastervolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY,1f);
    }
    public bool getmutebool(string key)
    {
        return PlayerPrefs.GetInt(key,0)==1;
    }
    public void setmutebool(string key,bool value)
    {
        PlayerPrefs.SetInt(key,value?1:0);
    }
    public void ApplySavedVolume()
    {
        applyvolumeset("MasterVolume",getsavedMastervolume(),getmutebool("MasterMute"));
        applyvolumeset("BGMVolume", getsavedBGMvolume(), getmutebool("BGMMute"));
        applyvolumeset("SFXVolume", getsavedSFXvolume(), getmutebool("SFXMute"));
    }
    public void pressmastermute()
    {
        bool mute = getmutebool("MasterMute");
        setmutebool("MasterMute",!mute);
        ApplySavedVolume();
    }
    public void pressBGMmute()
    {
        bool mute = getmutebool("BGMMute");
        setmutebool("BGMMute",!mute);
        ApplySavedVolume() ;
    }
    public void pressSFXmute()
    {
        bool mute = getmutebool("SFXMute");
        setmutebool("SFXMute", !mute);
        ApplySavedVolume();
    }
    public bool isMastermuted()
    {
        return getmutebool("MasterMute");
    }
    public bool isBGMmuted()
    {
        return getmutebool("BGMMute");
    }
    public bool isSFXmuted()
    {
        return getmutebool("SFXMute");
    }
    public void applyvolumeset(string volumename,float volume,bool muted)
    {
        if (muted)
        {
            audiomixer.SetFloat(volumename, -80f);
            return;
        }
        else
        {
            audiomixer.SetFloat (volumename, volumetodb(volume));
        }
    }
}
