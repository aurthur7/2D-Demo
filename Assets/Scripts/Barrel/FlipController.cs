using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    public Transform barreltransform;
    public SpriteRenderer sprite;
    public MonsterBarrelStateController statecontroller;
    private void Awake()
    {
        barreltransform = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        statecontroller =GetComponent<MonsterBarrelStateController>();
    }
    private void FixedUpdate()
    {
        if (statecontroller.state==MonsterBarrelStateController.cunrrentstate.dead
            || statecontroller.state==MonsterBarrelStateController.cunrrentstate.explore)
        {
            return;
        }
        isFlip();
    }
    void isFlip()
    {
        float a = Vector2.Dot(barreltransform.position-Player.Instance.transform.position,Vector2.right);
        if (a > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

}
