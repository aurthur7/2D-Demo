using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterEvacuate : MonoBehaviour
{
    public Iaudioevent audioevent;
    private bool isevacuating=false;
    public MonoBehaviour[] behaviours;
    public Collider2D monstercollider;
    public SpriteRenderer sprite;
    private float movespeed=5f;
    private float screenpadding = 1f;
    public Vector3 dir;
    public string poolname;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioevent = GetComponent<Iaudioevent>();
    }
    private void OnEnable()
    {
        audioevent.ondead += onmonsterdead;
    }
    private void OnDisable()
    {
        audioevent.ondead-=onmonsterdead;
    }
    private void FixedUpdate()
    {
        if (isevacuating==false)
        {
            return;
        }
        gameObject.transform.position += dir * movespeed * Time.fixedDeltaTime;
        flip();
        if (isoutofscreen())
        {
            PoolManager.Instance.giveback(poolname,gameObject);
        }
    }
    public void onmonsterdead()
    {
        MonsterEvacuationController.Instance.unregister(this);
    }
    public void evacuate()
    {
        if (isevacuating == true)
        {
            return;
        }
        isevacuating=true;
        monstercollider.enabled = false;
        randomdir();
        foreach (MonoBehaviour behaviour in behaviours)
        {
            if (behaviour != null)
            {
                behaviour.enabled = false;
            }
        }
    }
    public void evacuatereset()
    {
        isevacuating = false;
        monstercollider.enabled = true;
        foreach (MonoBehaviour behaviour in behaviours)
        {
            if (behaviour != null)
            {
                behaviour.enabled = true;
            }
        }
    }
    public Vector2 randomdir()
    {
        dir=(gameObject.transform.position - Camera.main.transform.position).normalized; 
        return dir;
    }
    public bool isoutofscreen()
    {
        Camera cam=Camera.main;
        float halfheight=cam.orthographicSize;
        float halfwidth=halfheight*cam.aspect;
        Vector3 center= cam.transform.position; 
        float left= center.x-halfwidth;
        float right= center.x+halfwidth;
        float top= center.y+halfheight;
        float bottom= center.y-halfheight;
        Vector3 pos=transform.position;
        return pos.x<left-screenpadding||pos.x>right+screenpadding||pos.y<bottom-screenpadding||pos.y>top+screenpadding;
    }
    public void flip()
    {
        if (transform.position.x - Player.Instance.transform.position.x >= 0)
        {
            sprite.flipX=false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
