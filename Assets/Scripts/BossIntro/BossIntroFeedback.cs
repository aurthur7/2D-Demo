using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class BossIntroFeedback : MonoBehaviour
{
    public GameObject warningui;
    private BossIntroController introcontroller;
    private void Awake()
    {
        introcontroller = GetComponent<BossIntroController>();
        warningui.SetActive(false);
    }
    private void OnEnable()
    {
        introcontroller.bossintrostarted += show;
        introcontroller.bossintrofinished += hide;
    }
    private void OnDisable()
    {
        introcontroller.bossintrostarted -= show;
        introcontroller.bossintrofinished -= hide;
    }
    public void show()
    {
        warningui.SetActive(true);
    }
    public void hide()
    {
        warningui.SetActive(false); 
    }
}
