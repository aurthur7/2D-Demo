using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public UINavigator navigator;
    public EditUI editui;
    public GameObject menupanel;
    private void Awake()
    {
        navigator.setroot(menupanel);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
    public void GameStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void Edit()
    {
        navigator.opennewpage(menupanel, editui.editpanel);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void backfromsetting()
    {
        menupanel.SetActive(true);
        show();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (navigator.backtopage())
            {
                return;
            }
            Exit();
        }
    }
}
