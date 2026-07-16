using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditUI : MonoBehaviour
{
    public UINavigator navigator;
    public GameObject audiopage;
    public GameObject videopage;
    public GameObject editpanel;
    public void ShowAudioPage()
    {
        audiopage.SetActive(true);
        videopage.SetActive(false);
    }
    public void ShowVideoPage()
    {
        videopage.SetActive(true);
        audiopage.SetActive(false);
    }
    public void show()
    {
        editpanel.SetActive(true);
    }
    public void hide()
    {
        editpanel.SetActive(false);
    }
    public void back()
    {
        navigator.backtopage();
    }
}
