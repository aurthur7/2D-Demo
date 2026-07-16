using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBarrelattack : MonoBehaviour
{
    
    public int exploredamage=1;
    public Transform monsterbarreltransform;
    public MonsterBarrelStateController statecontroller;
    public MonsterBarrelMove monsterBarrelMove;
    private CircleCollider2D monsterbarrelcollider;
    public BarrelAnimation barrelanimator;
    // Start is called before the first frame update
    void Awake()
    {
        monsterbarrelcollider = GetComponent<CircleCollider2D>();
        monsterbarreltransform = GetComponent<Transform>();
        statecontroller = GetComponent<MonsterBarrelStateController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (statecontroller.state==MonsterBarrelStateController.cunrrentstate.explore
            ||statecontroller.state==MonsterBarrelStateController.cunrrentstate.dead)
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
            statecontroller.changestate(MonsterBarrelStateController.cunrrentstate.explore);
        }
    }

    public void explore()
    {
        Collider2D[] colli= Physics2D.OverlapCircleAll(monsterbarreltransform.position,1f);
        if (colli == null)
        {
            return;
        }
        else
        {
            foreach (Collider2D col in colli)
            {
                if(col.gameObject.CompareTag("Player")&&col.TryGetComponent<IGetHit>(out IGetHit gethit))
                    gethit.GetHit(exploredamage);
            }
        }
        
    }

}
