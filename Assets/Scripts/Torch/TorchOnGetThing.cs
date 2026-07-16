using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOnGetThing : MonoBehaviour,IPoolable
{
    public Torch torch;
    public TorchStateController statecontroller;
    public Collider2D hitboxfront;
    public Collider2D hitboxup;
    public Collider2D hitboxdown;
    public TorchAnimation torchanimator;
    public MonsterEvacuate evacuate;
    private void Awake()
    {
        evacuate=GetComponent<MonsterEvacuate>();
        statecontroller = GetComponent<TorchStateController>();
        torch=GetComponent<Torch>();
        torchanimator = GetComponent<TorchAnimation>();
    }
    public void onSpawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.register(evacuate);
        torch.hp = 2;
        hitboxdown.enabled = false;
        hitboxup.enabled = false;   
        hitboxfront.enabled = false;
        statecontroller.StopAllCoroutines();
        statecontroller.point=Vector3.zero;
        torchanimator.torchanimator.SetBool("isdead",false);
        torchanimator.torchanimator.SetBool("iswalk", false);
        torchanimator.torchanimator.SetBool("isidle", false);
        statecontroller.state=TorchStateController.cunrrentstate.none;
    }
    public void onDespawned()
    {
        evacuate.evacuatereset();
        MonsterEvacuationController.Instance.unregister(evacuate);
        hitboxdown.enabled = false;
        hitboxup.enabled = false;
        hitboxfront.enabled = false;
        statecontroller.StopAllCoroutines();
        statecontroller.point = Vector3.zero;
        torchanimator.torchanimator.SetBool("isdead", false);
        torchanimator.torchanimator.SetBool("iswalk", false);
        torchanimator.torchanimator.SetBool("isidle", false);
        statecontroller.state=TorchStateController.cunrrentstate.none;
    }
}
