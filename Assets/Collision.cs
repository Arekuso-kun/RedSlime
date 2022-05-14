using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    public TextMeshProUGUI MyText;
    public SomeText scriptText;
    public bool Dead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("BadThing"))
        {
            Dead = true;
            Debug.Log("Dead = " + Dead.ToString());
            Time.timeScale = 0;
        }
    }
}
