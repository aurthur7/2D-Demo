using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class MonsterTNTMove : MonoBehaviour
{
    public SpriteRenderer TNTsprite;
    public MonsterTNTStateController TNTStateController;
    public Transform monsterTNTtransform;
    public Transform playertransform;
    public float movespeed = 0.1f;
    public Vector2 point;
    // Start is called before the first frame update

    private void Awake()
    {
        TNTsprite = GetComponent<SpriteRenderer>();
        monsterTNTtransform = GetComponent<Transform>();
        TNTStateController = GetComponent<MonsterTNTStateController>();
    }
    private void Start()
    {
        playertransform = Player.Instance.GetComponent<Transform>();
    }
    private void OnEnable()
    {
        TNTStateController.oncunrrentstatechange += onenterwander;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        switch (TNTStateController.state)
        {
            case MonsterTNTStateController.cunrrentstate.chase:
                chase();
                break;
            case MonsterTNTStateController.cunrrentstate.escape:
                escape();
                break;
            case MonsterTNTStateController.cunrrentstate.wander:
                wander();
                break;
        }

    }
    private void OnDisable()
    {
        TNTStateController.oncunrrentstatechange -= onenterwander;
    }

    public Vector2 randompoint()
    {
        float angle;
        Vector2 vec=monsterTNTtransform.position-playertransform.position;
        if (vec.y >= 0 && vec.x >= 0)
        {
            angle = UnityEngine.Random.Range(0, 90f) * Mathf.Deg2Rad;
        }
        else if (vec.y > 0 && vec.x < 0)
        {
            angle = UnityEngine.Random.Range(90f, 180f) * Mathf.Deg2Rad;
        }
        else if (vec.y < 0 && vec.x < 0)
        {
            angle = UnityEngine.Random.Range(180f, 270f) * Mathf.Deg2Rad;
        }
        else
        {
            angle = UnityEngine.Random.Range(270f, 360f) * Mathf.Deg2Rad;
        }
        float r = Mathf.Sqrt(UnityEngine.Random.Range(TNTStateController.incircle*TNTStateController.incircle,TNTStateController.outcircle*TNTStateController.outcircle));
        point = new Vector2(r*Mathf.Cos(angle),r*Mathf.Sin(angle));
        Vector2 playerposition = new Vector2(playertransform.position.x,playertransform.position.y);
        point += playerposition;
        return point;
    }
    public void chase()
    {
        if (TNTStateController.state==MonsterTNTStateController.cunrrentstate.idle
            || TNTStateController.state == MonsterTNTStateController.cunrrentstate.attack
            || TNTStateController.state == MonsterTNTStateController.cunrrentstate.dead)
        {
            return;
        }
        monsterTNTtransform.position = Vector3.MoveTowards(monsterTNTtransform.position,playertransform.position,movespeed*Time.fixedDeltaTime);
    }
    public void escape()
    {
        if (TNTStateController.state == MonsterTNTStateController.cunrrentstate.idle
            || TNTStateController.state == MonsterTNTStateController.cunrrentstate.attack
            || TNTStateController.state == MonsterTNTStateController.cunrrentstate.dead)
        {
            return ;
        }
        Vector3 dir=(monsterTNTtransform.position-playertransform.position).normalized;
        monsterTNTtransform.position+=dir*movespeed*Time.fixedDeltaTime;
    }
    public void wander()
    {
        monsterTNTtransform.position = Vector3.MoveTowards(monsterTNTtransform.position,point,movespeed*Time.fixedDeltaTime);
    }
    public void onenterwander(MonsterTNTStateController.cunrrentstate newstate)
    {
        if (newstate == MonsterTNTStateController.cunrrentstate.wander)
        {
            randompoint();
        }
    }
    public bool hasarrived()
    {
        float a = Vector2.Distance(monsterTNTtransform.position,point);
        if (a < 0.1f)
        {
            return true;
        }
        else
            return false;
    }
    
}



