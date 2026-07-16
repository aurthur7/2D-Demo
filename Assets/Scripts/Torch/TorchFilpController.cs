using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFilpController : MonoBehaviour
{
    public Transform torchtransform;
    public TorchStateController stateController;
    public SpriteRenderer torchsprite;
    public BoxCollider2D hitboxfront;
    private void Awake()
    {
        torchtransform = GetComponent<Transform>();
        stateController = GetComponent<TorchStateController>();
        torchsprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (stateController.state == TorchStateController.cunrrentstate.attackfront
            || stateController.state == TorchStateController.cunrrentstate.attackup
            || stateController.state == TorchStateController.cunrrentstate.attackdown)
        {
            return;
        }
        isflip();
    }
    void isflip()
    {
        Vector2 pos=hitboxfront.offset;
        float x=Mathf.Abs(pos.x);
        float dot = Vector2.Dot(torchtransform.position-Player.Instance.transform.position,Vector2.right);
        if (dot < 0)
        {
            torchsprite.flipX = false;
            pos.x = x;
        }
        else
        {
            torchsprite.flipX = true;
            pos.x = -x;
        }
        hitboxfront.offset = pos;
        if (stateController.state == TorchStateController.cunrrentstate.wander)
        {
            float dot2= Vector2.Dot(stateController.point-torchtransform.position, Vector2.right);
            if (dot2 < 0)
            {
                torchsprite.flipX = true;
            }
            else
            {
                torchsprite.flipX = false;
            }
        }
    }
}
