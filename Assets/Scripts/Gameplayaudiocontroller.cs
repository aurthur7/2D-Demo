using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplayaudiocontroller : MonoBehaviour
{
    public GameFlowController flowcontroller;
    private void OnEnable()
    {
        flowcontroller.onpausechanged += pausedbgm;
        flowcontroller.onstatechanged += onstatechange;
    }
    private void OnDisable()
    {
        flowcontroller.onpausechanged -= pausedbgm;
        flowcontroller.onstatechanged -= onstatechange;
    }
    public void onstatechange(GameFlowController.currentstate newstate)
    {
        if (newstate == GameFlowController.currentstate.bossfight)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.bossfightBGMplay();
            }
        }
        if (newstate == GameFlowController.currentstate.bossintro)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.bossintroBGMplay();
            }
        }
        if (newstate == GameFlowController.currentstate.win || newstate == GameFlowController.currentstate.gameover)
        {
            AudioManager.Instance.BGMstop();
        }
    }
    public void pausedbgm(bool ispaused)
    {
        if (ispaused == true)
        {
            AudioManager.Instance.BGMstop();
        }
        else
        {
            AudioManager.Instance.BGMcontinue();
        }
    }
    private void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.fightingBGMplay();
        }
    }
}
