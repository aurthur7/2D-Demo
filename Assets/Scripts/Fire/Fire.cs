using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour,IPoolable
{
    public Collider2D firecollider;
    public FireAnimation fireanimation;
    public int firedamage = 1;
    private void Awake()
    {
        firecollider = GetComponent<Collider2D>();
        fireanimation = GetComponent<FireAnimation>();
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
                gethit.GetHit(firedamage);
            }
        }
    }
    public void onSpawned()
    {
        fireanimation.warninganimation();
        firecollider.enabled = false;
    }
    public void onDespawned()
    {
        fireanimation.warninganimation();
        firecollider.enabled=false;
    }
    public void activefire()
    {
        StartCoroutine(firetime());
    }
    IEnumerator firetime()
    { 
        firecollider.enabled=true;
        fireanimation.fireanimation();
        yield return new WaitForSeconds(2);
        PoolManager.Instance.giveback("Fire",gameObject);
    }

}
