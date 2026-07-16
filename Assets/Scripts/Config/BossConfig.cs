using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="BossConfig",menuName ="GameConfig/BossConfig")]
public class BossConfig : ScriptableObject
{
    [Header("Health")]
    public int maxHp = 20;
    public int phase2Hp = 10;

    [Header("Move")]
    public float moveSpeed = 2f;
    public float chaseDistance = 7f;

    [Header("Attack")]
    public float attackWindupTime = 1f;
    public float attackCooldown = 3f;
}
