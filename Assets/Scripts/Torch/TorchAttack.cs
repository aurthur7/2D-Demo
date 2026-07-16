using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAttack : MonoBehaviour
{
    public TorchStateController statecontroller;
    public Collider2D fronthitbox;
    public Collider2D uphitbox;
    public Collider2D downhitbox;
    private void Awake()
    {
        statecontroller = GetComponent<TorchStateController>(); 
    }
    public void openhitbox()
    {
        switch (statecontroller.state)
        {
            case TorchStateController.cunrrentstate.attackfront:
                fronthitbox.enabled = true;
                break;
            case TorchStateController.cunrrentstate.attackup:
                uphitbox.enabled = true;
                break;
            case TorchStateController.cunrrentstate.attackdown:
                downhitbox.enabled = true;
                break;
        }
    }
    public void closehitbox()
    {
        fronthitbox.enabled = false;
        uphitbox.enabled = false;
        downhitbox.enabled = false;
    }
}
