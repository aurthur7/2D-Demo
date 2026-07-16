using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircleMove : MonoBehaviour,IPoolable
{
    private float movespeed=3;
    public float rotatespeed = 80;
    private Coroutine bulletcirclecor;
    public Vector3 dir;
    private void FixedUpdate()
    {
        transform.position += dir*movespeed*Time.fixedDeltaTime;
        transform.Rotate(Vector3.forward,rotatespeed*Time.fixedDeltaTime);
    }
    public void init(Vector3 spawnposition,Vector3 targetposition)
    {
        transform.position = spawnposition;
        dir = (targetposition - transform.position).normalized;
    }
    public void onSpawned()
    {
       bulletcirclecor= StartCoroutine(recycle());
    }
    public void onDespawned()
    {
        if (bulletcirclecor != null)
        {
            StopCoroutine(bulletcirclecor);
            bulletcirclecor=null;
        }
        dir=Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
    IEnumerator recycle()
    {
        yield return new WaitForSeconds(7);
        PoolManager.Instance.giveback("BulletCircle",gameObject);
    }
}
