using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    public TextMeshProUGUI MyText;
    public SomeText scriptText;
    public bool Dead = false;

    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Bad Thing(Clone)")
        {
            Dead = true;
            Debug.Log("U died! " + Dead.ToString());
            Time.timeScale = 0;
        }
    }
}
