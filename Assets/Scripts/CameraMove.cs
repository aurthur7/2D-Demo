using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playertransform;
    public Vector3 offset = new Vector3(0, 0, -10);
    public Transform cameratransform;
    // Start is called before the first frame update
    void Start()
    {
        playertransform=Player.Instance.transform;
        cameratransform=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameratransform.position = playertransform.position + offset;
    }
}
