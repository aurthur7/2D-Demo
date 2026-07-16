using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flameball : MonoBehaviour
{
    public int damage = 1;
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
                gethit.GetHit(damage);
            }
        }
    }
}
