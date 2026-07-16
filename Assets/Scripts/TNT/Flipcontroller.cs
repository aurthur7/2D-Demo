using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static MonsterTNTStateController;

public class Flipcontroller : MonoBehaviour
{
    public Transform playertransform;
    public Transform monsterTNTtransform;
    public MonsterTNTStateController TNTStateController;
    public SpriteRenderer TNTsprite;
    public MonsterTNTMove move;
    
    private void Awake()
    {
        monsterTNTtransform=GetComponent<Transform>();
        TNTStateController=GetComponent<MonsterTNTStateController>();
        TNTsprite=GetComponent<SpriteRenderer>();   
        move = GetComponent<MonsterTNTMove>();
    }
    private void Start()
    {
        playertransform = Player.Instance.GetComponent<Transform>();
    }
    private void OnEnable()
    {
        TNTStateController.oncunrrentstatechange += onchangetoattack;
    }
    private void OnDisable()
    {
        TNTStateController.oncunrrentstatechange -= onchangetoattack;
    }
    public void onchangetoattack(MonsterTNTStateController.cunrrentstate newstate)
    {
        if (newstate == MonsterTNTStateController.cunrrentstate.attack)
        {
            isFlip();
        }
    }
    public void isFlip()
    {
        float a = Vector2.Dot(monsterTNTtransform.position - playertransform.position, Vector2.right);
        //需要面向角色的：chase,idle,attack
        //背对角色的：escape
        //随机面向：wander
        if (TNTStateController. state == cunrrentstate.idle || TNTStateController.state == cunrrentstate.attack)
        {
            if (a >= 0)
            {
                TNTsprite.flipX = true;
            }
            else 
            {
                TNTsprite.flipX = false;
            }
        }
        if (TNTStateController.state == cunrrentstate.chase)
        {
            if (a >= 0)
            {
                TNTsprite.flipX = true;
            }
            else
            {
                TNTsprite.flipX = false;
            }
        }
        else if (TNTStateController.state == cunrrentstate.escape)
        {
            if (a >= 0)
            {
                TNTsprite.flipX = false;
            }
            else
            {
                TNTsprite.flipX = true;
            }
        }
        else if (TNTStateController.state == cunrrentstate.wander)
        {
            float b = Vector2.Dot(move.point - new Vector2(monsterTNTtransform.position.x, monsterTNTtransform.position.y), Vector2.right);
            if (b >= 0)
            {
                TNTsprite.flipX = false;
            }
            else
            {
                TNTsprite.flipX = true;
            }
        }

    }
    private void FixedUpdate()
    {
        if ( TNTStateController.state == MonsterTNTStateController.cunrrentstate.attack
            || TNTStateController.state == MonsterTNTStateController.cunrrentstate.dead)
        {
            return;
        }
        isFlip();
    }
}
