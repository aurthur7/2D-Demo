using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iaudioevent
{
    public event Action ongethit;
    public event Action ondead;
}
