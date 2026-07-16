using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public static Player Instance{ get; private set; }
    // Start is called before the first frame update
    
    private void Awake()
    {
        if (Instance == null)
        {
             Instance=this;
        }
    }
}
