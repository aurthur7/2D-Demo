using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlipController : MonoBehaviour
{
    public SpriteRenderer bosssprite;
    public BossStateController statecontroller;
    public float isflip;
    private void Awake()
    {
        bosssprite = GetComponent<SpriteRenderer>();
        statecontroller = GetComponent<BossStateController>();
    }
    private void Update()
    {
        if (statecontroller.state == BossStateController.currentstate.attack
            || statecontroller.state == BossStateController.currentstate.dead)
        {
            return;
        }
        Flip();
    }
    public void Flip()
    {
        isflip = Player.Instance.transform.position.x - transform.position.x;
        if (isflip >= 0)
        {
            bosssprite.flipX=false;
        }
        else
        {
            bosssprite.flipX = true;
        }
    }
}
