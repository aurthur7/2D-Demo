using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTAnimation : MonoBehaviour
{
    public Animator TNTanimator;
    public MonsterTNTStateController TNTStateController;
    public void idleanimation()
    {
        TNTanimator.SetBool("idle",true);
        TNTanimator.SetBool("iswalk",false);
    }
    public void attackanimation()
    {
        TNTanimator.SetBool("iswalk", false);
        TNTanimator.SetBool("idle", false);
        TNTanimator.SetTrigger("attack");
    }
    public void walkanimation()
    {
        TNTanimator.SetBool("iswalk",true);
        TNTanimator.SetBool("idle", false);
    }
    public void deadanimation()
    {
        TNTanimator.SetBool("isdead", true);
    }
    public void cunrrentanimationplayer(MonsterTNTStateController.cunrrentstate newstate)
    {
        switch (newstate)
        {
            case MonsterTNTStateController.cunrrentstate.chase:
            case MonsterTNTStateController.cunrrentstate.escape:
            case MonsterTNTStateController.cunrrentstate.wander:
                walkanimation();
                break;
            case MonsterTNTStateController.cunrrentstate.dead:
                deadanimation(); 
                break;
            case MonsterTNTStateController.cunrrentstate.idle:
                idleanimation();
                break;
            case MonsterTNTStateController.cunrrentstate.attack:
                attackanimation();
                break;
        }
    }
    void Awake()
    {
        TNTanimator=GetComponent<Animator>();
        TNTStateController=GetComponent<MonsterTNTStateController>();
    }
    private void OnEnable()
    {
        TNTStateController.oncunrrentstatechange += cunrrentanimationplayer;
    }
    private void OnDisable()
    {
        TNTStateController.oncunrrentstatechange -= cunrrentanimationplayer;
    }

}
