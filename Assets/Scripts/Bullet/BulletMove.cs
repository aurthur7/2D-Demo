using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 dir;
    public float movespeed=2;
    private void FixedUpdate()
    {
        transform.position += dir  *movespeed*Time.fixedDeltaTime;
    }
    public void init(Vector3 movedir,Vector3 spawnposition)
    {
        dir= movedir;
        transform.position = spawnposition;
    }
}
