using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameballCircleMove : MonoBehaviour, IPoolable
{
    public float rotatespeed = 80;
    private Coroutine circlecor;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -rotatespeed * Time.fixedDeltaTime);
    }
    public void onSpawned()
    {
        //circlecor = StartCoroutine(recycle());
    }
    public void onDespawned()
    {
        //if (circlecor != null)
        //{
        //    StopCoroutine(circlecor);
        //    circlecor=null;
        //}
        transform.SetParent(null);
        transform.localPosition = Vector3.zero;
        this.transform.eulerAngles = Vector3.zero;
    }
    //IEnumerator recycle()
    //{
    //    yield return new WaitForSeconds(5);
    //    PoolManager.Instance.giveback("FlameballCircle",gameObject);
    //}
}
