using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHP : MonoBehaviour
{
    public BossHealth health;
    public Slider slider;
    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = health.maxhp;
        slider.value = health.nowhp;
    }
    private void OnEnable()
    {
        health.onhpchanged += updatehp;
    }
    private void OnDisable()
    {
        health.onhpchanged -= updatehp;
    }
    public void updatehp(int nowhp)
    {
        slider.value = nowhp;
    }
}
