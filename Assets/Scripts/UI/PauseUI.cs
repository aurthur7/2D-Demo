using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public UINavigator navigator;
    public event Action oncontinuedown;
    public GameObject pausepanel;
    public EditUI editui;
    public void Show()
    {
        pausepanel.SetActive(true);
        navigator.setroot(pausepanel);
    }
    public void Hide()
    {
        pausepanel.SetActive(false);
        editui.hide();
        navigator.clear();
    }
    public void Continue()
    {
        oncontinuedown?.Invoke();
    }
    public bool tryback()
    {
        return navigator.backtopage();
    }
    public void Setting()
    {
        navigator.opennewpage(pausepanel,editui.editpanel);
    }
    public void toMenu()
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void backfromsetting()
    {
        pausepanel.SetActive(true);
        editui.hide();
    }
}
