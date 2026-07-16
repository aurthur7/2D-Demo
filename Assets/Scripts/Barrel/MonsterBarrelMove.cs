using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterBarrelMove : MonoBehaviour
{
    public Transform monsterBarreltransform;
    private Vector3 start;
    private Vector3 target;
    public float movespeed = 2f;
    public MonsterBarrelStateController controller;
    // Start is called before the first frame update
    void Awake()
    {
        monsterBarreltransform = GetComponent<Transform>();
        controller = GetComponent<MonsterBarrelStateController>();
    }

    private void FixedUpdate()
    {
        if(controller.state == MonsterBarrelStateController.cunrrentstate.dead 
            || controller.state == MonsterBarrelStateController.cunrrentstate.explore)
        {
            return;
        }
        moveto();
    }
    public void moveto()
    {
        start = monsterBarreltransform.position;
        target = Player.Instance.transform.position;
        monsterBarreltransform.position = Vector3.MoveTowards(start, target, movespeed * Time.fixedDeltaTime);
    }

}
