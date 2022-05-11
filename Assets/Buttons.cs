using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        RestartScreen.SetActive(false);
        Time.timeScale = 0;
        //m_collision = FindObjectOfType<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_collision.Dead == true)
        {
            RestartScreen.SetActive(true);
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
