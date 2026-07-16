using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombanimation : MonoBehaviour
{
    public Animator bombannimation;
    public Bombstatecontroller bombstatecontroller;
    private void Awake()
    {
        bombannimation=GetComponent<Animator>();
        bombstatecontroller=GetComponent<Bombstatecontroller>();
    }
    private void OnEnable()
    {
        bombstatecontroller.onstatechange += statechangeanimation;
    }
    private void OnDisable()
    {
        bombstatecontroller.onstatechange -= statechangeanimation;
    }
    public void statechangeanimation(Bombstatecontroller.bombstate newstate)
    {
        switch (newstate)
        {
            case Bombstatecontroller.bombstate.flying:
                flyanimation();
                break;
            case Bombstatecontroller.bombstate.explore:
                exploreanimation();
                break; 
        }
    }
    public void flyanimation()
    {

    }
    public void exploreanimation()
    {
        bombannimation.SetBool("explore",true);
    }
}
