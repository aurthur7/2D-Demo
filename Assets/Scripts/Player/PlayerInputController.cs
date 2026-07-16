using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 attackposition;
    public Vector3 dir;
    public Vector2 moveinput;
    public bool isattackpressed=false;
    public bool canreadinput=true;
    public bool pauseinput=true;
    public bool stateinput=true;
    public GameFlowController flowController;
    private void OnEnable()
    {
        flowController.onpausechanged += pause;
        flowController.onstatechanged += over;
    }
    private void OnDisable()
    {
        flowController.onpausechanged -= pause;
        flowController.onstatechanged -= over;
    }
    public void readinput()
    {
        moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isattackpressed = Input.GetMouseButtonDown(0);
        if (isattackpressed)
        {
            attackposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = attackposition - Player.Instance.transform.position;
        }
    }
    public void over(GameFlowController.currentstate newstate)
    {
        if (newstate == GameFlowController.currentstate.gameover||newstate==GameFlowController.currentstate.win
            ||newstate==GameFlowController.currentstate.bossintro)
        {
            stateinput=false;
        }
        else
        {
            stateinput = true;
        }
        refreshinput();
    }
    public void pause(bool ispause)
    {
        pauseinput=!ispause;
        refreshinput();
    }
    public void refreshinput()
    {
        canreadinput=pauseinput&&stateinput;
    }
    void Update()
    {
        if (!canreadinput)
        {
            moveinput=Vector2.zero;
            isattackpressed = false;
            return;
        }
        readinput();
    }
}
