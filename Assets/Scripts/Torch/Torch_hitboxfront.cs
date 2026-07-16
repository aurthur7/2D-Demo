using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_hitboxfront : MonoBehaviour
{
    public int attackdamage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }
        else
        {
            if (collision.gameObject.CompareTag("Player") && collision.TryGetComponent<IGetHit>(out IGetHit gethit))
            {
                gethit.GetHit(attackdamage);
            }
        }
    }
}
