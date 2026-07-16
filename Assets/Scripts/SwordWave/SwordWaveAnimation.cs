using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWaveAnimation : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void attackanimation()
    {
        animator.SetTrigger("isattack");
    }
}
