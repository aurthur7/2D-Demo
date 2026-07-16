using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    public Animator fireanimator;
    private void Awake()
    {
        fireanimator = GetComponent<Animator>();
    }
    public void warninganimation()
    {
        fireanimator.SetBool("iswarning",true);
        fireanimator.SetBool("isfire",false);
    }
    public void fireanimation()
    {
        fireanimator.SetBool("isfire",true);
        fireanimator.SetBool("iswarning",false);
    }
}
