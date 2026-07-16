using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowController : MonoBehaviour
{
    public enum currentstate { playing,bossintro, bossfight,gameover,win}
    public bool ispaused=false;
    public currentstate gamestate;
    public PlayerAnimation playeranimation;
    public BossAnimation bossanimation;
    public GameoverUI gameoverui;
    public PauseUI pauseui;
    public WinUI winui;
    public event Action<currentstate> onstatechanged;
    public event Action<bool> onpausechanged;
    private void OnEnable()
    {
        pauseui.oncontinuedown += resume;
        bossanimation.ondeadend += killedboss;
        playeranimation.ondeadend += ondeadfinish;
    }
    private void OnDisable()
    {
        pauseui.oncontinuedown -= resume;
        bossanimation.ondeadend -= killedboss;
        playeranimation.ondeadend -= ondeadfinish;
    }
    public void resume()
    {
        setpause(false);
    }
    public void killedboss()
    {
        enterwin();
    }
    public void ondeadfinish()
    {
        entergameover();
    }
    public void changegamestate(currentstate newstate)
    {
        if (gamestate == newstate)
        {
            return;
        }
        else
        {
            gamestate = newstate;
        }
        onstatechanged?.Invoke(gamestate);
    }
    public void setpause(bool paused)
    {
        if (paused&&!CanPause())
        {
            return;
        }
        if (ispaused == paused)
        {
            return;
        }
        else
        {
            ispaused = paused;
        }
        Time.timeScale = ispaused?0:1;
        onpausechanged?.Invoke(paused);
        if (ispaused)
        {
            pauseui.Show();
        }
        else
        {
            pauseui.Hide();
        }
    }
    public void entergameover()
    {
        if (ispaused)
        {
            setpause(false);
        }
        changegamestate(currentstate.gameover);
        Time.timeScale = 0;
        gameoverui.Show();
    }
    public void enterwin()
    {
        if (ispaused)
        {
            setpause(false);
        }
        changegamestate(currentstate.win);
        Time.timeScale = 0;
        winui.Show();
    }
    private bool CanPause()
    {
        return gamestate == currentstate.playing
            || gamestate == currentstate.bossfight;
    }
    private void Update()
    {
        if (gamestate == currentstate.gameover||gamestate==currentstate.win)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!CanPause())
            {
                return;
            }
            if (ispaused)
            {
                if (pauseui.tryback())
                {
                    return;
                }
                setpause(false);
            }
            else
            {
                setpause(true);
            }
        }
    }
}
