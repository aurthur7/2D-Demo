using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bomb : MonoBehaviour,IPoolable
{
    public int exploredamage = 1;
    public float movespeed=2f;
    public Vector3 start;
    public Vector3 target;
    public float time;
    public float high=2f;
    public float flytime=1.5f;
    public bool isfly=false;
    public Bombstatecontroller bombcontroller;
    public Bombanimation bombanimation;
    public void onSpawned()
    {
        StopAllCoroutines();
        isfly = false;
        time = 0;
        start = Vector3.zero;
        target = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
        bombanimation.bombannimation.SetBool("explore", false);
        bombcontroller.ChangeState(Bombstatecontroller.bombstate.none);
    }
    public void onDespawned()
    {
        StopAllCoroutines();
        isfly = false;
        time = 0;
        start = Vector3.zero;
        target = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.identity;
        bombanimation.bombannimation.SetBool("explore", false);
        bombcontroller.ChangeState(Bombstatecontroller.bombstate.none);
    }
    private void Awake()
    {
        bombanimation=GetComponent<Bombanimation>();
        bombcontroller = GetComponent<Bombstatecontroller>();
    }
    private void FixedUpdate()
    {
        if (isfly)
        {
            gameObject.transform.Rotate(Vector3.forward,200f, Space.Self);
        }
    }
    public void beforefly()
    {
        time = 0;
        start=transform.position;
        target=Player.Instance.transform.position;
        bombcontroller.ChangeState(Bombstatecontroller.bombstate.flying);
        StartCoroutine(fly());
    }
    IEnumerator fly()
    {
        while (time<flytime)
        {
            isfly = true;
            time += Time.deltaTime;
            float t = time / flytime;
            Vector3 horizontalposition = Vector3.Lerp(start, target, t);
            float height = Mathf.Sin(t * Mathf.PI) * high;
            this.transform.position = horizontalposition + new Vector3(0, height, 0);
            yield return null;
        }
        isfly = false;
        yield return new WaitForSeconds(3f);
        bombcontroller.ChangeState(Bombstatecontroller.bombstate.explore);
        explore();
        yield return new WaitForSeconds(0.5f) ;
        PoolManager.Instance.giveback("Bomb",gameObject);
    }
    public void explore()
    {
        Collider2D[] hits= Physics2D.OverlapCircleAll(transform.position,1.5f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player")&&hit.TryGetComponent<IGetHit>(out IGetHit gethit))
            {
                gethit.GetHit(exploredamage);
            }
        }
        
    }
}
