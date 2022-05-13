using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Buttons : MonoBehaviour
{
    public Collision m_collision;
    public GameObject RestartScreen;
    public GameObject MMScreen;
    public SomeText m_text;

    public GameObject m_player;
    public Transform m_transform;
    public Rigidbody2D m_Rigidbody2D;
    public Player_Movement m_player_Movement;

    public Volume m_Volume;
    DepthOfField depthOfFieldValue;

    void Start()
    {
        RestartScreen.SetActive(false);
        DepthOfField dof;
        if(m_Volume.profile.TryGet<DepthOfField>(out dof)) { depthOfFieldValue = dof; }
        depthOfFieldValue.active = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        Debug.Log("m_collision.Dead = " + m_collision.Dead.ToString());
        Debug.Log("\ndepthOfFieldValue.active = " + depthOfFieldValue.active.ToString());
        Debug.Log("\nTime.timeScale = " + Time.timeScale.ToString());

        if (m_collision.Dead == true)
        {
            RestartScreen.SetActive(true);
            depthOfFieldValue.active = true;
        }
        else
        {
            if (Time.timeScale != 0)
                depthOfFieldValue.active = false;
            else depthOfFieldValue.active = true;
        }
    }

    public void RestartGame()
    {
        m_collision.Dead = false;
        Time.timeScale = 1;
        RestartScreen.SetActive(false);
        m_text.time = 0;
        m_text.score = 0;
        m_text.levelTimer = 0;

        m_player_Movement.HorizontalMovement = 0;
        m_transform.position = new Vector3(0, 0);
        m_Rigidbody2D.velocity = Vector3.zero;

        GameObject[] Things;
        Things = GameObject.FindGameObjectsWithTag("BadThing");
        foreach (GameObject Thing in Things)
        {
            Destroy(Thing);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        MMScreen.SetActive(false);
        Time.timeScale = 1;
    }

}
