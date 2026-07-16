using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimation playeranimator;
    public PlayerMove playermove;
    public Transform playertransform;
    public PlayerStateController statecontroller;
    public PlayerInputController inputcontroller;
    public int damage = 1;
    // Start is called before the first frame update
    void Awake()
    {
        playeranimator=Player.Instance.GetComponent<PlayerAnimation>();
        playermove=Player.Instance.GetComponent<PlayerMove>();
        playertransform=Player.Instance.GetComponent<Transform>();
        statecontroller=GetComponent<PlayerStateController>();
        inputcontroller=GetComponent<PlayerInputController>();
    }
    private void OnEnable()
    {
        statecontroller.onstatechange += onattackstate;
    }
    private void OnDisable()
    {
        statecontroller.onstatechange -= onattackstate;
    }
    public void onattackstate(PlayerStateController.currentstate newstate)
    {
        if (newstate == PlayerStateController.currentstate.attackfront
            || newstate == PlayerStateController.currentstate.attackdown
            || newstate == PlayerStateController.currentstate.attackup)
        {
            GameObject obj=PoolManager.Instance.get("SwordWave");
            obj.transform.position=inputcontroller.attackposition+new Vector3(0,0,10);
            //RaycastHit2D[] gethit = Physics2D.RaycastAll(inputcontroller.attackposition, Vector2.zero);
            //if (gethit == null)
            //{
            //    return;
            //}
            //foreach (RaycastHit2D hit in gethit)
            //{
            //    if (hit.collider.gameObject.CompareTag("Monster"))
            //    {
            //        IGetHit monsterGetHit = hit.collider.gameObject.GetComponent<IGetHit>();

            //        monsterGetHit.GetHit(damage);
            //    }
            //}
        }
    }
}
