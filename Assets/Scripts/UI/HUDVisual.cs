using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDVisual : MonoBehaviour
{
    public GameObject bosshp;
    public GameFlowController controller;
    private void OnEnable()
    {
        controller.onstatechanged += hideorshow;
    }
    private void OnDisable()
    {
        controller.onstatechanged-=hideorshow;
    }
    public void hideorshow(GameFlowController.currentstate newstate)
    {
        switch (newstate)
        {
            case GameFlowController.currentstate.bossfight:
                BossHPUIShow();
                break;
            case GameFlowController.currentstate.gameover:
            case GameFlowController.currentstate.win:
                BossHPUIHide();
                break;
        }
    }
    public void BossHPUIShow()
    {
        bosshp.SetActive(true) ;
    }
    public void BossHPUIHide()
    {
        bosshp.SetActive(false);
    }
}
