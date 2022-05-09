using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D m_controller;
    public Animator m_animator;
    public Transform m_transform;  

    public float HorizontalMovement = 0f;
    public float Speed = 150f;

    bool JumpStatus = false;

    Vector2 screenBounds = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("speed", Mathf.Abs(HorizontalMovement));

        HorizontalMovement = Input.GetAxisRaw("Horizontal") * Speed;

        if (Input.GetButtonDown("Jump"))
        {
            JumpStatus = true;
            // Debug.Log(JumpStatus);
        }
        if(m_transform.position.x > screenBounds.x)
        {
            m_transform.position = new Vector3(-screenBounds.x, m_transform.position.y);
        }
        if (m_transform.position.x < -screenBounds.x)
        {
            m_transform.position = new Vector3(screenBounds.x, m_transform.position.y);
        }
    }

    void FixedUpdate()
    {
        m_controller.Move(HorizontalMovement * Time.fixedDeltaTime, false, JumpStatus);
        JumpStatus = false;
    }
}
