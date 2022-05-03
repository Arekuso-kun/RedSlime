using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;

    float HorizontalMovement = 0;

    public float Speed = 150f;

    bool JumpStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        // controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(HorizontalMovement));

        HorizontalMovement = Input.GetAxisRaw("Horizontal") * Speed;

        if (Input.GetButtonDown("Jump"))
            JumpStatus = true;
    }

    void FixedUpdate()
    {
        controller.Move(HorizontalMovement * Time.fixedDeltaTime, false, JumpStatus);
        JumpStatus = false;
    }
}
