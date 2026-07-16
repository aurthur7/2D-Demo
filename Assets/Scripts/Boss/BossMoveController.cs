using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMoveController : MonoBehaviour
{
    public BossConfig config;
    public float movespeed=>config.moveSpeed;
    public Transform bosstransform;
    public Vector3 dir;
    public float angle=0;
    public float anglespeed=0.3f;
    public float radius;
    private float basedradius=3.5f;
    public float time=0;
    public float T = 2;
    public BossStateController statecontroller;
    private void Awake()
    {
        bosstransform = GetComponent<Transform>();
        statecontroller = GetComponent<BossStateController>();
    }
    private void FixedUpdate()
    {
        if (statecontroller.state == BossStateController.currentstate.attack)
        {
            return;
        }
        switch (statecontroller.state)
        {
            case BossStateController.currentstate.chase:
                chase();
                break;
            case BossStateController.currentstate.wander:
                wander();
                break;
            case BossStateController.currentstate.idle:
                break;
        }
    }
    public void wander()
    {
        time+=Time.fixedDeltaTime;
        angle += anglespeed * Time.fixedDeltaTime;
        radius=basedradius+Mathf.Sin(time*T);
        Vector3 offset = new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0) * radius;
        Vector3 targetposition=offset+Player.Instance.transform.position;
        bosstransform.position = Vector3.MoveTowards(bosstransform.position,targetposition,Time.fixedDeltaTime*movespeed);
    }
    public void chase()
    {
        dir=(Player.Instance.transform.position- bosstransform.position).normalized;
        bosstransform.position += dir*Time.fixedDeltaTime*movespeed;
    }
    public void escape()
    {
        dir = (  bosstransform.position-Player.Instance.transform.position).normalized;
        bosstransform.position += dir * Time.fixedDeltaTime * movespeed;
    }
    public void stopmove()
    {
        
    }
}
