using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWave : MonoBehaviour,IPoolable
{
    public SwordWaveAnimation swordanimator;
    SwordWaveAttack attack;
    private void Awake()
    {
        swordanimator = GetComponent<SwordWaveAnimation>();
        attack = GetComponent<SwordWaveAttack>();
    }
    public void onSpawned()
    {
        attack.closehitbox();
        swordanimator.attackanimation();
    }
    public void onDespawned()
    {
        attack.closehitbox();
        swordanimator.animator.ResetTrigger("isattack");
    }
    public void recycle()
    {
        PoolManager.Instance.giveback("SwordWave",gameObject);
    }
}
