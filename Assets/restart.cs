using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public Collision m_collision;
    public GameObject RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
        //m_collision = FindObjectOfType<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_collision.Dead == true)
        {
            Debug.Log(m_collision.Dead);
            RestartButton.SetActive(true);
        }
    }
}
