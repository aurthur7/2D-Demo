using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipController : MonoBehaviour
{
    public SpriteRenderer sprite;
    public PlayerStateController statecontroller;
    public PlayerInputController inputcontroller;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        statecontroller = GetComponent<PlayerStateController>();
        inputcontroller = GetComponent<PlayerInputController>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechange += attackflip;
    }
    private void OnDisable()
    {
        statecontroller.onstatechange -= attackflip;
    }
    private void FixedUpdate()
    {
        if (statecontroller.canmove())
        {
            return;
        }
        IsFlip();
    }
    public void IsFlip()
    {
        float horizontal = inputcontroller.moveinput.x;
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
        }
        else
            return;
    }
    public void attackflip(PlayerStateController.currentstate newstate)
    {
        if (newstate == PlayerStateController.currentstate.attackdown
            || newstate == PlayerStateController.currentstate.attackup
            || newstate == PlayerStateController.currentstate.attackfront)
        {
            float a = Vector3.Dot(inputcontroller.dir, Vector2.right);
            if (a >= 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }
}
