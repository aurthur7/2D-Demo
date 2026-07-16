using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWaveAttack : MonoBehaviour
{
    private int damage = 1;
    public Collider2D hitbox;
    private void Awake()
    {
       hitbox = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        else
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                collision.gameObject.TryGetComponent<IGetHit>(out IGetHit gethit);
                gethit.GetHit(damage);
            }
        }
    }
    public void openhitbox()
    {
        hitbox.enabled = true;
    }
    public void closehitbox()
    {
        hitbox.enabled= false;
    }
}
