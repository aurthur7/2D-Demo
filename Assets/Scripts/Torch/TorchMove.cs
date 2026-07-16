
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMove : MonoBehaviour
{
    public float movespeed = 2f;
    public Transform torchtransform;
    public TorchStateController statecontroller;
    private void Awake()
    {
        torchtransform=GetComponent<Transform>();
        statecontroller=GetComponent<TorchStateController>();
    }

    private void FixedUpdate()
    {
        if (statecontroller.state == TorchStateController.cunrrentstate.chase)
        {
            chase(Player.Instance.transform.position);
        }
        if (statecontroller.state == TorchStateController.cunrrentstate.wander)
        {
            chase(statecontroller.point);
        }

    }
    public void chase(Vector3 vec)
    {
        torchtransform.position = Vector3.MoveTowards(torchtransform.position,vec,movespeed*Time.fixedDeltaTime);
    }

}
