using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    public int bulletdamage = 1;
    private Coroutine recyclecoroutine;
    public BulletMove bulletmove;
    private void Awake()
    {
        bulletmove = GetComponent<BulletMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        else
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent<IGetHit>(out IGetHit gethit))
            {
                gethit.GetHit(bulletdamage);
            }
        }
    }
    public void onSpawned()
    {
        recyclecoroutine=StartCoroutine(recycle());
    }
    public void onDespawned()
    {
        if (recyclecoroutine != null)
        {
            StopCoroutine(recyclecoroutine);
            recyclecoroutine=null;
        }
        bulletmove.dir = Vector3.zero;
    }
    IEnumerator recycle()
    {
        yield return new WaitForSeconds(7);
        PoolManager.Instance.giveback("Bullet",gameObject);
    }
}
