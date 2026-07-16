using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D playerrb;
    public int movespeed=200;
    public float horizontal;
    public float vertical;
    public PlayerStateController stateController;
    public PlayerInputController inputcontroller;
    // Start is called before the first frame update
    void Awake()
    {
        playerrb=GetComponent<Rigidbody2D>();
        stateController=GetComponent<PlayerStateController>();
        inputcontroller=GetComponent<PlayerInputController>();
    }
    private void FixedUpdate()
    {
        if (stateController.canmove())
        {
            playerrb.velocity = Vector3.zero;
            return;
        }
        moveto();
    }
    public void moveto()
    {
        playerrb.velocity = new Vector2(inputcontroller.moveinput.x, inputcontroller.moveinput.y).normalized * movespeed * Time.fixedDeltaTime;
    }
}
